using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Model
{
    /// <summary>
    /// 厂家表
    /// </summary>
    public class Manufacturer
    {
     
        /// <summary>
        /// 厂家名
        /// </summary>
        public string ManufacturerName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 保留
        /// </summary>
        public string Reserve { get; set; }



        public virtual ICollection<StoragePriority> StoragePrioritys { get; set; } 
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ImportStorage> Imports { get; set; }
        public virtual ICollection<GoodsDetail> GoodsDetails { get; set; }
        public virtual ICollection<ExportStorage> Exps { get; set; }
        public virtual ICollection<CheckRecord> Checks { get; set; }



    }
}
