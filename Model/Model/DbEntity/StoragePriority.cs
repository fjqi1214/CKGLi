using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 库位优先级
    /// </summary>
    public class StoragePriority
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// 厂家名称
        /// </summary>
        public string ManufacturerName { get; set; }

        /// <summary>
        /// 库编号
        /// </summary>
        public string StorageNumber { get; set; }

        /// <summary>
        /// 优先级 1-6 越低越高
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 备用
        /// </summary>
        public string Reserve { get; set; }

        public Manufacturer Man { get; set; }
        public StorageCategory Categroy { get; set; }

    }
}
