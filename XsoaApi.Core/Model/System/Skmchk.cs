namespace XsoaApi.Core.Models
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("mchk")]
    public class SkMchk
    {
        
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="dwbh" ,IsPrimaryKey = true) ]
        public string Dwbh  { get; set;  } = null!;
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="danwbh" ) ]
        public string? Danwbh  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="dwmch" ) ]
        public string? Dwmch  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="zjm" ) ]
        public string? Zjm  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="kehufl" ) ]
        public string? Kehufl  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="kehulb" ) ]
        public string? Kehulb  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="kehudengji" ) ]
        public string? Kehudengji  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="beactive" ) ]
        public string? Beactive  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="hkqx" ) ]
        public decimal? Hkqx  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="dw_xz" ) ]
        public string? DwXz  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="province" ) ]
        public string? Province  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="city" ) ]
        public string? City  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="county" ) ]
        public string? County  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="street" ) ]
        public string? Street  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="createtime" ) ]
        public string? Createtime  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="kdy" ) ]
        public string? Kdy  { get; set;  } 
    

    }
    
}