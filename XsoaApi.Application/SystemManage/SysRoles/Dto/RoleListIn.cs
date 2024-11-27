namespace XsoaApi.Application;

public class RoleListIn
{
    /// <summary>
    /// 当前页
    /// </summary>
    public int Current { get; set; }

    /// <summary>
    /// 每页数
    /// </summary>
    public int Size { get; set; }

}