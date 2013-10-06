using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace CKGL
{
    public partial class RePasswd : Form
    {
        UserService service;
        public RePasswd(UserService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            ErrorHandle.HandleError(() =>
              {
                  if (string.IsNullOrEmpty(txtOldPwd.Text))
                  {
                      labTip.Text = "原始密码不能为空！";
                      return;
                  }
                  if(txtOldPwd.Text!=service.User.Pwd)
                  {
                      labTip.Text = "原始密码错误！";
                      return;
                  }
                  if (string.IsNullOrEmpty(txtNewPwd.Text))
                  {
                      labTip.Text = "新密码不能为空！";
                      return;
                  }
                  if (string.IsNullOrEmpty(txtPwd2.Text))
                  {
                      labTip.Text = "确认密码不能为空！";
                      return;
                  }
                  if (txtPwd2.Text != txtNewPwd.Text)
                  {
                      labTip.Text = "两次输入密码不一致！";
                      return;
                  }
                
                  service.User.Pwd = txtNewPwd.Text;
                  int count = service.UpdateUser(service.User);
                  if (count == 1)
                  {
                      MessageBox.Show("修改成功！");
                  }
                  else
                  {
                      MessageBox.Show("修改失败！");
                  }
                     
              }, "Debug.data");

        }




    }
}
