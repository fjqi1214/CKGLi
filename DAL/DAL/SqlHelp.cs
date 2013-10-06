using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interface;
using Model;
using System.Linq.Expressions;
using Utility;
namespace DAL
{
    public class SqlHelp<T, Key> : IPersistent<T>, IDataQuery<T, Key>, IValitdate<T>, IUserLogin where T : class
    {

        CKGLContext db;
        public SqlHelp(CKGLContext context)
        {
            this.db = context;
        }

        #region IDataQuery Members

        public IQueryable<T> PagingQuery(int pageNum, int size, Expression<Func<T, Key>> func, List<Expression<Func<T, bool>>> filters)
        {
            if (filters != null && filters.Count != 0)
            {
                //if (filters.Count == 3)
                //{

                //  var e= LabelExpression.And(filters[0], filters[1]);
                //   e = LabelExpression.And(e, filters[2]);
                //   var two= Expression.Lambda<Func<T,bool>>(e, Expression.Parameter(typeof(T)));

                //   return db.Set<T>().Where(two).OrderBy(func).Skip(pageNum * size).Take(size);
                //}
                if (filters.Count == 2)
                {

                    return db.Set<T>().Where(filters[0]).Where(filters[1]).OrderBy(func).Skip(pageNum * size).Take(size);
                }
                if (filters.Count == 1)
                {
                    return db.Set<T>().Where(filters[0]).OrderBy(func).Skip(pageNum * size).Take(size);
                }
            }

            return db.Set<T>().OrderBy(func).Skip(pageNum * size).Take(size);
        }

        public int GetCount(List<Expression<Func<T, bool>>> filters)
        {

            if (filters != null && filters.Count != 0)
            {
                if (filters.Count == 2)
                {
                    return db.Set<T>().Where(filters[0]).Where(filters[1]).Count();
                }
                if (filters.Count == 1)
                {
                    return db.Set<T>().Where(filters[0]).Count();
                }

            }
            return db.Set<T>().Count();

        }

        #endregion

        #region IPersistent<T> Members

        /// <summary>
        /// 返回保存的数量
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int Update(List<T> entities)
        {
            int num = 0;
            if (entities != null && entities.Count > 0)
            {
                List<T> modiftyList = new List<T>();
                List<T> addList = new List<T>();
                foreach (var e in entities)
                {

                    if (db.Entry<T>(e).State == System.Data.EntityState.Unchanged)
                    {
                        continue;
                    }
                    else if (db.Entry<T>(e).State == System.Data.EntityState.Detached)
                    {
                        addList.Add(e);
                    }
                    else if (db.Entry<T>(e).State == System.Data.EntityState.Modified)
                    {
                        modiftyList.Add(e);
                    }
                }

              

                RecoverHandler.RecoverError(() =>
                {

                    foreach (var e in modiftyList)
                    {
                        db.Entry<T>(e).State = System.Data.EntityState.Modified;

                    }
                    foreach (var e in addList)
                    {
                        db.Set<T>().Add(e);
                    }
                    num = db.SaveChanges();
                }
                  , () =>
                  {
                      foreach (var e in addList)
                      {
                          db.Set<T>().Remove(e);
                      }

                  });
            }

            return num;

        }

        public int Delete(List<T> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (var e in entities)
                {
                    if (db.Entry<T>(e).State == System.Data.EntityState.Detached)
                    {
                        continue;
                    }
                    db.Entry<T>(e).State = System.Data.EntityState.Deleted;

                }
                return db.SaveChanges();
            }
            else
            {
                return 0;
            }

        }

        public int Insert(List<T> e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserLogin Members

        public User GetUser(string name, string pwd)
        {
            var user = this.db.Users.Where(i => i.UserName == name && i.Pwd == pwd).FirstOrDefault();

            return user;
        }
        #endregion



        #region IValitdate<T,Key> Members

        public bool ValitedateKeyUnique(Expression<Func<T, bool>> func)
        {
            var count = this.db.Set<T>().Count<T>(func);
            if (count == 0)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
