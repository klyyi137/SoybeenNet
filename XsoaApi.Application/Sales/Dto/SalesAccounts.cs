namespace XsoaApi.Application.Sales.Dto
{
    public class SalesAccounts
    {
        [SugarColumn(ColumnName = "rq")]
        public string? Rq { get; set; }
        [SugarColumn(ColumnName = "djbh")]
        public string? Djbh { get; set; }
        [SugarColumn(ColumnName = "dwmch")]
        public string? Dwmch { get; set; }
        [SugarColumn(ColumnName = "wjsje")]
        public decimal? Wjsje { get; set; }
        [SugarColumn(ColumnName = "ywy")]
        public string? Ywy { get; set; }
        [SugarColumn(ColumnName = "is_sc")]
        public string? IsSc { get; set; }
        [SugarColumn(ColumnName = "djbs")]
        public string? Djbs { get; set; }
        [SugarColumn(ColumnName = "RowIndex")]
        public string? RowIndex { get; set; }

    }
}
