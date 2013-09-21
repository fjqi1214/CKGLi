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
        /// 检验状态0
        /// </summary>
        public bool CheckStatu { get; set; }

        /// <summary>
        /// 厂家1
        /// </summary>
        public string ManufacturerName { get; set; }

        /// <summary>
        /// 库位2
        /// </summary>
        public string LocationName { get; set; }

        /// <summary>
        /// 品名3
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// lot号4
        /// </summary>
        public string LotNum { get; set; }

    

        /// <summary>
        /// 数量5
        /// </summary>
        public int Number { get; set; }    

        /// <summary>
        /// 生产日期6
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

        public virtual Manufacturer Manu { get; set; }

        public virtual StorageLocation StorageL { get; set; }




    }
}
