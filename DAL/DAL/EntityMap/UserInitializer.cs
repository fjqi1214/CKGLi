using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Model;

namespace DAL
{
    public class UserInitializer 
        : DropCreateDatabaseIfModelChanges<CKGLContext>
    {
        protected override void Seed(CKGLContext context)
        {
            var uses = new List<User>{
                new User{ UserName="admin", Auth= 0, Pwd="admin"},
                new User{ UserName="zhangsan", Auth= 1, Pwd="666666"},
            };
            uses.ForEach(i => context.Users.Add(i));
            context.SaveChanges();
        }
    }
}
