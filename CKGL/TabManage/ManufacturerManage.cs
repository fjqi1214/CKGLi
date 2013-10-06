using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Windows.Forms;
using BLL;
using System.Linq.Expressions;

namespace CKGL
{
    public class ManufacturerManage
         : TabManager<Manufacturer, string>
    {
        public ManufacturerManage(BindingSource s, DataGridView d, BindingNavigator n, ToolStripLabel currentPageNum, ToolStripLabel totalPageNum)
            : base(s, d, n, currentPageNum, totalPageNum, new SplitePageQuery<Manufacturer, string>())
        {

        }

        protected override int Save(List<Manufacturer> entities)
        {
            return pager.Update(entities);
        }

        protected override int Delete(List<Manufacturer> entities)
        {
            return pager.Delete(entities);
        }

        protected override List<Manufacturer> MoveToFirstPage()
        {
            List<Expression<Func<Manufacturer, bool>>> filters = GetFilters();
            var items = pager.MoveFirstPage(i => i.ManufacturerName, filters).ToList();
            return items;
        }

        protected override List<Manufacturer> MoveToLastPage()
        {
            List<Expression<Func<Manufacturer, bool>>> filters = GetFilters();
            var items = pager.MoveLastPage(i => i.ManufacturerName, filters).ToList();
            return items;
        }

        protected override List<Manufacturer> MoveToNextPage()
        {
            List<Expression<Func<Manufacturer, bool>>> filters = GetFilters();
            var items = pager.MoveNextPage(i => i.ManufacturerName, filters).ToList();
            return items;
        }

        protected override List<Manufacturer> MoveToPreviousPage()
        {
            List<Expression<Func<Manufacturer, bool>>> filters = GetFilters();
            var items = pager.MovePreviousPage(i => i.ManufacturerName, filters)
                .ToList();
            return items;
        }

        protected override List<Manufacturer> ChangePageSize(int newPagesize)
        {
            List<Expression<Func<Manufacturer, bool>>> filters = GetFilters();
            var items = pager.PageSizeChange(newPagesize, i => i.ManufacturerName, filters).ToList();
            return items;
        }

        protected override List<Manufacturer> MoveToSpecificPage(int pageNum)
        {
            List<Expression<Func<Manufacturer, bool>>> filters = GetFilters();
            var items = pager.MoveToPage(i => i.ManufacturerName, pageNum, filters).ToList();
            return items;
        }

        private List<Expression<Func<Manufacturer, bool>>> GetFilters()
        {
            
            List<Expression<Func<Manufacturer, bool>>> list = new List<Expression<Func<Manufacturer, bool>>>();

            if (!string.IsNullOrEmpty(SearchManufacturerName))
            {

                list.Add(b => b.ManufacturerName.Contains(SearchManufacturerName));
            }
            return list;
        }

        public string SearchManufacturerName { get; set; }
    }
}
