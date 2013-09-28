using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 产品表
    /// </summary>
    public class Product
    {
        /// <summary>
        /// 检验状态：未检/已检/冻结
        /// </summary>
        public int  CheckStatu { get; set; }

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
        /// lot号
        /// </summary>
        public string LotNum { get; set; }

    
        /// <summary>
        /// 数量
        /// </summary>
        public int Number { get; set; }    

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime ProductTime { get; set; }

        /// <summary>
        /// 检验时间7
        /// </summary>
        public DateTime CheckTime
        {
            get;
            set;
        }

        /// <summary>
        /// 料号8
        /// </summary>
        public string MaterialNo { get; set; }

        /// <summary>
        /// 单位数量9
        /// </summary>
        public int UnitNum { get; set; }

        public int Id { get; set; }

        public string Reserve { get; set; }



        public virtual Manufacturer Manu { get; set; }

        public virtual StorageLocation StorageL { get; set; }

        public virtual GoodsDetail Goods { get; set; }



    }
}
