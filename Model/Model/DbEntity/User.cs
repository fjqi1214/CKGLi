using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class User
    {
        public string UserName { get; set; }
        public string Pwd { get; set; }
        /// <summary>
        /// 0 特权,1普通
        /// </summary>
        public int Auth { get; set; }
        
    }


    public enum AuthLevel
    { 
        /// <summary>
        /// 普通用户
        /// </summary>
        Common,

        /// <summary>
        /// 特权用户
        /// </summary>
        Privilege,
    }
}
