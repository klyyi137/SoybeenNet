namespace XsoaApi.Core.Models;

/// <summary>
/// 角色菜单表
/// </summary>
[SugarTable("t_sys_role_menu")]
public class SysRoleMenu : ModelBase
{
    /// <summary>
    /// 角色ID
    /// </summary>
    [SugarColumn(ColumnName = "RoleId")]
    public int RoleId { get; set; }

    /// <summary>
    /// 菜单ID
    /// </summary>
    [SugarColumn(ColumnName = "MenuId")]
    public int MenuId { get; set; }
}