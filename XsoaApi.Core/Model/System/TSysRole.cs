
namespace XsoaApi.Core.Models;


/// <summary>
/// t_sys_role:数据库映射类
/// </summary>
[Serializable]
[SugarTable("t_sys_role")]
public class SysRole
{
	/// <summary>
	/// 主键
	/// </summary>
	[SugarColumn(ColumnName = "Id", IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }


	/// <summary>
	/// 角色名称
	/// </summary>
	[SugarColumn(ColumnName = "RoleName")]
    public string RoleName { get; set; }

	/// <summary>
	/// 角色编码
	/// </summary>
	[SugarColumn(ColumnName = "RoleCode")]
	public string RoleCode { get; set; }

	/// <summary>
	/// 描述
	/// </summary>
	[SugarColumn(ColumnName = "RoleDesc")]
    public string RoleDesc { get; set; }

	/// <summary>
	/// 是否启用
	/// 默认值:1
	/// </summary>
	public int Status { get; set; }

	/// <summary>
	/// 数据范围(字典数据DataRang)
	/// </summary>
	[SugarColumn(ColumnName = "DataRang")]
    public string DataRang { get; set; }

	/// <summary>
	/// 数据权限(当范围为自定义时选择的部门)
	/// </summary>
	[SugarColumn(ColumnName = "Permission")]
    public string Permission { get; set; }


	/// <summary>
	/// 系统字段-创建人
	/// </summary>
	[SugarColumn(ColumnName = "SysCreateUser")]
    public int SysCreateUser { get; set; }

	/// <summary>
	/// 系统字段-创建时间
	/// 默认值:CURRENT_TIMESTAMP
	/// </summary>
	[SugarColumn(ColumnName = "SysCreateTime", IsOnlyIgnoreInsert = true)]
    public DateTime SysCreateTime { get; set; }

	/// <summary>
	/// 系统字段-修改人
	/// </summary>
	[SugarColumn(ColumnName = "SysUpdateUser")]
    public int SysUpdateUser { get; set; }

	/// <summary>
	/// 系统字段-修改时间
	/// 默认值:CURRENT_TIMESTAMP
	/// </summary>
	[SugarColumn(ColumnName = "SysUpdateTime", IsOnlyIgnoreInsert = true)]
    public DateTime SysUpdateTime { get; set; }

	/// <summary>
	/// 系统字段-删除人
	/// </summary>
	[SugarColumn(ColumnName = "SysDeleteUser")]
    public int SysDeleteUser { get; set; }

	/// <summary>
	/// 系统字段-删除时间
	/// </summary>
	[SugarColumn(ColumnName = "SysDeleteTime", IsOnlyIgnoreInsert = true)]
    public DateTime SysDeleteTime { get; set; }

	/// <summary>
	/// 系统字段-删除标记
	/// 默认值:0
	/// </summary>
	[SugarColumn(ColumnName = "SysIsDelete", DefaultValue = "0")]
    public bool SysIsDelete { get; set; }
}