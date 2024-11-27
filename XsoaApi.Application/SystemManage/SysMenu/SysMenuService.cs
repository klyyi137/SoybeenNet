namespace XsoaApi.Application
{
    /// <summary>
    /// 菜单管理服务接口
    /// </summary>
    [Route("systemManage")]
    public class SysMenuService(SqlSugarRepository<SysMenu> sysMenuRep) : ControllerBase, IDynamicApiController
    {
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("getMenuList")]
        public IActionResult GetMenuList()
        {
            return Ok();
        }

        /// <summary>
        /// 获取菜单树
        /// </summary>
        /// <returns></returns>
        [HttpGet("getMenuList/v2")]
        public async Task<IActionResult> GetMenuList2()
        {
            var ids = new List<int> { 9, 10, 11, 12, 13, 44 };
            var sysmenulist = await sysMenuRep.Context.Queryable<SysMenu>()
                .Where(m => m.SysIsDelete == false)
                //.Select<MenuList>()
                //.In(m => m.Id, ids)
                .ToTreeAsync(x => x.Children, x => x.ParentId, 0);
            var pageList = new PageList<SysMenu>
            {
                Current = 1,
                Size = 20,
                Total = 1,
                Records = sysmenulist.OrderBy(x => x.Order).ToList()
            };
            return Ok(pageList);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost("sysMenu/add")]
        public async Task<bool> Add([FromBody] MenuAddandUpIn input)
        {
            var isExist = await sysMenuRep.Where(x => x.RoutePath == input.RoutePath ||
                                                      x.RouteName == input.RouteName || x.MenuName == input.RouteName)
                .AnyAsync();
            if (isExist) throw Oops.Bah("当前菜单已存在");
            var entity = input.Adapt<SysMenu>();
            return await sysMenuRep.InsertReturnIdentityAsync(entity) > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("sysMenu/delete")]
        public async Task<bool> Delete(int id)
        {
            var entity = await sysMenuRep.FirstOrDefaultAsync(u => u.Id == id);
            if (entity == null) throw Oops.Bah("未找到当前菜单");
            entity.SysIsDelete = true;
            return await sysMenuRep.UpdateAsync(entity) > 0;
        }

        /// <summary>
        /// 更新菜单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("sysMenu/update")]
        public async Task<bool> Update([FromBody]MenuAddandUpIn input)
        {
            var entity = await sysMenuRep.FirstOrDefaultAsync(u => u.Id == input.Id);
            if (entity == null) throw Oops.Bah("未找到当前账号");

            var sysRole = input.Adapt<SysMenu>();
            return await sysMenuRep.AsUpdateable(sysRole).IgnoreColumns(false).ExecuteCommandAsync() > 0;
        }

        /// <summary>
        /// 获取所有页面组件
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAllPages")]
        public IActionResult GetAllPage()
        {
            var page =
           new List<string>( [
                "home",
                "403",
                "404",
                "405",
                "function_multi-tab",
                "function_tab",
                "exception_403",
                "exception_404",
                "exception_500",
                "multi-menu_first_child",
                "multi-menu_second_child_home",
                "manage_user",
                "manage_role",
                "manage_menu",
                "manage_user-detail",
                "about",
                "ttt"
            ]);
            return Ok(page);
        }

        /*
        /// <summary>
        /// 用户菜单
        /// </summary>
        /// <returns></returns>
        public async Task<List<RoleListOut>> GetUserMenu()
        {
            var list = await _sysMenuRep.Context.Queryable<TSysRole>()
                .Select<RoleListOut>().ToListAsync();
            return list;
        }

        /// <summary>
        /// 全部菜单
        /// </summary>
        /// <returns></returns>
        public async Task<List<RoleListOut>> GetAllMenu()
        {
            var list = await _sysMenuRep.Context.Queryable<TSysRole>()
                .Select<RoleListOut>().ToListAsync();
            return list;
        }
        */
    }
}