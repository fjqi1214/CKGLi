using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interface;
using DAL;
using Model;
using System.Linq.Expressions;
namespace BLL
{
    public class SplitePageQuery<T, Key> : ISplitePageQuery<T, Key>
       
    {

        CKGLContext context = new CKGLContext();

        private Dictionary<Type, object> Pagingquery;

        public SplitePageQuery()
        {
            Pagingquery = new Dictionary<Type, object>(){
                {typeof(StorageLocation),new SqlHelp<StorageLocation,string>(this.context)},
                {typeof(CheckRecord),new SqlHelp<CheckRecord,int>(this.context)},
                {typeof(ExportStorage),new SqlHelp<ExportStorage,int>(this.context)},
                {typeof(ImportStorage),new SqlHelp<ImportStorage,int>(this.context)},
                {typeof(Manufacturer),new  SqlHelp<Manufacturer,string>(this.context)},
                {typeof(Product),new  SqlHelp<Product,int>(this.context) },
            };
        }
        private SplitPager pager;
        public SplitPager Pager
        {
            set
            {
                pager = value;
            }
            get
            {
                return pager;
            }
        }

        #region ISplitePageQuery<T> Members

        public IQueryable<T> MoveNextPage(Expression<Func<T, Key>> func, List<Expression<Func<T, bool>>> filters)
        {
            pager.MoveNextPage();

            var items = ((IDataQuery<T, Key>)Pagingquery[typeof(T)])
                .PagingQuery(pager.CurrentPageNum, pager.PageSize, func,filters);
            return items;
        }

        public IQueryable<T> MovePreviousPage(Expression<Func<T, Key>> func, List<Expression<Func<T, bool>>> filters)
        {
            pager.MovePreviousPage();
            var items = ((IDataQuery<T, Key>)Pagingquery[typeof(T)])
                 .PagingQuery(pager.CurrentPageNum, pager.PageSize, func,filters);
            return items;
        }

        public IQueryable<T> MoveLastPage(Expression<Func<T, Key>> func,List<Expression<Func<T, bool>>> filters)
        {
            var total = ((IDataQuery<T, Key>)Pagingquery[typeof(T)]).GetCount(filters);
            pager.MoveLastPage(total);
            return ((IDataQuery<T, Key>)Pagingquery[typeof(T)])
               .PagingQuery(pager.CurrentPageNum, pager.PageSize, func,filters);
        }

        public IQueryable<T> MoveFirstPage(Expression<Func<T, Key>> func,List<Expression<Func<T, bool>>> filters)
        {
            var total = ((IDataQuery<T, Key>)Pagingquery[typeof(T)]).GetCount(filters);
            if (pager == null)
            {
                pager = new SplitPager(10, total);
            }
            pager.MoveFirstPage(total);
            return ((IDataQuery<T, Key>)Pagingquery[typeof(T)])
                .PagingQuery(pager.CurrentPageNum, pager.PageSize, func, filters);
        }

        public IQueryable<T> MoveToPage(Expression<Func<T, Key>> func, int num,List<Expression<Func<T, bool>>> filters)
        {
            pager.MoveToPage(num - 1);
            return ((IDataQuery<T, Key>)Pagingquery[typeof(T)])
               .PagingQuery(pager.CurrentPageNum, pager.PageSize, func, filters);


        }

        public IQueryable<T> PageSizeChange(int newPageSize, Expression<Func<T, Key>> func, List<Expression<Func<T, bool>>> filters)
        {
            var total = ((IDataQuery<T, Key>)Pagingquery[typeof(T)]).GetCount(filters);
            this.pager = new SplitPager(newPageSize, total);//ma
            pager.MoveFirstPage(total);
            return ((IDataQuery<T, Key>)Pagingquery[typeof(T)])
               .PagingQuery(pager.CurrentPageNum, pager.PageSize, func, filters);

        }

        #endregion


        #region IPersistent<T> Members

        public int Update(List<T> e)
        {
            return ((IPersistent<T>)Pagingquery[typeof(T)]).Update(e);
        }

        public int Delete(List<T> e)
        {
            throw new NotImplementedException();
        }

        public int Insert(List<T> e)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
