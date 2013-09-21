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

        public TabManager(BindingSource s, DataGridView d, BindingNavigator n, ToolStripLabel currentPageNum, ToolStripLabel totalPageNum,SplitePageQuery<T, Key> pager)
        {
            this.bS = s;
            this.dV = d;
            this.bN = n;
            this.pager = pager;
            this.currentPageNum = currentPageNum;
            this.totalPageNum = totalPageNum;
        }

        public void MovePreviousPage()
        {
            if (pager.Pager.CurrentPageNum == 0)
            {
                return;
            }
            this.trackEntities = MoveToPreviousPage();
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
            this.bS.DataSource = this.trackEntities;
            this.dV.DataSource = this.bS;
            this.totalPageNum.Text = pager.Pager.FormatTotalPageNum.ToString();
            this.currentPageNum.Text = pager.Pager.FormatPageNum.ToString();

        }

        public void PageSizeChange(int newPageSize)
        {

            this.trackEntities = ChangePageSize(newPageSize);
            this.bS.DataSource = this.trackEntities;
            this.dV.DataSource = this.bS;
            this.totalPageNum.Text = pager.Pager.FormatTotalPageNum.ToString();
            this.currentPageNum.Text = pager.Pager.FormatPageNum.ToString();
        }
        public void ChangeTab()
        {
            this.trackEntities = MoveToFirstPage();
            this.bS.DataSource = this.trackEntities;
            this.dV.DataSource = this.bS;
            this.bN.BindingSource = this.bS;
            this.totalPageNum.Text = pager.Pager.FormatTotalPageNum.ToString();
            this.currentPageNum.Text = pager.Pager.FormatPageNum.ToString();
        }

        protected abstract List<T> MoveToFirstPage();

        protected abstract List<T> MoveToLastPage();

        protected abstract List<T> MoveToNextPage();

        protected abstract List<T> MoveToPreviousPage();

        protected abstract List<T> ChangePageSize(int newPagesize);

        protected abstract List<T> MoveToSpecificPage(int pageNum);



    }
}
