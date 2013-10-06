using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interface;
using Model;
using DAL;

namespace BLL
{
    public class UserService
    {
        private CKGLContext db = new CKGLContext();
        private SqlHelp<User,string> sqlHelp;
        public UserService()
        {
            sqlHelp=new SqlHelp<User, string>(db);
            this.LoginValidate = (IUserLogin)sqlHelp;
            this.Validate=(IValitdate<User>)sqlHelp;
        }

        public IUserLogin LoginValidate { get; set; }
        public IValitdate<User> Validate{get;set;}

        public User User { get; set; }
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="pwd">密码</param>
        /// <returns>成功返回对象 否则返回null</returns>
        public bool Login(string name, string pwd)
        {
           
            var user = LoginValidate.GetUser(name, pwd);

            if (user == null)
            {
                return false;
            }
            this.User = user;
            return true;

            
        }
        public bool UniqueValidate(string name)
        {
            return  Validate.ValitedateKeyUnique(i => i.UserName == name);
        }

        public int Register(string name, string pwd, int auth)
        {
            User user = new User { UserName = name, Pwd = pwd, Auth = auth };
            List<User> users=new List<Model.User>();
            users.Add(user);
            return sqlHelp.Update(users);
        }

        public int UpdateUser(User user)
        {
            List<User> users=new List<Model.User>();
            users.Add(user);
            return sqlHelp.Update(users);
        }

    }
}
