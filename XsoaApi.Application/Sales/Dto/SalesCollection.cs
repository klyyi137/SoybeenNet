namespace XsoaApi.Application.Sales.Dto
{
    public class SalesCollection
    {
        [SugarColumn(ColumnName = "rq")]
        public string? Rq { get; set; }
        [SugarColumn(ColumnName = "djbh")]
        public string? Djbh { get; set; }
        [SugarColumn(ColumnName = "dwmch")]
        public string? Dwmch { get; set; }
        [SugarColumn(ColumnName = "hsje")]
        public string? Hsje { get; set; }
        [SugarColumn(ColumnName = "ywy")]
        public string? Ywy { get; set; }
        [SugarColumn(ColumnName = "is_sc")]
        public string? IsSc { get; set; }
        [SugarColumn(ColumnName = "djbs")]
        public string? Djbs { get; set; }
        [SugarColumn(ColumnName = "RowIndex")]
        public string? RowIndex { get; set; }
        [Navigate(NavigateType.OneToMany, nameof(SkYwjsmxk.Djbh), nameof(Djbh))]
        public List<SkYwjsmxk>? Details { get; set; }

    }
}
