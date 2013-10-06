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
using DAL;
using System.Data.Entity;
using Utility;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using CKGL;
namespace CKGL
{
    public partial class MangeForm : Form
    {
        UserService userS;
        Form parentForm;
        Form register;
        Form RePwd;
        ProductManger products;
        StorageLocationManage locations;
        ImportStorageManage imports;
        ExportStorageManage exports;
        CheckRecordManage checkRecords;
        ManufacturerManage manus;
        GoodsManage goods;

        public MangeForm(UserService us, Form parentForm)
        {

            InitializeComponent();

            DataTable checkState = new DataTable();
            checkState.Columns.Add("Value");
            checkState.Columns.Add("Name");
            DataRow checkStateDr;
            checkStateDr = checkState.NewRow();
            checkStateDr[0] = "未检";
            checkStateDr[1] = "未检";
            checkState.Rows.Add(checkStateDr);
            checkStateDr = checkState.NewRow();
            checkStateDr[0] = "已检";
            checkStateDr[1] = "已检";
            checkState.Rows.Add(checkStateDr);
            checkStateDr = checkState.NewRow();
            checkStateDr[0] = "冻结";
            checkStateDr[1] = "冻结";
            checkState.Rows.Add(checkStateDr);
            var col1 = ((DataGridViewComboBoxColumn)this.dgvProd.Columns[0]);
            col1.DataSource = checkState;
            col1.DisplayMember = "Name";
            col1.ValueMember = "Value";


            locations = new StorageLocationManage(this.bS1, this.dgvSl, this.bN, txtPageNum, txtTotalPageNum);
            products = new ProductManger(this.bS2, this.dgvProd, this.bN, txtPageNum, txtTotalPageNum);
            imports = new ImportStorageManage(this.bS3, this.dgvImport, this.bN, txtPageNum, txtTotalPageNum);
            exports = new ExportStorageManage(this.bS4, this.dgvExport, this.bN, txtPageNum, txtTotalPageNum);
            checkRecords = new CheckRecordManage(this.bS5, this.dgvCheck, this.bN, txtPageNum, txtTotalPageNum);
            manus = new ManufacturerManage(this.bS6, this.dgvManu, this.bN, txtPageNum, txtTotalPageNum);
            goods = new GoodsManage(null, null, this.bN, txtPageNum, txtTotalPageNum);
            this.userS = us;
            this.parentForm = parentForm;
            this.bN.Enabled = true; ;
          

           ErrorHandle.HandleError(() =>
           {
               locations.ChangeTab();
           }, "Debug.data");

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
            ErrorHandle.HandleError(() =>
            {
                switch (e.TabPageIndex)
                {
                    case 0:
                        locations.ChangeTab();
                        break;
                    case 1:
                        products.ChangeTab();
                        break;
                    case 2:
                        imports.ChangeTab();
                        break;
                    case 3:
                        exports.ChangeTab();
                        break;
                    case 4:
                        checkRecords.ChangeTab();
                        break;
                    case 5:
                        manus.ChangeTab();
                        break;
                }
            }, "Debug.data");
        }


        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            ErrorHandle.HandleError(() =>
           {
               switch (mangeTab.SelectedIndex)
               {
                   case 0:
                       locations.MoveNextPage();
                       break;
                   case 1:
                       products.MoveNextPage();
                       break;
                   case 2:
                       imports.MoveNextPage();
                       break;
                   case 3:
                       exports.MoveNextPage();
                       break;
                   case 4:
                       checkRecords.MoveNextPage();
                       break;
                   case 5:
                       manus.MoveNextPage();
                       break;
               }
           }, "Debug.data");
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            ErrorHandle.HandleError(() =>
          {
              switch (mangeTab.SelectedIndex)
              {
                  case 0:
                      locations.MoveFirstPage();
                      break;
                  case 1:
                      products.MoveFirstPage();
                      break;
                  case 2:
                      imports.MoveFirstPage();
                      break;
                  case 3:
                      exports.MoveFirstPage();
                      break;
                  case 4:
                      checkRecords.MoveFirstPage();
                      break;
                  case 5:
                      manus.MoveFirstPage();
                      break;
              }

          }, "Debug.data");

        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            ErrorHandle.HandleError(() =>
           {
               
               switch (mangeTab.SelectedIndex)
               {
                   case 0:
                       locations.MovePreviousPage();
                       break;
                   case 1:
                       products.MovePreviousPage();
                       break;
                   case 2:
                       imports.MovePreviousPage();
                       break;
                   case 3:
                       exports.MovePreviousPage();
                       break;
                   case 4:
                       checkRecords.MovePreviousPage();
                       break;
                   case 5:
                       manus.MovePreviousPage();
                       break;
               }
           }, "Debug.data");

        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {

            ErrorHandle.HandleError(() =>
            {
                switch (mangeTab.SelectedIndex)
                {
                    case 0:
                        locations.MoveLastPage();
                        break;
                    case 1:
                        products.MoveLastPage();
                        break;
                    case 2:
                        imports.MoveLastPage();
                        break;
                    case 3:
                        exports.MoveLastPage();
                        break;
                    case 4:
                        checkRecords.MoveLastPage();
                        break;
                    case 5:
                        manus.MoveLastPage();
                        break;
                }
            }, "Debug.data");

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            ErrorHandle.HandleError(() =>
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
                            locations.MoveToPage(num);
                            break;
                        case 1:
                            products.MoveToPage(num);
                            break;
                        case 2:
                            imports.MoveToPage(num);
                            break;
                        case 3:
                            exports.MoveToPage(num);
                            break;
                        case 4:
                            checkRecords.MoveToPage(num);
                            break;
                        case 5:
                            manus.MoveToPage(num);
                            break;
                    }
                }
            }, "Debug.data");

        }

        private void cbPageItemNum_TextChanged(object sender, EventArgs e)
        {
            ErrorHandle.HandleError(() =>
            {
                switch (this.mangeTab.SelectedIndex)
                {
                    case 0:
                        locations.PageSizeChange(Convert.ToInt32(cbPageSize.Text));
                        break;
                    case 1:
                        products.PageSizeChange(Convert.ToInt32(cbPageSize.Text));
                        break;
                    case 2:
                        imports.PageSizeChange(Convert.ToInt32(cbPageSize.Text));
                        break;
                    case 3:
                        exports.PageSizeChange(Convert.ToInt32(cbPageSize.Text));
                        break;
                    case 4:
                        checkRecords.PageSizeChange(Convert.ToInt32(cbPageSize.Text));
                        break;
                    case 5:
                        manus.PageSizeChange(Convert.ToInt32(cbPageSize.Text));
                        break;
                }
            }, "Debug.data");

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


        private void dgvSl_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ErrorHandle.HandleError(() =>
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        if (this.dgvSl.Rows[e.RowIndex].Cells[0].Value != null
                            && string.IsNullOrEmpty(this.dgvSl.Rows[e.RowIndex].ErrorText))
                            e.Cancel = true;
                        break;
                }
            }, "Debug.data");
        }


        private void dgvSl_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            ErrorHandle.HandleError(() =>
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            e.Cancel = true;
                            this.dgvSl.Rows[e.RowIndex].ErrorText = "不能为空！";
                        }
                        else
                        {
                            e.Cancel = false;

                            Regex regex = new Regex(@"^[A-T]-\d+-\d+$");
                            var result = regex.IsMatch(e.FormattedValue.ToString());
                            if (!result)
                            {
                                e.Cancel = true;
                                this.dgvSl.Rows[e.RowIndex].ErrorText = "格式必须如 A-1-1";
                            }
                            else
                            {
                                e.Cancel = false;
                                var str = e.FormattedValue.ToString();
                                this.dgvSl.Rows[e.RowIndex].Cells[3].Value = str.Substring(0, 1);
                                this.dgvSl.Rows[e.RowIndex].Cells[0].Value = str;
                            }
                        }
                        break;
                    case 3:
                        if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            e.Cancel = true;
                            this.dgvSl.Rows[e.RowIndex].ErrorText = "不能为空！";
                        }
                        else
                        {
                            e.Cancel = false;
                            this.dgvSl.Rows[e.RowIndex].ErrorText = "";
                            Regex regex = new Regex(@"^[A-T]$");
                            var result = regex.IsMatch(e.FormattedValue.ToString());
                            if (!result)
                            {
                                e.Cancel = true;
                                this.dgvSl.Rows[e.RowIndex].ErrorText = "只能输入A-T";
                            }
                            else
                            {
                                this.dgvSl.Rows[e.RowIndex].ErrorText = "";
                                e.Cancel = false;
                            }
                        }
                        break;
                }
            }, "Debug.data");

        }

        private void dgvSl_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ErrorHandle.HandleError(() =>
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 0)
                    {
                        var cellVal = dgvSl.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        if (cellVal != null)
                        {
                            var str = cellVal.ToString();
                            if (!locations.ValidateUnique(i => i.LocationName == str))
                            {
                                this.dgvSl.Rows[e.RowIndex].ErrorText = "主键已存在不能添加 强制操作会失败！";
                            }
                            else
                            {
                                this.dgvSl.Rows[e.RowIndex].ErrorText = "";
                            }
                        }

                    }
                }
            }, "Debug.data");
        }

        private void dgvProd_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            ErrorHandle.HandleError(() =>
           {
               string str = e.FormattedValue.ToString();
               switch (e.ColumnIndex)
               {
                   case 1:
                       if (!string.IsNullOrEmpty(str))
                       {

                           if (manus.ValidateUnique(t => t.ManufacturerName == str))
                           {
                               e.Cancel = true;
                               this.dgvProd.Rows[e.RowIndex].ErrorText = "厂家必须在厂家表中存在！";

                           }
                           else
                           {
                               e.Cancel = false;
                               this.dgvProd.Rows[e.RowIndex].ErrorText = "";
                           }
                       }
                       break;
                   case 2:
                       if (!string.IsNullOrEmpty(e.FormattedValue.ToString()))
                       {
                           if (locations.ValidateUnique(t => t.LocationName == str))
                           {
                               e.Cancel = true;
                               this.dgvProd.Rows[e.RowIndex].ErrorText = "库位必须在库位表中存在！";

                           }
                           else
                           {
                               e.Cancel = false;
                               this.dgvProd.Rows[e.RowIndex].ErrorText = "";
                           }
                       }
                       break;
                   case 3:
                       if (!string.IsNullOrEmpty(str))
                       {
                           if (goods.ValidateUnique(t => t.GoodsName == str))
                           {
                               e.Cancel = true;
                               this.dgvProd.Rows[e.RowIndex].ErrorText = "产品名必须在产品表中存在！";

                           }
                           else
                           {
                               e.Cancel = false;
                               this.dgvProd.Rows[e.RowIndex].ErrorText = "";
                           }
                       }
                       break;

                   case 6:
                   case 7:
                       DateTime time;

                       if (!DateTime.TryParse(str, out time))
                       {
                           e.Cancel = true;
                           this.dgvProd.Rows[e.RowIndex].ErrorText = "数据格式错误！";
                       }
                       else
                       {
                           e.Cancel = false;
                           this.dgvProd.Rows[e.RowIndex].ErrorText = "";
                       }
                       break;
                   case 5:
                   case 9:

                       int i = 0;
                       if (!int.TryParse(str, out i))
                       {
                           e.Cancel = true;
                           this.dgvProd.Rows[e.RowIndex].ErrorText = "数据格式错误！";
                       }
                       else
                       {
                           e.Cancel = false;
                           this.dgvProd.Rows[e.RowIndex].ErrorText = "";
                       }
                       break;
               }
           }, "Debug.data");

        }


        private void dgvImport_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            ErrorHandle.HandleError(() =>
            {
                string str = e.FormattedValue.ToString();
                switch (e.ColumnIndex)
                {
                    case 0:
                        if (!string.IsNullOrEmpty(str))
                        {

                            if (manus.ValidateUnique(t => t.ManufacturerName == str))
                            {
                                e.Cancel = true;
                                this.dgvImport.Rows[e.RowIndex].ErrorText = "厂家必须在厂家表中存在！";

                            }
                            else
                            {
                                e.Cancel = false;
                                this.dgvImport.Rows[e.RowIndex].ErrorText = "";
                            }
                        }

                        break;
                    case 1:
                        if (!string.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            if (locations.ValidateUnique(t => t.LocationName == str))
                            {
                                e.Cancel = true;
                                this.dgvImport.Rows[e.RowIndex].ErrorText = "库位必须在库位表中存在！";

                            }
                            else
                            {
                                e.Cancel = false;
                                this.dgvImport.Rows[e.RowIndex].ErrorText = "";
                            }
                        }
                        break;
                    case 2:
                        if (!string.IsNullOrEmpty(str))
                        {
                            if (goods.ValidateUnique(t => t.GoodsName == str))
                            {
                                e.Cancel = true;
                                this.dgvImport.Rows[e.RowIndex].ErrorText = "产品名必须在产品表中存在！";

                            }
                            else
                            {
                                e.Cancel = false;
                                this.dgvImport.Rows[e.RowIndex].ErrorText = "";
                            }
                        }
                        break;

                    case 4:
                    case 5:
                        DateTime time;
                        if (!DateTime.TryParse(str, out time))
                        {
                            e.Cancel = true;
                            this.dgvImport.Rows[e.RowIndex].ErrorText = "数据格式错误！";
                        }
                        else
                        {
                            e.Cancel = false;
                            this.dgvImport.Rows[e.RowIndex].ErrorText = "";
                        }
                        break;
                    case 6:
                    case 8:
                        int i = 0;
                        if (!int.TryParse(str, out i))
                        {
                            e.Cancel = true;
                            this.dgvImport.Rows[e.RowIndex].ErrorText = "数据格式错误！";
                        }
                        else
                        {
                            e.Cancel = false;
                            this.dgvImport.Rows[e.RowIndex].ErrorText = "";
                        }
                        break;
                }
            }, "Debug.data");
        }

        private void dgvExport_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            ErrorHandle.HandleError(() =>
            {
                string str = e.FormattedValue.ToString();
                switch (e.ColumnIndex)
                {
                    case 0:
                        if (!string.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            if (locations.ValidateUnique(t => t.LocationName == str))
                            {
                                e.Cancel = true;
                                this.dgvExport.Rows[e.RowIndex].ErrorText = "库位必须在库位表中存在！";

                            }
                            else
                            {
                                e.Cancel = false;
                                this.dgvExport.Rows[e.RowIndex].ErrorText = "";
                            }
                        }

                        break;
                    case 1:
                        if (!string.IsNullOrEmpty(str))
                        {
                            if (goods.ValidateUnique(t => t.GoodsName == str))
                            {
                                e.Cancel = true;
                                this.dgvExport.Rows[e.RowIndex].ErrorText = "产品名必须在产品表中存在！";

                            }
                            else
                            {
                                e.Cancel = false;
                                this.dgvExport.Rows[e.RowIndex].ErrorText = "";
                            }
                        }

                        break;
                    case 2:
                        if (!string.IsNullOrEmpty(str))
                        {

                            if (manus.ValidateUnique(t => t.ManufacturerName == str))
                            {
                                e.Cancel = true;
                                this.dgvExport.Rows[e.RowIndex].ErrorText = "厂家必须在厂家表中存在！";

                            }
                            else
                            {
                                e.Cancel = false;
                                this.dgvExport.Rows[e.RowIndex].ErrorText = "";
                            }
                        }

                        break;

                    case 4:

                        DateTime time;
                        if (!DateTime.TryParse(str, out time))
                        {
                            e.Cancel = true;
                            this.dgvExport.Rows[e.RowIndex].ErrorText = "数据格式错误！";
                        }
                        else
                        {
                            e.Cancel = false;
                            this.dgvExport.Rows[e.RowIndex].ErrorText = "";
                        }
                        break;
                    case 5:
                    case 6:
                        int i = 0;
                        if (!int.TryParse(str, out i))
                        {
                            e.Cancel = true;
                            this.dgvExport.Rows[e.RowIndex].ErrorText = "数据格式错误！";
                        }
                        else
                        {
                            e.Cancel = false;
                            this.dgvExport.Rows[e.RowIndex].ErrorText = "";
                        }
                        break;
                }
            }, "Debug.data");

        }

        private void dgvCheck_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            ErrorHandle.HandleError(() =>
            {
                string str = e.FormattedValue.ToString();
                switch (e.ColumnIndex)
                {
                    case 0:
                        if (!string.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            if (locations.ValidateUnique(t => t.LocationName == str))
                            {
                                e.Cancel = true;
                                this.dgvCheck.Rows[e.RowIndex].ErrorText = "库位必须在库位表中存在！";

                            }
                            else
                            {
                                e.Cancel = false;
                                this.dgvCheck.Rows[e.RowIndex].ErrorText = "";
                            }
                        }

                        break;
                    case 1:
                        if (!string.IsNullOrEmpty(str))
                        {
                            if (goods.ValidateUnique(t => t.GoodsName == str))
                            {
                                e.Cancel = true;
                                this.dgvCheck.Rows[e.RowIndex].ErrorText = "产品名必须在产品表中存在！";

                            }
                            else
                            {
                                e.Cancel = false;
                                this.dgvCheck.Rows[e.RowIndex].ErrorText = "";
                            }
                        }

                        break;
                    case 2:
                        if (!string.IsNullOrEmpty(str))
                        {

                            if (manus.ValidateUnique(t => t.ManufacturerName == str))
                            {
                                e.Cancel = true;
                                this.dgvCheck.Rows[e.RowIndex].ErrorText = "厂家必须在厂家表中存在！";

                            }
                            else
                            {
                                e.Cancel = false;
                                this.dgvCheck.Rows[e.RowIndex].ErrorText = "";
                            }
                        }

                        break;
                    //有一列盘点状态
                    case 5:
                        int i = 0;
                        if (!int.TryParse(str, out i))
                        {
                            e.Cancel = true;
                            this.dgvCheck.Rows[e.RowIndex].ErrorText = "数据格式错误！";
                        }
                        else
                        {
                            e.Cancel = false;
                            this.dgvCheck.Rows[e.RowIndex].ErrorText = "";
                        }
                        break;

                    case 6:
                        DateTime time;
                        if (!DateTime.TryParse(str, out time))
                        {
                            e.Cancel = true;
                            this.dgvCheck.Rows[e.RowIndex].ErrorText = "数据格式错误！";
                        }
                        else
                        {
                            e.Cancel = false;
                            this.dgvCheck.Rows[e.RowIndex].ErrorText = "";
                        }
                        break;
                }
            }, "Debug.data");
        }


        private void dgvManu_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ErrorHandle.HandleError(() =>
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        if (this.dgvManu.Rows[e.RowIndex].Cells[0].Value != null
                            && string.IsNullOrEmpty(this.dgvManu.Rows[e.RowIndex].ErrorText))
                            e.Cancel = true;
                        break;
                }
            }, "Debug.data");

        }


        private void dgvManu_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ErrorHandle.HandleError(() =>
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 0)
                    {
                        var cellValue = this.dgvManu.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        if (cellValue != null)
                        {
                            var str = cellValue.ToString();
                            if (!manus.ValidateUnique(i => i.ManufacturerName == str))
                            {
                                this.dgvManu.Rows[e.RowIndex].ErrorText = "主键已存在不能添加 强制操作会失败！";

                            }
                            else
                            {

                                this.dgvManu.Rows[e.RowIndex].ErrorText = "";
                            }
                        }
                    }
                }
            }, "Debug.data");

        }

        private void dgvManu_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            ErrorHandle.HandleError(() =>
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            e.Cancel = true;
                            this.dgvManu.Rows[e.RowIndex].ErrorText = "不能为空！";
                        }
                        else
                        {
                            e.Cancel = false;
                        }
                        break;
                }
            }, "Debug.data");

        }


        private void btnDel_Click(object sender, EventArgs e)
        {
            ErrorHandle.HandleError(() =>
           {
               switch (mangeTab.SelectedIndex)
               {
                   case 0:
                       locations.Delete();
                       break;
                   case 1:
                       products.Delete();
                       break;
                   case 2:
                       imports.Delete();
                       break;
                   case 3:
                       exports.Delete();
                       break;
                   case 4:
                       checkRecords.Delete();
                       break;
                   case 5:
                       manus.Delete();
                       break;
               }
           }, "Debug.data");
        }

        #region 保存修改点击事件

        private void btnSLSave_Click(object sender, EventArgs e)
        {
            ErrorHandle.HandleError(() =>
            {
                locations.SaveChange();
            }, "Debug.data");

        }

        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            ErrorHandle.HandleError(() =>
           {
               products.SaveChange();
           }, "Debug.data");

        }



        private void btnImportSave_Click(object sender, EventArgs e)
        {
            ErrorHandle.HandleError(() =>
            {
                imports.SaveChange();
            }, "Debug.data");

        }

        private void btnExportSave_Click(object sender, EventArgs e)
        {
            ErrorHandle.HandleError(() =>
            {
                exports.SaveChange();
            }, "Debug.data");

        }

        private void btnCheckSave_Click(object sender, EventArgs e)
        {
            ErrorHandle.HandleError(() =>
            {
                checkRecords.SaveChange();
            }, "Debug.data");

        }

        private void ManufacturerSave_Click(object sender, EventArgs e)
        {
            ErrorHandle.HandleError(() =>
            {
                manus.SaveChange();
            }, "Debug.data");

        }

        #endregion

        #region 所有搜索按钮事件

        private void btnSearch1_Click(object sender, EventArgs e)
        {
            ErrorHandle.HandleError(() =>
            {
                this.locations.SearchLocationName = this.txtLocationName.Text;
                this.locations.SearchUse = this.cbUse.Text;
                locations.ChangeTab();
            }, "Debug.data");

        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            ErrorHandle.HandleError(() =>
            {
                this.products.SearchProduct = txtSearchProductName.Text;
                this.products.SearchCheckTime = txtSearchCheckTime.Text;
                products.ChangeTab();
            }, "Debug.data");

        }


        private void btnSearch3_Click(object sender, EventArgs e)
        {
            ErrorHandle.HandleError(() =>
            {
                this.imports.SearchImportTime = txtImportTime.Text;
                this.imports.SearchProductName = txtImProductName.Text;
                imports.ChangeTab();
            }, "Debug.data");

        }


        private void btnSearch4_Click(object sender, EventArgs e)
        {
            ErrorHandle.HandleError(() =>
            {
                this.exports.SearchExportTime = txtExpTime.Text;
                this.exports.SearchProductName = txtExpProductName.Text;
                exports.ChangeTab();
            }, "Debug.data");

        }



        private void btnSearch5_Click(object sender, EventArgs e)
        {
            ErrorHandle.HandleError(() =>
            {
                this.checkRecords.SearchCheckTime = txtCheckTime.Text;
                this.checkRecords.SearchProductName = txtCheckProductName.Text;
                checkRecords.ChangeTab();
            }, "Debug.data");

        }


        private void btnSearch6_Click(object sender, EventArgs e)
        {
            ErrorHandle.HandleError(() =>
           {
               this.manus.SearchManufacturerName = txtManufacturerName.Text;
               this.manus.ChangeTab();
           }, "Debug.data");
        }

        #endregion


        private void btnProductReset_Click(object sender, EventArgs e)
        {
            ErrorHandle.HandleError(() =>
            {
                txtSearchProductName.Text = "";
                products.ChangeTab();
            }, "Debug.data");

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }



        private void productMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var rows = dgvProd.SelectedRows;

            MessageBox.Show(rows[0].Index.ToString());

        }

        private void registNewUser_Click(object sender, EventArgs e)
        {
            if (userS.User.Auth == 0)
            {
                this.register = new Register(userS);
                this.register.Show();
            }
            else
            {
                MessageBox.Show("账户权限不足！");
            }

        }

        private void RetsetPwd_Click(object sender, EventArgs e)
        {
            this.RePwd=new RePasswd(this.userS);
            this.RePwd.Show();
        }



    }
}
