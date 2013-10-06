using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Linq.Expressions;

namespace Interface
{
    public interface IUserLogin
    {
         User GetUser(string name, string pwd);
    }

    public interface ISplitePageQuery<T,Key>
    {
        IQueryable<T> MoveNextPage(Expression<Func<T, Key>> func,List<Expression<Func<T,bool>>> filters);
        IQueryable<T> MovePreviousPage(Expression<Func<T, Key>> func, List<Expression<Func<T, bool>>> filters);
        IQueryable<T> MoveLastPage(Expression<Func<T, Key>> func, List<Expression<Func<T,bool>>> filters);
        IQueryable<T> MoveFirstPage(Expression<Func<T, Key>> func, List<Expression<Func<T, bool>>> filters);
        IQueryable<T> MoveToPage(Expression<Func<T, Key>> func, int num, List<Expression<Func<T, bool>>> filters);
        
       
    }

    public interface IDataQuery<T,Key>
    {
        IQueryable<T> PagingQuery(int pageNum, int size, Expression<Func<T,Key>> func,List<Expression<Func<T,bool>>> filters);

        int GetCount(List<Expression<Func<T, bool>>> filters);
    }

    public interface IPersistent<T>
    {
        int Update(List<T> e);
        int Delete(List<T> e);
        int Insert(List<T> e);
    }

    public interface IValitdate<T>
    {
        bool ValitedateKeyUnique(Expression<Func<T, bool>> func);
    }


}
