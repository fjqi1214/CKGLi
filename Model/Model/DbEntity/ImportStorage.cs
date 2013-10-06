using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{

    /// <summary>
    /// 入库表
    /// </summary>
    public class ImportStorage
    {
        public ImportStorage()
        {
            ProductTime = DateTime.Now;
            ArrivalTime = DateTime.Now;
        }

        /// <summary>
        /// 厂家
        /// </summary>
        public string ManufacturerName { get; set; }

        /// <summary>
        /// 库位
        /// </summary>
        public string LocationName { get; set; }

        /// <summary>
        /// 品名
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Lot.NO
        /// </summary>
        public string LotNum { get; set; }

        /// <summary>
        /// 生产时间
        /// </summary>
        public DateTime ProductTime { get; set; }

        /// <summary>
        /// 到货时间
        /// </summary>
        public DateTime ArrivalTime { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Number { get; set; }

       
        /// <summary>
        /// 料号
        /// </summary>
        public string MaterialNo { get; set; }

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
