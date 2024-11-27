namespace XsoaApi.Application;

public class DtoSales
{
    [SugarColumn(ColumnName = "drxs")] public double Drxs { get; set; }
    [SugarColumn(ColumnName = "drsc")] public double Drsc { get; set; }
    [SugarColumn(ColumnName = "byxs")] public double Byxs { get; set; }
    [SugarColumn(ColumnName = "byhk")] public double Byhk { get; set; }
}

public class DtoSalesChain
{
    [SugarColumn(ColumnName = "rq")] public string? Rq { get; set; }
    [SugarColumn(ColumnName = "is_sc")] public string? IsSc { get; set; }
    [SugarColumn(ColumnName = "hsje")] public string? Hsje { get; set; }
}