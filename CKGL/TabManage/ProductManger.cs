using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using Model;
using BLL;
using System.Linq.Expressions;
using Utility;

namespace CKGL
{
    public class ProductManger : TabManager<Product, int>
    {
      

        public ProductManger(BindingSource s, DataGridView d, BindingNavigator n, ToolStripLabel currentPageNum, ToolStripLabel totalPageNum)
            : base(s, d, n, currentPageNum, totalPageNum, new SplitePageQuery<Product, int>())
        {


        }

        protected override List<Product> MoveToPreviousPage()
        {

            List<Expression<Func<Product, bool>>> filters = GetFilters();
            var items = pager.MovePreviousPage(i => i.Id, filters)
                .ToList();
            return items;
        }

        protected override List<Product> MoveToNextPage()
        {

            List<Expression<Func<Product, bool>>> filters = GetFilters();
            var items = pager.MoveNextPage(i => i.Id, filters).ToList();
            return items;

        }

        protected override List<Product> MoveToFirstPage()
        {

            List<Expression<Func<Product, bool>>> filters = GetFilters();
            var items = pager.MoveFirstPage(i => i.Id, filters).ToList();
            return items;
        }


        protected override List<Product> MoveToLastPage()
        {
           
            List<Expression<Func<Product, bool>>> filters = GetFilters();
            var items= pager.MoveLastPage(i => i.Id, filters).ToList();
            return items;
        }

        protected override List<Product> MoveToSpecificPage(int num)
        {
           
            List<Expression<Func<Product, bool>>> filters = GetFilters();
            var items = pager.MoveToPage(i => i.Id, num, filters).ToList();
            return items;

        }

        protected override List<Product> ChangePageSize(int newPageSize)
        {
            List<Expression<Func<Product, bool>>> filters = GetFilters();
            var items= pager.PageSizeChange(newPageSize, i => i.Id, filters).ToList();
            return items;
        }


        protected override int Save(List<Product> entities)
        {
            return pager.Update(entities);
        }

        protected override int Delete(List<Product> entities)
        {
            return pager.Delete(entities);
        }


        private List<Expression<Func<Product, bool>>> GetFilters()
        {
            DateTime dateTime;
            List<Expression<Func<Product, bool>>> list = new List<Expression<Func<Product, bool>>>();
            if (!string.IsNullOrEmpty(SearchCheckTime) && UtilityTool.ConvertToShortDateTime(SearchCheckTime, out dateTime))
            {

                var endTime = dateTime.AddHours(24);
                list.Add(a => a.CheckTime > dateTime && a.CheckTime < endTime);
            }
            if (!string.IsNullOrEmpty(SearchProduct))
            {

                list.Add(b => b.ProductName.Contains(SearchProduct));
            }

            return list;
        }

        public string SearchProduct { get; set; }
        public string SearchCheckTime { get; set; }


      
    }
}
