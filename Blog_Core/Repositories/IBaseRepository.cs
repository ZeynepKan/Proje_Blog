using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_Core.Model;

namespace Blog_Core.Repositories
{
    public interface IBaseRepository<T> where T : IBaseEntity
    {
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> Any(Expression<Func<T, bool>> expression);
        Task<T> GetDefault(Expression<Func<T, bool>> expression);
        Task<List<T>> GetDefaults(Expression<Func<T, bool>> expression);

        Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> selector,
                               Expression<Func<T, bool>> expression,
                               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                               Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> selector,
                              Expression<Func<T, bool>> expression,
                              Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                              Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

    }
}
