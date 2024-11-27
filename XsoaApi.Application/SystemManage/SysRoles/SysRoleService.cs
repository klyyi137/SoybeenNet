namespace XsoaApi.Application
{
    /// <summary>
    /// 权限管理服务接口
    /// </summary>
    /// <param name="sysRoleRep"></param>
    [Route("systemManage")]
    public class SysRoleService(SqlSugarRepository<SysRole> sysRoleRep) : ControllerBase, IDynamicApiController
    {
        /// <summary>
        /// 获取所有权限
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var list = await sysRoleRep.Context.Queryable<SysRole>()
                .Select<RoleListOut>().ToListAsync();

            return Ok(list);
        }

        /// <summary>
        /// 取角色列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("getRoleList")]
        public async Task<IActionResult> GetRoleList(RoleListIn input)
        {
            var totalNumber = new RefAsync<int>(0);
            var roleList = await sysRoleRep.Context.Queryable<SysRole>()
                .Where(m => m.SysIsDelete == false)
                .ToPageListAsync(input.Current,input.Size, totalNumber);
            
            var pageList = new PageList<SysRole>
            {
                Current = input.Current,
                Size = input.Size,
                Total = totalNumber,
                Records = roleList
            };

            return Ok(pageList);
        }
    }
}