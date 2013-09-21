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
        /// 库位
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


        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<CheckRecord> CheckRecords { get; set; }

        public virtual ICollection<ExportStorage> Exports { get; set; }

        public virtual ICollection<ImportStorage> Imports { get; set; }



    }
}
