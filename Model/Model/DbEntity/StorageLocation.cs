using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 库位表
    /// </summary>
    public class StorageLocation
    {
        /// <summary>
        /// 货架号
        /// </summary>
        public string LocationName { get; set; }

        /// <summary>
        /// 厂家
        /// </summary>
        public string ManufacturerName { get; set; }

        /// <summary>
        /// 品名
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 货架
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 是否可用 true可用 false不可用
        /// </summary>
        public bool CanUse { get; set; }

        public string Reserve { get; set; }

        public virtual StorageCategory Category { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<CheckRecord> CheckRecords { get; set; }

        public virtual ICollection<ExportStorage> Exps { get; set; }

        public virtual ICollection<ImportStorage> Imports { get; set; }

        public virtual ICollection<CheckRecord> Checks { get; set; }

    }
}
