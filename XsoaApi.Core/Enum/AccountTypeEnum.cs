namespace XsoaApi.Core;

/// <summary>
/// 账号类型枚举
/// </summary>
[Description("账号类型枚举")]
public enum AccountTypeEnum
{
    /// <summary>
    /// 超级管理员
    /// </summary>
    [Description("超级管理员")]
    SuperAdmin = 999,

    /// <summary>
    /// 系统管理员
    /// </summary>
    [Description("系统管理员")]
    SysAdmin = 888,

    /// <summary>
    /// 部门负责人
    /// </summary>
    [Description("部门负责人")]
    NormalUser = 777,

    /// <summary>
    /// 职员
    /// </summary>
    [Description("职员")]
    Member = 666,
}