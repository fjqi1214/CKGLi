using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using BLL;
using DAL;
using Interface;
using DAL.EntityMap;
using System.Data.Entity;
using Utility;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
namespace CKGL
{
    public partial class MangeForm : Form
    {
        UserService userS;
        Form parentForm;
        Form register;
        Form RePwd;
        ProductManger products;
        public MangeForm(UserService us, Form parentForm)
        {

            InitializeComponent();
            Database.SetInitializer<CKGLContext>(new ProductInitializer());
            Database.SetInitializer<CKGLContext>(new ImportStorageInitializer());
            products = new ProductManger(this.bS2, this.dgvProd, this.bN, txtPageNum, txtTotalPageNum);
            this.userS = us;
            this.parentForm = parentForm;
            this.bN.Enabled = true; ;
          
        }

        private void cExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MangeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.parentForm.Show();
        }

        private void mangeTab_Selected(object sender, TabControlEventArgs e)
        {
            //MessageBox.Show(e.TabPageIndex.ToString());


            switch (e.TabPageIndex)
            {
                case 0:

                    break;
                case 1:
                    products.ChangeTab();

                    break;
                case 2:

                    break;

                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
            }



        }


        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            switch (mangeTab.SelectedIndex)
            {
                case 0:
                    //bS1.DataSource = SplitePager.MoveNextPage<StorageLocation>();
                    //dgvSl.DataSource = bS1;
                    break;
                case 1:

                    products.MoveNextPage();

                    break;
                case 2:

                    break;

                case 3:


                    break;
                case 4:


                    break;
                case 5:


                    break;
            }

        }


        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            switch (mangeTab.SelectedIndex)
            {
                case 0:
                    //bS1.DataSource = SplitePager.MoveNextPage<StorageLocation>();
                    //dgvSl.DataSource = bS1;
                    break;
                case 1:

                    products.MoveFirstPage();

                    break;
                case 2:

                    break;

                case 3:


                    break;
                case 4:


                    break;
                case 5:


                    break;
            }
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            switch (mangeTab.SelectedIndex)
            {
                case 0:
                    //bS1.DataSource = SplitePager.MoveNextPage<StorageLocation>();
                    //dgvSl.DataSource = bS1;
                    break;
                case 1:

                    products.MovePreviousPage();

                    break;
                case 2:

                    break;

                case 3:


                    break;
                case 4:


                    break;
                case 5:


                    break;
            }
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            switch (mangeTab.SelectedIndex)
            {
                case 0:
                    break;
                case 1:

                    products.MoveLastPage();

                    break;
                case 2:

                    break;

                case 3:


                    break;
                case 4:


                    break;
                case 5:


                    break;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (string.IsNullOrEmpty(txtGoNum.Text))
            {
                return;
            }
            var b = UtilityTool.ConvertToInt(txtGoNum.Text, out num);
            if (b)
            {
                switch (mangeTab.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1:

                        products.MoveToPage(num);

                        break;
                    case 2:

                        break;

                    case 3:


                        break;
                    case 4:


                        break;
                    case 5:


                        break;
                }
            }
        }

        private void cbPageItemNum_TextChanged(object sender, EventArgs e)
        {
            int count = 0;
            switch (this.mangeTab.SelectedIndex)
            {
                case 0:

                    break;
                case 1:
                    products.PageSizeChange(Convert.ToInt32(cbPageSize.Text));

                    break;
                case 2:

                    break;

                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
            }

            //txtCurPageNum.Text = SplitePager.Pager.FormatPageNum.ToString();
            //txtTotalPageNum.Text = SplitePager.Pager.FormatTotalPageNum.ToString();
        }


        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            switch (mangeTab.SelectedIndex)
            {
                case 0:

                    break;
                case 1:


                    break;
                case 2:

                    break;

                case 3:


                    break;
                case 4:


                    break;
                case 5:


                    break;
            }
        }



        /// <summary>
        /// 进入库位管理标签页
        /// </summary>
        private void SetStorageLocationTab()
        {




        }

    
        private void 注册用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            register = new Register();
            register.Show();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RePwd = new RePasswd();
            RePwd.Show();
        }





        private void dgvProd_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            switch (e.ColumnIndex)
            {
                case 6:
                case 7:
                    DateTime time;
                    string str = e.FormattedValue.ToString();
                    if (!DateTime.TryParse(str, out time))
                    {
                        e.Cancel = true;
                        this.dgvProd.Rows[e.RowIndex].ErrorText = "数据格式错误";
                    }
                    else
                    {
                        e.Cancel = false;
                        this.dgvProd.Rows[e.RowIndex].ErrorText = "";
                    }
                    break;
                case 5:
                case 9:
                    int i;
                    string str2 = e.FormattedValue.ToString();
                    if (!int.TryParse(str2, out i))
                    {
                        e.Cancel = true;
                        this.dgvProd.Rows[e.RowIndex].ErrorText = "数据格式错误";
                    }
                    else
                    {
                        e.Cancel = false;
                        this.dgvProd.Rows[e.RowIndex].ErrorText = "";
                    }

                    break;

            }

        }

        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            
        }


        private void btnProductReset_Click(object sender, EventArgs e)
        {

            txtSearchProductName.Text = "";
            products.ChangeTab();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch1_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {

            this.products.SearchProduct = txtSearchProductName.Text;
            this.products.SearchCheckTime = txtSearchCheckTime.Text;
            products.ChangeTab();
        }



        private void productMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var rows = dgvProd.SelectedRows;

            MessageBox.Show(rows[0].Index.ToString());

        }










    }
}
