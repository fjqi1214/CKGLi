using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 
    /// </summary>
    public class StorageCategory
    {
        /// <summary>
        /// 库编号
        /// </summary>
        public string StorageNumber { get; set; }

        /// <summary>
        /// 货架类型
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 保留
        /// </summary>
        public string Reserve { get; set; }


        public virtual ICollection<StorageLocation> StorageLocations { get; set; }
        public virtual ICollection<StoragePriority> StoragePrioritys { get; set; }
    }
}
