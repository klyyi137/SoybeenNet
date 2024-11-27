namespace XsoaApi.Core
{
    [ErrorCodeType]
    public enum ErrorCodes
    {
        [ErrorCodeItemMetadata("{0} 不能小于 {1}")]
        Z1000,

        [ErrorCodeItemMetadata("数据不存在")] X1000,

        [ErrorCodeItemMetadata("{0} 发现 {1} 个异常", "百小僧", 2)]
        X1001,

        [ErrorCodeItemMetadata("服务器运行异常", ErrorCode = "Error")]
        ServerError
    }

    [ErrorCodeType]
    public enum UserErrorCodes
    {
        [ErrorCodeItemMetadata("用户名或密码错误")] U1000,

        [ErrorCodeItemMetadata("其他异常")] U1001
    }
}