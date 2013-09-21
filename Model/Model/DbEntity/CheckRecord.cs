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


        public int Id { get; set; }
        /// <summary>
        /// 库位
        /// </summary>
        public string LocationName { get; set; }

        /// <summary>
        /// 品名
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 盘点状态
        /// </summary>
        public bool CheckStatus { get; set; }

        /// <summary>
        /// lot.号
        /// </summary>
        public string LotNum { get; set; }

        /// <summary>
        /// 单位数量
        /// </summary>
        public string UnitNumber { get; set; }



    }
}
