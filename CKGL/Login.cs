using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using Model;
using BLL;
using System.Linq.Expressions;

namespace CKGL
{
    public partial class Login : Form
    {
       
        MangeForm manageForm;

        private CKGLContext db=new CKGLContext();
        public Login()
        {
            InitializeComponent();
            CKGLContext db = new CKGLContext();
            //db.Users.Add(new User { Auth = AuthLevel.Common, UserName = "fdff" });

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserService us = new UserService();
            //us.UserValidate = new CKGLDAL<User>(this.db);
            var name = txtName.Text;
            var pwd = txtPwd.Text;
            bool result = us.Login(name, pwd);

            if (!result)
            {
                //用户登录失败
                ShowPrompt("用户名或密码错误！");
            }
            else
            { 
                //用户登录成功
                manageForm = new MangeForm(us, this);
                manageForm.Show();
                this.Hide();
                
            }
        }

        private void ShowPrompt(string message)
        {
            MessageBox.Show(message, "提示");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StorageLocation s = new StorageLocation { ProductName = "1", LocationName = "位置1", ManufacturerName = "厂家1" };
            db.StorageLocations.Add(s);
            db.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //var list = db.Set<Product>().Where(i => i.ProductName == "1").Where(i=>i.CheckTime==DateTime.Now).Where(i=>i.LotNum=="1").OrderBy(i=>i.Id).Skip(0).Take(10).ToList();
            var query = db.Set<Product>();
             int k=1;
            List<Expression<Func<Product,bool>>> list=new List<Expression<Func<Product,bool>>>{i=>i.CheckTime==DateTime.Now,i=>i.ProductName=="产品1"}; 
            foreach(var i in list)
            {
                query.Where(i);
            }
            var item= query.OrderBy(i => i.Id).Skip(0).Take(10).ToList();
           
        }
    }
}
