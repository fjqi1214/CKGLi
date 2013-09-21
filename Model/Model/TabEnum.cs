using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public enum TabEnum
    {
        /// <summary>
        /// 库位管理标签页
        /// </summary>
        StorageLocationTab = 0,

        /// <summary>
        /// 产品标签
        /// </summary>
        ProductTab = 1,

        /// <summary>
        /// 入库管理标签页
        /// </summary>
        ImportStorageTab = 2,

        /// <summary>
        /// 出库管理标签页
        /// </summary>
        ExportStorageTab = 3,


        /// <summary>
        /// 盘点管理标签页
        /// </summary>
        CheckRecordTab = 4,

        /// <summary>
        /// 厂家管理标签页
        /// </summary>
        ManufacturerTab = 5,

    }
}
