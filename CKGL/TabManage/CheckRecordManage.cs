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
    public class CheckRecordManage
        : TabManager<CheckRecord, int>
    {
        public CheckRecordManage(BindingSource s, DataGridView d, BindingNavigator n, ToolStripLabel currentPageNum, ToolStripLabel totalPageNum)
            : base(s, d, n, currentPageNum, totalPageNum, new SplitePageQuery<CheckRecord, int>())
        { 
        
        }

        protected override int Save(List<CheckRecord> entities)
        {
            return pager.Update(entities);
        }

        protected override int Delete(List<CheckRecord> entities)
        {
            return pager.Delete(entities);
        }

        protected override List<CheckRecord> MoveToFirstPage()
        {
            List<Expression<Func<CheckRecord, bool>>> filters = GetFilters();
            var items = pager.MoveFirstPage(i => i.Id, filters).ToList();
            return items;
        }

        protected override List<CheckRecord> MoveToLastPage()
        {
            List<Expression<Func<CheckRecord, bool>>> filters = GetFilters();
            var items = pager.MoveLastPage(i => i.Id, filters).ToList();
            return items;
        }

        protected override List<CheckRecord> MoveToNextPage()
        {
            List<Expression<Func<CheckRecord, bool>>> filters = GetFilters();
            var items = pager.MoveNextPage(i => i.Id, filters).ToList();
            return items;
        }

        protected override List<CheckRecord> MoveToPreviousPage()
        {
            List<Expression<Func<CheckRecord, bool>>> filters = GetFilters();
            var items = pager.MovePreviousPage(i => i.Id, filters)
                .ToList();
            return items;
        }

        protected override List<CheckRecord> ChangePageSize(int newPagesize)
        {
            List<Expression<Func<CheckRecord, bool>>> filters = GetFilters();
            var items = pager.PageSizeChange(newPagesize, i => i.Id, filters).ToList();
            return items;
        }

        protected override List<CheckRecord> MoveToSpecificPage(int pageNum)
        {
            List<Expression<Func<CheckRecord, bool>>> filters = GetFilters();
            var items = pager.MoveToPage(i => i.Id, pageNum, filters).ToList();
            return items;
        }

        private List<Expression<Func<CheckRecord, bool>>> GetFilters()
        {
            DateTime dateTime;
            List<Expression<Func<CheckRecord, bool>>> list = new List<Expression<Func<CheckRecord, bool>>>();
            if (!string.IsNullOrEmpty(SearchCheckTime) && UtilityTool.ConvertToShortDateTime(SearchCheckTime, out dateTime))
            {

                var endTime = dateTime.AddHours(24);
                list.Add(a => a.CheckTime > dateTime && a.CheckTime < endTime);
            }
            if (!string.IsNullOrEmpty(SearchProductName))
            {

                list.Add(b => b.ProductName.Contains(SearchProductName));
            }

            return list;
        }


        public string SearchProductName { get; set; }

        public string SearchCheckTime { get; set; }
    
    }
}
