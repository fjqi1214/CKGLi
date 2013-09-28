using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 盘点表
    /// </summary>
    public class CheckRecord
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
        /// 厂家名称
        /// </summary>
        public string ManufacturerName { get; set; }

        /// <summary>
        /// 盘点状态
        /// </summary>
        public bool CheckStatus { get; set; }

        /// <summary>
        /// lot.号
        /// </summary>
        public string LotNum { get; set; }

        /// <summary>
        /// 盘点数量
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 盘点时间
        /// </summary>
        public DateTime CheckTime { get; set; }

        /// <summary>
        /// 编号 (自增)
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
