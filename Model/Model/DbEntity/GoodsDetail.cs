using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 厂家产品表
    /// </summary>
    public class GoodsDetail
    {
        /// <summary>
        /// 品名
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 厂家名称
        /// </summary>
        public string ManufacturerName { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Units{ get; set; }

        /// <summary>
        /// 有效日期 天数或月数或年数
        /// </summary>
        public int EffectiveDate { get; set; }

        /// <summary>
        /// 保留
        /// </summary>
        public string Reserve1 { get; set; }

        /// <summary>
        /// 保留
        /// </summary>
        public string Reserve2 { get; set; }



        public virtual Manufacturer Manu { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ImportStorage> Imports { get; set; }
        public virtual ICollection<ExportStorage> Exps { get; set; }
        public virtual ICollection<CheckRecord> Checks { get; set; }

    }
}
