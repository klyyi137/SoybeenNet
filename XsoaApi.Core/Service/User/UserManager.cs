namespace XsoaApi.Core;

/// <summary>
/// 当前登录用户
/// </summary>
public class UserManager(IHttpContextAccessor httpContextAccessor) : IScoped
{
    /// <summary>
    /// 用户ID
    /// </summary>
    public long UserId => (httpContextAccessor.HttpContext?.User.FindFirst(ClaimConst.UserId)?.Value).ToLong();

    /// <summary>
    /// 用户账号
    /// </summary>
    public string Account => httpContextAccessor.HttpContext?.User.FindFirst(ClaimConst.Account)?.Value;

    /// <summary>
    /// 真实姓名
    /// </summary>
    public string Name => httpContextAccessor.HttpContext?.User.FindFirst(ClaimConst.Name)?.Value;

    /// <summary>
    /// 是否超级管理员
    /// </summary>
    public bool SuperAdmin => httpContextAccessor.HttpContext?.User.FindFirst(ClaimConst.AccountType)?.Value == ((int)AccountTypeEnum.SuperAdmin).ToString();

    /// <summary>
    /// 是否系统管理员
    /// </summary>
    public bool SysAdmin => httpContextAccessor.HttpContext?.User.FindFirst(ClaimConst.AccountType)?.Value == ((int)AccountTypeEnum.SysAdmin).ToString();

    /// <summary>
    /// 组织机构Id
    /// </summary>
    public long OrgId => (httpContextAccessor.HttpContext?.User.FindFirst(ClaimConst.OrgId)?.Value).ToLong();

    /// <summary>
    /// 微信OpenId
    /// </summary>
    public string OpenId => httpContextAccessor.HttpContext?.User.FindFirst(ClaimConst.OpenId)?.Value;
}