namespace XsoaApi.Core.Models
{
    /// <summary>
    /// 销售单明细视图
    ///</summary>
    [SugarTable("Das_OrderDetails")]
    public class OrderDetails
    {
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "djbh")]
        public string Djbh { get; set; }

        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "dj_sn")]
        public string DjSn { get; set; }

        /// <summary>
        /// 备  注:
        /// 默认值:
        /// </summary>
        [SugarColumn(ColumnName = "dj_sort")]
        public string DjSort { get; set; }

        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "spbh")]
        public string Spbh { get; set; }

        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "spmch")]
        public string Spmch { get; set; }

        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "shpgg")]
        public string Shpgg { get; set; }

        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "shpchd")]
        public string Shpchd { get; set; }

        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "dw")]
        public string Dw { get; set; }

        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "shl")]
        public string Shl { get; set; }

        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "hshj")]
        public string Hshj { get; set; }

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
        [SugarColumn(ColumnName = "abcfl")]
        public string Abcfl { get; set; }
    }
}