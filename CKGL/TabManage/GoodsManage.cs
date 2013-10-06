using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Windows.Forms;
using BLL;

namespace CKGL
{
    class GoodsManage
        : TabManager<GoodsDetail, string>
    {
        public GoodsManage(BindingSource s, DataGridView d, BindingNavigator n, ToolStripLabel currentPageNum, ToolStripLabel totalPageNum)
            : base(s, d, n, currentPageNum, totalPageNum, new SplitePageQuery<GoodsDetail, string>())
        { 
        
        }


        protected override int Save(List<GoodsDetail> entities)
        {
            throw new NotImplementedException();
        }

        protected override int Delete(List<GoodsDetail> entities)
        {
            throw new NotImplementedException();
        }

        protected override List<GoodsDetail> MoveToFirstPage()
        {
            throw new NotImplementedException();
        }

        protected override List<GoodsDetail> MoveToLastPage()
        {
            throw new NotImplementedException();
        }

        protected override List<GoodsDetail> MoveToNextPage()
        {
            throw new NotImplementedException();
        }

        protected override List<GoodsDetail> MoveToPreviousPage()
        {
            throw new NotImplementedException();
        }

        protected override List<GoodsDetail> ChangePageSize(int newPagesize)
        {
            throw new NotImplementedException();
        }

        protected override List<GoodsDetail> MoveToSpecificPage(int pageNum)
        {
            throw new NotImplementedException();
        }
    }
}
