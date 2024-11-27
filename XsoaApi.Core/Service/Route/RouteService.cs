namespace XsoaApi.Core
{
    /// <summary>
    /// 动态路由
    /// </summary>
    /// <param name="userManager"></param>
    [Route("route")]
    public class RouteService(
        UserManager userManager
    ) : ControllerBase, IDynamicApiController
    {
        /// <summary>
        /// 获取固定的路由数据(不需要权限)
        /// </summary>
        [HttpGet("getConstantRoutes")]
        public IActionResult GetConstantRoutes()
        {
            var routes = new Route[]
            {
                new Route
                {
                    Name = "login",
                    Path = "/login/:module(pwd-login|code-login|register|reset-pwd|bind-wechat)?",
                    Component = "layout.blank$view.login",
                    Props = true,
                    Meta = new Meta
                    {
                        Title = "login",
                        I18nKey = "route.login",
                        Constant = true,
                        HideInMenu = true
                    }
                }
            };

            return Ok(routes);
        }

        /// <summary>
        /// 获取用户路由数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("getUserRoutes")]
        public async Task<IActionResult> GetUserRoutes()
        {
            var db = DbContext.Instance;

            var userId = userManager.UserId;
            var user = await db.Queryable<SysUser>()
                .Where(t => Equals(t.Id, userId) && t.SysIsDelete == false)
                .With(SqlWith.NoLock)
                .FirstAsync();
            if (user == null) throw Oops.Bah("账号信息丢失,请重新登录。");

            var userRolesId = user.UserRolesId;

            var menuId = await db.Queryable<SysRoleMenu>()
                .WhereIF(!userManager.SuperAdmin, r => userRolesId.Contains(r.RoleId))
                .Distinct()
                .Select(r => r.MenuId)
                .With(SqlWith.NoLock)
                .ToListAsync();

            var menus = await db.Queryable<SysMenu>()
                .WhereIF(!userManager.SuperAdmin, m => menuId.Contains(m.Id))
                .With(SqlWith.NoLock)
                .ToTreeAsync(it => it.Children, it => it.ParentId, 0);

            var routes = ConvertMenuToRoute(menus);

            return Ok(new UserRote() { Home = "home", Routes = routes });
        }

        /// <summary>
        /// 路由是否存在
        /// </summary>
        /// <returns></returns>
        [HttpGet("isRouteExist")]
        public IActionResult IsRouteExist()
        {
            return Ok();
        }

        internal static List<Route> ConvertMenuToRoute(List<SysMenu> menus)
        {
            return menus.Select(menu =>
            {
                var route = menu.Adapt<Route>();
                if (route.Children == null)
                {
                }
                else
                {
                    route.Children = ConvertMenuToRoute(menu.Children); // 递归处理子菜单
                }

                return route;
            }).ToList();
        }
    }
}