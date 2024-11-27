namespace XsoaApi.Core;

public class AuthUserLoginIn
{
    /// <summary>
    /// 登录账号
    /// </summary>
    /// <example>admin</example>
    public string UserName { get; set; }


    /// <summary>
    /// 密码
    /// </summary>
    /// <example>123456</example>
    public string PassWord { get; set; }
}