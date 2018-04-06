using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using HomeBudget.DAL.Interfaces;
using HomeBudget.Models;

namespace HomeBudget.DAL.Repositories
{
    public class AbstractRepository<T> : IAbstractRepository<T>, IGetListWithIncludes<T> where T : class
    {
        public void Create(T entity)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var context = new ApplicationDbContext())
            {

                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            using (var context = new ApplicationDbContext())
            {
                var query = context.Set<T>().Where(expression);
                return query.ToList();
            }
        }

        public virtual List<T> GetWhereWithIncludes(Expression<Func<T, bool>> expressionWhere, params Expression<Func<T, object>>[] includes)
        {
            using (var context = new ApplicationDbContext())
            {
                IQueryable<T> query = context.Set<T>();
                foreach (Expression<Func<T, object>> include in includes)
                    query = query.Include(include);
                query = query.Where(expressionWhere);
                return query.ToList();
            }
        }

        public void Update(T entity)
        {
            using (var context = new ApplicationDbContext())
            {

                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}