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
    public class ExportStorageManage
        : TabManager<ExportStorage, int>
    {
        public ExportStorageManage(BindingSource s, DataGridView d, BindingNavigator n, ToolStripLabel currentPageNum, ToolStripLabel totalPageNum)
            : base(s, d, n, currentPageNum, totalPageNum, new SplitePageQuery<ExportStorage, int>())
        {

        }

        protected override int Save(List<ExportStorage> entities)
        {
            return pager.Update(entities);
        }

        protected override int Delete(List<ExportStorage> entities)
        {
            return pager.Delete(entities);
        }

        protected override List<ExportStorage> MoveToFirstPage()
        {
            List<Expression<Func<ExportStorage, bool>>> filters = GetFilters();
            var items = pager.MoveFirstPage(i => i.Id, filters).ToList();
            return items;
        }

        protected override List<ExportStorage> MoveToLastPage()
        {
            List<Expression<Func<ExportStorage, bool>>> filters = GetFilters();
            var items = pager.MoveLastPage(i => i.Id, filters).ToList();
            return items;
        }

        protected override List<ExportStorage> MoveToNextPage()
        {
            List<Expression<Func<ExportStorage, bool>>> filters = GetFilters();
            var items = pager.MoveNextPage(i => i.Id, filters).ToList();
            return items;
        }

        protected override List<ExportStorage> MoveToPreviousPage()
        {
            List<Expression<Func<ExportStorage, bool>>> filters = GetFilters();
            var items = pager.MovePreviousPage(i => i.Id, filters)
                .ToList();
            return items;
        }

        protected override List<ExportStorage> ChangePageSize(int newPagesize)
        {
            List<Expression<Func<ExportStorage, bool>>> filters = GetFilters();
            var items = pager.PageSizeChange(newPagesize, i => i.Id, filters).ToList();
            return items;
        }

        protected override List<ExportStorage> MoveToSpecificPage(int pageNum)
        {
            List<Expression<Func<ExportStorage, bool>>> filters = GetFilters();
            var items = pager.MoveToPage(i => i.Id, pageNum, filters).ToList();
            return items;
        }

        private List<Expression<Func<ExportStorage, bool>>> GetFilters()
        {
            DateTime dateTime;
            List<Expression<Func<ExportStorage, bool>>> list = new List<Expression<Func<ExportStorage, bool>>>();
            if (!string.IsNullOrEmpty(SearchExportTime) && UtilityTool.ConvertToShortDateTime(SearchExportTime, out dateTime))
            {

                var endTime = dateTime.AddHours(24);
                list.Add(a => a.ExpTime > dateTime && a.ExpTime < endTime);
            }
            if (!string.IsNullOrEmpty(SearchProductName))
            {

                list.Add(b => b.ProductName.Contains(SearchProductName));
            }

            return list;
        }

        public string SearchProductName { get; set; }

        public string SearchExportTime { get; set; }

    }
}
