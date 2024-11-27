namespace XsoaApi.Application
{
    public class Mapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<SysUser, AuthUserInfoOut>()
                .Map(dest => dest.UserId, src => src.Id)
                .Map(dest => dest.UserName, src => src.Name)
                //.Map(dest => dest.Roles,src => src.UserRolesId.Select(x=>x.ToString()).ToList());
                .Map(dest => dest.Roles, src => src.UserRolesId.Select(x => x.ToString()).ToList());

            config.ForType<SysMenu, Route>()
                .Map(dest => dest.Name, src => src.RouteName)
                .Map(dest => dest.Path, src => src.RoutePath)
                .Map(dest => dest.Component, src => src.Component)
                .Map(dest => dest.Meta.Title, src => src.MenuName)
                .Map(dest => dest.Meta.I18nKey, src => src.I18nKey)
                .Map(dest => dest.Meta.Order, src => src.Order)
                .Map(dest => dest.Meta.KeepAlive, src => src.KeepAlive)
                .Map(dest => dest.Meta.Constant, src => src.Constant)
                .Map(dest => dest.Meta.Icon, src => src.Icon)
                .Map(dest => dest.Meta.Href, src => src.Href)
                .Map(dest => dest.Meta.HideInMenu, src => src.HideInMenu)
                .Map(dest => dest.Meta.ActiveMenu, src => src.ActiveMenu)
                .Map(dest => dest.Meta.MultiTab, src => src.MultiTab)
                .Map(dest => dest.Meta.FixedIndexInTab, src => src.FixedIndexInTab)
                ;
        }
    }
}