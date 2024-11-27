namespace XsoaApi.Application
{
    public class SalesAmount
    {
        [SugarColumn(ColumnName = "RowIndex")]
        public int Id { get; set; }
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
        public string? Issc { get; set; }
        [SugarColumn(ColumnName = "djbs")]
        public string? Djbs { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [Navigate(NavigateType.OneToMany, nameof(OrderDetails.Djbh), nameof(Djbh))]
        public List<OrderDetails> OrderItem { get; set; }
    }
}