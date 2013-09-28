using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 出库表
    /// </summary>
    public class ExportStorage
    {
        /// <summary>
        /// 库位
        /// </summary>
        public string LocationName { get; set; }

        /// <summary>
        /// 品名
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 厂家
        /// </summary>
        public string ManufacturerName { get; set; }
        
        /// <summary>
        /// lot.号
        /// </summary>
        public string LotNumber { get; set; }

        /// <summary>
        /// 出库时间
        /// </summary>
        public DateTime ExpTime { get; set; }

        /// <summary>
        /// 出库数量
        /// </summary>
        public int ExpNum { get; set; }

        /// <summary>
        /// 单位数量
        /// </summary>
        public int UnitNum { get; set; }

        /// <summary>
        /// 编号（自增）
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 保留
        /// </summary>
        public string Reserve { get; set; }



        public virtual Manufacturer Manu { get; set; }

        public virtual StorageLocation StorageL { get; set; }

        public virtual GoodsDetail Goods { get; set; }


    }
}
