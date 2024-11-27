using XsoaApi.Application.Sales.Dto;

namespace XsoaApi.Application;

[Route("sales")]
public class SalesService(UserManager userManager) : ControllerBase, IDynamicApiController
{
    /// <summary>
    /// 销售查询
    /// </summary>
    /// <returns></returns>
    [HttpGet("getSalesAmount")]
    public async Task<IActionResult> GetSalesAmount(SalesIn input)
    {
        if (input.Month == null) return Ok();
        var db = DbContext.Instance;

        var total = new RefAsync<int>(0);
        List<string> ywyList = [];
        if (!userManager.SuperAdmin) ywyList = await GetUserList();

        var salesAmount = await db.Queryable<Order>()
            .OrderBy(c => c.Rq, OrderByType.Desc)
            .OrderBy(c => c.Djbs)
            .Where(c => c.Djbh!.StartsWith("xs[abc]") && c.Rq!.StartsWith(input.Month))
            .WhereIF(!userManager.SuperAdmin, c => ywyList.Contains(c.Ywy))
            .WhereIF(!string.IsNullOrEmpty(input.Ywy), c => c.Ywy == input.Ywy)
            .WhereIF(!string.IsNullOrEmpty(input.Dwmch), c => c.Dwmch.Contains(input.Dwmch))
            .Select<SalesAmount>()
            .Includes(s => s.OrderItem.OrderBy(d => SqlFunc.Asc(d.DjSort)).ToList())
            .With(SqlWith.NoLock)
            .ToPageListAsync(input.Current, input.Size, total);

        var result = new PageList<SalesAmount>()
        {
            Current = input.Current,
            Size = input.Size,
            Total = total,
            Records = salesAmount
        };

        return Ok(result);
    }

    /// <summary>
    /// 销售汇总查询
    /// </summary>
    /// <returns></returns>
    [HttpGet("getSalesAmountSummary")]
    public async Task<IActionResult> GetSalesAmountSummary(SalesIn input)
    {
        if (input.Month == null) return Ok();
        var db = DbContext.Instance;

        var total = new RefAsync<int>(0);
        List<string> ywyList = [];
        if (!userManager.SuperAdmin) ywyList = await GetUserList();

        var salesSummary = await db.Queryable<Order>()
            .RightJoin<OrderDetails>((c, d) => c.Djbh == d.Djbh)
            .GroupBy((c,d) => d.Abcfl)
            .Where(c => c.Djbh!.StartsWith("xs[abc]") && c.Rq!.StartsWith(input.Month))
            .WhereIF(!userManager.SuperAdmin, c => ywyList.Contains(c.Ywy))
            .WhereIF(!string.IsNullOrEmpty(input.Ywy), c => c.Ywy == input.Ywy)
            .WhereIF(!string.IsNullOrEmpty(input.Dwmch), c => c.Dwmch.Contains(input.Dwmch))
            .Select((c,d) => new { Abcfl = d.Abcfl, Hjse = SqlFunc.AggregateSum(d.Hsje)})
            .With(SqlWith.NoLock)
            .ToListAsync();

        return Ok(salesSummary);
    }

    /// <summary>
    /// 取业务员列表
    /// </summary>
    /// <returns></returns>
    private async Task<List<string>> GetUserList()
    {
        var db = DbContext.Instance;

        var user = await db.Queryable<SysUser>()
            .Where(u => u.Id == userManager.UserId).FirstAsync();
        if (user == null) throw Oops.Bah("账号信息丢失,请重新登录。");

        // 默认仅看自己，当账户类型为777部门负责人时查询本部门及下属成员
        List<string> userList = [user.Name];
        switch (user.AccountType)
        {
            case (int)AccountTypeEnum.NormalUser:
            {
                var orgs = await db.Queryable<SysOrg>()
                    .ToChildListAsync(it => it.ParentId, user.OrgId);
                var oList = orgs.Select(o => o.Id).ToList();

                userList = await db.Queryable<SysUser>()
                    .Where(u => oList.Contains(u.OrgId))
                    .Select(u => u.Name)
                    .ToListAsync();
                break;
            }
        }

        return userList;
    }
}