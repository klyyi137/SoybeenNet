namespace XsoaApi.Core
{
    /// <summary>
    /// 用户登录服务接口
    /// </summary>
    [Route("auth")]
    public class AuthAppService(
        SqlSugarRepository<SysUser> sysUserRep,
        UserManager userManager,
        IHttpContextAccessor httpContextAccessor)
        : ControllerBase, IDynamicApiController
    {
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<AuthUserLoginOut> Login([FromBody] AuthUserLoginIn input)
        {
            var db = DbContext.Instance;

            var user = await db.Queryable<SysUser>()
                .Where(c => c.Account == input.UserName).FirstAsync();
            if (user == null) throw Oops.Oh(UserErrorCodes.U1000);

            //if (!MD5Encryption.Compare(input.PassWord, user.PassWord)) throw Oops.Oh(UserErrorCodes.U1000);
            if (!Equals(input.PassWord, user.PassWord)) throw Oops.Oh(UserErrorCodes.U1000);

            if (user.Status != 1) throw Oops.Bah("该账户已被冻结");

            return await CreateToken(user);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        //[AllowAnonymous]
        [HttpGet("getUserInfo")]
        public async Task<IActionResult> GetUserInfo()
        {
            var userId = userManager.UserId;
            var user = await sysUserRep
                .Where(t => Equals(t.Id, userId) && t.SysIsDelete == false).FirstAsync();
            if (user == null) throw Oops.Bah("账号信息丢失,请重新登录。");
            var userInfo = user.Adapt<AuthUserInfoOut>();
            if (userManager.SuperAdmin) userInfo.Roles = ["R_SUPER"];
            return Ok(userInfo);
        }
        
        /// <summary>
        /// 生成Token令牌 🔖
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [NonAction]
        internal virtual async Task<AuthUserLoginOut> CreateToken(SysUser user)
        {
            // 生成Token令牌
            var accessToken = JWTEncryption.Encrypt(new Dictionary<string, object>
            {
                { ClaimConst.UserId, user.Id },
                { ClaimConst.Account, user.Account },
                { ClaimConst.Name, user.Name },
                { ClaimConst.AccountType, user.AccountType },
                { ClaimConst.OrgId, user.OrgId }
            });

            // 生成刷新Token令牌
            var refreshToken = JWTEncryption.GenerateRefreshToken(accessToken);

            // 设置响应报文头
            httpContextAccessor.HttpContext.SetTokensOfResponseHeaders(accessToken, refreshToken);

            return new AuthUserLoginOut
            {
                Token = accessToken,
                RefreshToken = refreshToken
            };
        }
    }
}