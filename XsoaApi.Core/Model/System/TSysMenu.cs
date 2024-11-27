namespace XsoaApi.Core.Models;

#nullable enable
/// <summary>
/// t_sys_menu:数据库映射类
/// </summary>
[Serializable]
[SugarTable("t_sys_menu")]
public class SysMenu : ModelBase
{
    /// <summary>
    /// 主键
    /// </summary>
    [SugarColumn(ColumnName = "Id", IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }

    /// <summary>
    /// Desc:菜单类型1 .目录 2.菜单
    /// Default:
    /// Nullable:False
    /// </summary>
    public string MenuType { get; set; }

    /// <summary>
    /// 
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
    public string? I18nKey { get; set; } = null;

    /// <summary>
    /// Desc:图标
    /// Default:0
    /// Nullable:False
    /// </summary>
    public string? Icon { get; set; } = null;

    /// <summary>
    /// 图标类型
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
    public bool? KeepAlive { get; set; } = null;

    /// <summary>
    /// 常量路由
    /// </summary>
    public bool? Constant { get; set; } = null;

    /// <summary>
    /// Desc:排序
    /// Default:0
    /// Nullable:True
    /// </summary>
    public int? Order { get; set; } = null;

    /// <summary>
    /// 
    /// </summary>
    public string? Href { get; set; } = null;

    /// <summary>
    /// Desc:隐藏菜单
    /// Default:0
    /// Nullable:False
    /// </summary>
    public bool? HideInMenu { get; set; } = null;

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>
    public string? ActiveMenu { get; set; } = null;

    /// <summary>
    /// 支持多页签
    /// </summary>
    public bool? MultiTab { get; set; } = null;

    /// <summary>
    /// 固定在页签中的序号
    /// </summary>
    public int? FixedIndexInTab { get; set; } = null;
    
    /// <summary>
    /// 路由参数
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string> Query { get; set; } = [];

    /// <summary>
    /// 按钮
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string> Buttons { get; set; } = [];

    /// <summary>
    /// 子菜单
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<SysMenu>? Children { get; set; } = null;
}