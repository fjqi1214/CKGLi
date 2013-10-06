//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;
//using BLL;
//using Model;
//using Interface;
//using System.Linq.Expressions;

using System.Windows.Forms;
using BLL;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
namespace CKGL
{
    public abstract class TabManager<T, Key>
    {
        private BindingSource bS;
        private BindingNavigator bN;
        private DataGridView dV;
        protected SplitePageQuery<T, Key> pager;
        private ToolStripLabel currentPageNum;
        private ToolStripLabel totalPageNum;
        private List<T> trackEntities;
        private List<T> trackDelts;

        public TabManager(BindingSource s, DataGridView d, BindingNavigator n, ToolStripLabel currentPageNum, ToolStripLabel totalPageNum, SplitePageQuery<T, Key> pager)
        {
            this.bS = s;
            this.dV = d;
            this.bN = n;
            this.pager = pager;
            this.currentPageNum = currentPageNum;
            this.totalPageNum = totalPageNum;
            trackDelts = new List<T>();
        }

        public void MovePreviousPage()
        {
            if (pager.Pager.CurrentPageNum == 0)
            {
                return;
            }
            this.trackEntities = MoveToPreviousPage();
            trackDelts.Clear();
            this.bS.DataSource = this.trackEntities;
            this.dV.DataSource = this.bS;
            this.totalPageNum.Text = pager.Pager.FormatTotalPageNum.ToString();
            this.currentPageNum.Text = pager.Pager.FormatPageNum.ToString();
        }

        public void MoveNextPage()
        {
            if (pager.Pager.CurrentPageNum == pager.Pager.TotalPageCount)
            {
                return;
            }
            this.trackEntities = MoveToNextPage();
            trackDelts.Clear();
            this.bS.DataSource = this.trackEntities;
            this.dV.DataSource = this.bS;
            this.totalPageNum.Text = pager.Pager.FormatTotalPageNum.ToString();
            this.currentPageNum.Text = pager.Pager.FormatPageNum.ToString();
        }

        public void MoveFirstPage()
        {
            if (pager.Pager.CurrentPageNum == 0)
            {
                return;
            }
            this.trackEntities = MoveToFirstPage();
            trackDelts.Clear();
            this.bS.DataSource = this.trackEntities;
            this.dV.DataSource = this.bS;
            this.totalPageNum.Text = pager.Pager.FormatTotalPageNum.ToString();
            this.currentPageNum.Text = pager.Pager.FormatPageNum.ToString();
        }

        public void MoveLastPage()
        {
            if (pager.Pager.CurrentPageNum == pager.Pager.TotalPageCount)
            {
                return;
            }
            this.trackEntities = MoveToLastPage();
            trackDelts.Clear();
            this.bS.DataSource = this.trackEntities;
            this.dV.DataSource = this.bS;

            this.totalPageNum.Text = pager.Pager.FormatTotalPageNum.ToString();
            this.currentPageNum.Text = pager.Pager.FormatPageNum.ToString();
        }

        public void MoveToPage(int num)
        {
            if (pager.Pager.TotalPageCount < num - 1)
            {
                return;
            }
            this.trackEntities = MoveToSpecificPage(num);
            trackDelts.Clear();
            this.bS.DataSource = this.trackEntities;
            this.dV.DataSource = this.bS;
            this.totalPageNum.Text = pager.Pager.FormatTotalPageNum.ToString();
            this.currentPageNum.Text = pager.Pager.FormatPageNum.ToString();

        }

        public void PageSizeChange(int newPageSize)
        {

            this.trackEntities = ChangePageSize(newPageSize);
            trackDelts.Clear();
            this.bS.DataSource = this.trackEntities;
            this.dV.DataSource = this.bS;
            this.totalPageNum.Text = pager.Pager.FormatTotalPageNum.ToString();
            this.currentPageNum.Text = pager.Pager.FormatPageNum.ToString();
        }
        public void ChangeTab()
        {
            this.trackEntities = MoveToFirstPage();
            trackDelts.Clear();
            this.bS.DataSource = this.trackEntities;
            this.dV.DataSource = this.bS;
            this.bN.BindingSource = this.bS;
            this.totalPageNum.Text = pager.Pager.FormatTotalPageNum.ToString();
            this.currentPageNum.Text = pager.Pager.FormatPageNum.ToString();
        }

        public int SaveChange()
        {
            int delCount = 0;
            int saveCount = 0;
            var r = MessageBox.Show("是否确认数据的更改！", "提示", MessageBoxButtons.YesNo);
            if (r == System.Windows.Forms.DialogResult.No)
            {
                return 0;
            }
            saveCount = Save(this.trackEntities);
            delCount = Delete(this.trackDelts);
            MessageBox.Show("删除" + delCount.ToString() + "，增加修改" + saveCount.ToString());
            return delCount + saveCount;
        }

        public void Delete()
        {
            List<int> rowNums = new List<int>();
            if (this.dV.SelectedRows != null && this.dV.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dV.SelectedRows)
                {
                    rowNums.Add(row.Index);
                }
            }

            foreach (var rowIndex in rowNums)
            {
                this.bS.DataSource = new List<T>();
                this.dV.DataSource = this.bS;
                this.bN.BindingSource = this.bS;
                trackDelts.Add(trackEntities[rowIndex]);
                trackEntities.RemoveAt(rowIndex);
                this.bS.DataSource = this.trackEntities;
                this.dV.DataSource = this.bS;
                this.bN.BindingSource = this.bS;
            }
        }

        public bool ValidateUnique(Expression<Func<T,bool>> func)
        {
            return pager.ValitedateKeyUnique(func);
        }


        protected abstract int Save(List<T> entities);

        protected abstract int Delete(List<T> entities);

        protected abstract List<T> MoveToFirstPage();

        protected abstract List<T> MoveToLastPage();

        protected abstract List<T> MoveToNextPage();

        protected abstract List<T> MoveToPreviousPage();

        protected abstract List<T> ChangePageSize(int newPagesize);

        protected abstract List<T> MoveToSpecificPage(int pageNum);



    }
}
