using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interface;
using Model;

namespace BLL
{
    public class UserService
    {
        
        public IUserLogin UserValidate { get; set; }

        public User User { get; set; }
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="pwd">密码</param>
        /// <returns>成功返回对象 否则返回null</returns>
        public bool Login(string name, string pwd)
        {
            //用户输入的过滤
            //var user = UserValidate.GetUser(name, pwd);

            //if (user == null)
            //{
            //    return false;
            //}
            //this.User = user;
            return true;

            
        }
    }
}
