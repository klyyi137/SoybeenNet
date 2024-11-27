using Furion;
using Furion.DataValidation;
using Furion.DependencyInjection;
using Furion.FriendlyException;
using Furion.UnifyResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XsoaApi.Web.Core;

/// <summary>
/// RESTful 风格返回值
/// </summary>
[SuppressSniffer, UnifyModel(typeof(RESTfulResult<>))]
public class ResTfulResultProvider : IUnifyResultProvider
{
    /// <summary>
    /// JWT 授权异常返回值
    /// </summary>
    /// <param name="context"></param>
    /// <param name="metadata"></param>
    /// <returns></returns>
    public IActionResult OnAuthorizeException(DefaultHttpContext context, ExceptionMetadata metadata)
    {
        return new JsonResult(ResTfulResult(metadata.StatusCode, data: metadata.Data, errors: metadata.Errors)
            , UnifyContext.GetSerializerSettings(context));
    }

    /// <summary>
    /// 异常返回值
    /// </summary>
    /// <param name="context"></param>
    /// <param name="metadata"></param>
    /// <returns></returns>
    public IActionResult OnException(ExceptionContext context, ExceptionMetadata metadata)
    {
        return new JsonResult(ResTfulResult(metadata.StatusCode, data: metadata.Data, msg: metadata.Errors.ToString())
            , UnifyContext.GetSerializerSettings(context));
    }

    /// <summary>
    /// 成功返回值
    /// </summary>
    /// <param name="context"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public IActionResult OnSucceeded(ActionExecutedContext context, object data)
    {
        return new JsonResult(ResTfulResult(StatusCodes.Status200OK, data: data, msg: "请求成功")
            , UnifyContext.GetSerializerSettings(context));
    }

    /// <summary>
    /// 验证失败/业务异常返回值
    /// </summary>
    /// <param name="context"></param>
    /// <param name="metadata"></param>
    /// <returns></returns>
    public IActionResult OnValidateFailed(ActionExecutingContext context, ValidationMetadata metadata)
    {
        return new JsonResult(ResTfulResult(metadata.StatusCode ?? StatusCodes.Status400BadRequest
                , data: metadata.Data
                , msg: !metadata.SingleValidationErrorDisplay ? metadata.ValidationResult.ToString() : metadata.FirstErrorMessage)
            , UnifyContext.GetSerializerSettings(context));
    }

    /// <summary>
    /// 特定状态码返回值
    /// </summary>
    /// <param name="context"></param>
    /// <param name="statusCode"></param>
    /// <param name="unifyResultSettings"></param>
    /// <returns></returns>
    public async Task OnResponseStatusCodes(HttpContext context, int statusCode,
        UnifyResultSettingsOptions unifyResultSettings)
    {
        // 设置响应状态码
        UnifyContext.SetResponseStatusCodes(context, statusCode, unifyResultSettings);

        switch (statusCode)
        {
            // 处理 401 状态码
            case StatusCodes.Status401Unauthorized:
                await context.Response.WriteAsJsonAsync(ResTfulResult(statusCode, msg: "401 Unauthorized")
                    , App.GetOptions<JsonOptions>()?.JsonSerializerOptions);
                break;
            // 处理 403 状态码
            case StatusCodes.Status403Forbidden:
                await context.Response.WriteAsJsonAsync(ResTfulResult(statusCode, msg: "403 Forbidden")
                    , App.GetOptions<JsonOptions>()?.JsonSerializerOptions);
                break;
        }
    }

    /// <summary>
    /// 返回 RESTful 风格结果集
    /// </summary>
    /// <param name="code"></param>
    /// <param name="msg"></param>
    /// <param name="data"></param>
    /// <param name="errors"></param>
    /// <returns></returns>
    public static CustomResTfulResult<object> ResTfulResult(int code, string msg = default, object data = default,
        object errors = default)
    {
        return new CustomResTfulResult<object>
        {
            Code = code == 200 ? "0000" : code.ToString(),
            Msg = msg,
            Data = data,
            Errors = errors
        };
    }
}

[SuppressSniffer]
public class CustomResTfulResult<T>
{
    /// <summary>
    /// 状态码
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 数据
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public T Data { get; set; }

    /// <summary>
    /// 执行成功
    /// </summary>
    public string Msg { get; set; }

    /// <summary>
    /// 错误信息
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object Errors { get; set; } = null;
}