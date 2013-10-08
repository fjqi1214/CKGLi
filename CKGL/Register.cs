using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Model;

namespace CKGL
{
    public partial class Register : Form
    {
        private UserService service;
        public Register(UserService userService)
        {
            InitializeComponent();
            this.service = userService;

        }

        private void btnRegOk_Click(object sender, EventArgs e)
        {
            ErrorHandle.HandleError(() =>
            {
                if (string.IsNullOrEmpty(txtRegUserName.Text))
                {
                    labTip.Text = "用户名不能为空！";
                    return;
                }
                if (string.IsNullOrEmpty(txtRegPwd.Text))
                {
                    labTip.Text = "密码不能为空！";
                    return;
                }
                if (string.IsNullOrEmpty(txtRegPwd2.Text))
                {
                    labTip.Text = "确认密码不能为空！";
                    return;
                }
                if (txtRegPwd.Text != txtRegPwd2.Text)
                {
                    labTip.Text = "两次输入密码不一致！";
                    return;
                }
                bool r = this.service.UniqueValidate(txtRegUserName.Text);
                if (!r)
                {
                    labTip.Text = "用户名已存在！";
                    return;
                }
                int auth = 0;
                if (cbAuth.Text == "普通成员") auth = 1;
                int result = service.Register(txtRegUserName.Text, txtRegPwd.Text, auth);
                if (result == 1)
                {
                    MessageBox.Show("注册成功！", "提示！");
                }
                else
                {
                    MessageBox.Show("注册失败！", "提示！");
                }

            }, "Debug.data");

        }


        private void btnRegRetset_Click(object sender, EventArgs e)
        {
            txtRegUserName.Text = string.Empty;
            txtRegPwd.Text = string.Empty;
            txtRegPwd2.Text = string.Empty;
            labTip.Text = string.Empty;
            cbAuth.SelectedIndex = 0;

        }



        private void txtRegUserName_Leave(object sender, EventArgs e)
        {
            ErrorHandle.HandleError(() =>
            {
                if (!string.IsNullOrEmpty(txtRegUserName.Text))
                {
                    bool r = this.service.UniqueValidate(txtRegUserName.Text);
                    if (!r)
                    {
                        labTip.Text = "用户名已存在！";
                    }
                    else
                    {
                        labTip.Text = string.Empty;
                    }
                }
            }, "Debug.data");

        }




    }
}
