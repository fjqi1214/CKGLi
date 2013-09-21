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
        /// 厂家
        /// </summary>
        public string ManufacturerName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ImportStorage> Imports { get; set; }
    }
}
