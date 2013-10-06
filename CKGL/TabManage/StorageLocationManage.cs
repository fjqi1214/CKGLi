using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Model;
using System.Linq.Expressions;

namespace CKGL
{
    public class StorageLocationManage
        : TabManager<StorageLocation, string>
    {


        public StorageLocationManage(BindingSource s, DataGridView d, BindingNavigator n, ToolStripLabel currentPageNum, ToolStripLabel totalPageNum)
            : base(s, d, n, currentPageNum, totalPageNum, new SplitePageQuery<StorageLocation, string>())
        {


        }

        protected override int Save(List<StorageLocation> entities)
        {
            return pager.Update(entities);
        }

        protected override int Delete(List<StorageLocation> entities)
        {
            return pager.Delete(entities);
        }

        protected override List<StorageLocation> MoveToFirstPage()
        {
            List<Expression<Func<StorageLocation, bool>>> filters = GetFilters();
            var items = pager.MoveFirstPage(i => i.LocationName, filters).ToList();
            return items;
        }

        protected override List<StorageLocation> MoveToLastPage()
        {
            List<Expression<Func<StorageLocation, bool>>> filters = GetFilters();
            var items = pager.MoveLastPage(i => i.LocationName, filters).ToList();
            return items;
        }

        protected override List<StorageLocation> MoveToNextPage()
        {
            List<Expression<Func<StorageLocation, bool>>> filters = GetFilters();
            var items = pager.MoveNextPage(i => i.LocationName, filters).ToList();
            return items;
        }

        protected override List<StorageLocation> MoveToPreviousPage()
        {
            List<Expression<Func<StorageLocation, bool>>> filters = GetFilters();
            var items = pager.MovePreviousPage(i => i.LocationName, filters)
                .ToList();
            return items;
        }

        protected override List<StorageLocation> ChangePageSize(int newPagesize)
        {
            List<Expression<Func<StorageLocation, bool>>> filters = GetFilters();
            var items = pager.PageSizeChange(newPagesize, i => i.LocationName, filters).ToList();
            return items;
        }

        protected override List<StorageLocation> MoveToSpecificPage(int pageNum)
        {
            List<Expression<Func<StorageLocation, bool>>> filters = GetFilters();
            var items = pager.MoveToPage(i => i.LocationName, pageNum, filters).ToList();
            return items;
        }


        private List<Expression<Func<StorageLocation, bool>>> GetFilters()
        {
            bool use = false;
            List<Expression<Func<StorageLocation, bool>>> list = new List<Expression<Func<StorageLocation, bool>>>();
            if (!string.IsNullOrEmpty(this.SearchUse))
            {
                if (this.SearchUse == "是")
                {
                    use = true;
                }


                list.Add(a => a.CanUse == use);
            }
            if (!string.IsNullOrEmpty(this.SearchLocationName))
            {
                list.Add(b => b.LocationName.Contains(this.SearchLocationName));
            }

            return list;
        }


        public string SearchUse { get; set; }

        public string SearchLocationName { get; set; }
    }
}
