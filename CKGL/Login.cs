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
using Interface;

namespace CKGL
{
    public partial class Login : Form
    {
       
        MangeForm manageForm;
        public Login()
        {
            InitializeComponent();
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           ErrorHandle.HandleError(() =>
           {
               if (string.IsNullOrEmpty(txtName.Text))
               {
                   labTip.Text = "用户名不能为空！";
                   return;
               }
               if (string.IsNullOrEmpty(txtPwd.Text))
               {
                   labTip.Text = "密码不能为空！";
                   return;
               }
               UserService us = new UserService();

               var name = txtName.Text;
               var pwd = txtPwd.Text;
               bool result = us.Login(name, pwd);

               if (!result)
               {
                   //用户登录失败
                   labTip.Text = "登录失败！用户名或密码错误！";
               }
               else
               {
                   //用户登录成功
                   manageForm = new MangeForm(us, this);
                   manageForm.Show();
                   this.Hide();
               }
           }, "Debug.data");
           
        }

        private void ShowPrompt(string message)
        {
            MessageBox.Show(message, "提示");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
      
    }
}
