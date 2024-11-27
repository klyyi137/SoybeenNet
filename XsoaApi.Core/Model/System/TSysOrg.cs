namespace XsoaApi.Core.Models;


/// <summary>
/// t_sys_menu:���ݿ�ӳ����
/// </summary>
[Serializable]
[SugarTable("t_sys_org")]
public class SysOrg
{
    /// <summary>
    /// ����
    /// </summary>
    [SugarColumn(ColumnName = "Id", IsPrimaryKey = true, IsIdentity = true)]
    public long Id { get; set; }

    [SugarColumn(ColumnName = "ParentId")]
    public int ParentId { get; set; }

    [SugarColumn(ColumnName = "Name")]
    public string Name { get; set; }

    [SugarColumn(ColumnName = "Description")]
    public string Description { get; set; }

    [SugarColumn(ColumnName = "Status")]
    public int Status { get; set; }
}