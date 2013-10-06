using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Windows.Forms;
using BLL;
using System.Linq.Expressions;
using Utility;

namespace CKGL
{
    public class ImportStorageManage
         : TabManager<ImportStorage, int>
    {

        public ImportStorageManage(BindingSource s, DataGridView d, BindingNavigator n, ToolStripLabel currentPageNum, ToolStripLabel totalPageNum)
            : base(s, d, n, currentPageNum, totalPageNum, new SplitePageQuery<ImportStorage, int>())
        {

        }
        protected override int Save(List<ImportStorage> entities)
        {
            return pager.Update(entities);
        }

        protected override int Delete(List<ImportStorage> entities)
        {
            return pager.Delete(entities);
        }

        protected override List<ImportStorage> MoveToFirstPage()
        {
            List<Expression<Func<ImportStorage, bool>>> filters = GetFilters();
            var items = pager.MoveFirstPage(i => i.Id, filters).ToList();
            return items;
        }

        protected override List<ImportStorage> MoveToLastPage()
        {
            List<Expression<Func<ImportStorage, bool>>> filters = GetFilters();
            var items = pager.MoveLastPage(i => i.Id, filters).ToList();
            return items;
        }

        protected override List<ImportStorage> MoveToNextPage()
        {
            List<Expression<Func<ImportStorage, bool>>> filters = GetFilters();
            var items = pager.MoveNextPage(i => i.Id, filters).ToList();
            return items;
        }

        protected override List<ImportStorage> MoveToPreviousPage()
        {
            List<Expression<Func<ImportStorage, bool>>> filters = GetFilters();
            var items = pager.MovePreviousPage(i => i.Id, filters)
                .ToList();
            return items;
        }

        protected override List<ImportStorage> ChangePageSize(int newPagesize)
        {
            List<Expression<Func<ImportStorage, bool>>> filters = GetFilters();
            var items = pager.PageSizeChange(newPagesize, i => i.Id, filters).ToList();
            return items;
        }

        protected override List<ImportStorage> MoveToSpecificPage(int pageNum)
        {
            List<Expression<Func<ImportStorage, bool>>> filters = GetFilters();
            var items = pager.MoveToPage(i => i.Id, pageNum, filters).ToList();
            return items;
        }

        private List<Expression<Func<ImportStorage, bool>>> GetFilters()
        {
            DateTime dateTime;
            List<Expression<Func<ImportStorage, bool>>> list = new List<Expression<Func<ImportStorage, bool>>>();
            if (!string.IsNullOrEmpty(SearchImportTime) && UtilityTool.ConvertToShortDateTime(SearchImportTime, out dateTime))
            {

                var endTime = dateTime.AddHours(24);
                list.Add(a => a.ArrivalTime > dateTime && a.ArrivalTime < endTime);
            }
            if (!string.IsNullOrEmpty(SearchProductName))
            {

                list.Add(b => b.ProductName.Contains(SearchProductName));
            }

            return list;
        }

        public string SearchProductName { get; set; }

        public string SearchImportTime { get; set; }


    }
}
