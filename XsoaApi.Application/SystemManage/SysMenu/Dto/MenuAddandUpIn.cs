namespace XsoaApi.Application;

public class MenuAddandUpIn
{
    /// <summary>
    /// 菜单id
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    /// Desc:菜单类型1 .目录 2.菜单
    /// Default:
    /// Nullable:False
    /// </summary>
    public string MenuType { get; set; }

    /// <summary>
    /// Desc:菜单名称
    /// Default:
    /// </summary>
    public string MenuName { get; set; }

    /// <summary>
    /// Desc:路由名称
    /// Default:
    /// Nullable:False
    /// </summary>
    public string RouteName { get; set; }

    /// <summary>
    /// Desc:路由路径
    /// Default:
    /// Nullable:False
    /// </summary>
    public string RoutePath { get; set; }

    /// <summary>
    /// Desc:页面组件
    /// Default:
    /// Nullable:False
    /// </summary>
    public string Component { get; set; }

    /// <summary>
    /// 国际化key
    /// </summary>
    public string I18NKey { get; set; }

    /// <summary>
    /// Desc:图标
    /// Default:0
    /// Nullable:False
    /// </summary>
    public string Icon { get; set; }

    /// <summary>
    /// Desc:图标类型
    /// Default:0
    /// Nullable:False
    /// </summary>
    public string IconType { get; set; }

    /// <summary>
    /// Desc:父级菜单ID
    /// Default:
    /// Nullable:False
    /// </summary>
    public int ParentId { get; set; }

    /// <summary>
    /// Desc:菜单状态
    /// Default:
    /// Nullable:True
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// 缓存路由
    /// </summary>
    public bool? KeepAlive { get; set; }

    /// <summary>
    /// 常量路由
    /// </summary>
    public bool? Constant { get; set; }

    /// <summary>
    /// Desc:排序
    /// Default:0
    /// Nullable:True
    /// </summary>
    public int? Order { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Href { get; set; }

    /// <summary>
    /// Desc:隐藏菜单
    /// Default:0
    /// Nullable:False
    /// </summary>
    public bool HideInMenu { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string ActiveMenu { get; set; }

    /// <summary>
    /// 支持多页签
    /// </summary>
    public bool? MultiTab { get; set; }

    /// <summary>
    /// 固定在页签中的序号
    /// </summary>
    public int? FixedIndexInTab { get; set; }

    /*
    /// <summary>
    /// 路由参数
    /// </summary>
    public List<string> Query { get; set; }

    /// <summary>
    /// 按钮
    /// </summary>
    public List<string> Buttons { get; set; }
    */
}