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
        public string pwd { get; set; }
        public AuthLevel Auth { get; set; }
        
    }


    public enum AuthLevel
    { 
        Common,
        privilege,
    }
}
