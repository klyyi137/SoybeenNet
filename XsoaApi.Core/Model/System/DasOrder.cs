namespace XsoaApi.Core.Models
{
    /// <summary>
    /// 销售单视图
    /// </summary>
    [SugarTable("Das_Order")]
    public class Order
    {
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "djbh", IsPrimaryKey = true)]
        public string Djbh { get; set; }

        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "rq")]
        public string Rq { get; set; }

        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "dwmch")]
        public string Dwmch { get; set; }

        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "hsje")]
        public string Hsje { get; set; }

        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "ywy")]
        public string Ywy { get; set; }

        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "is_sc")]
        public string Issc { get; set; }

        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "djbs")]
        public string Djbs { get; set; }

    }
}