﻿using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Zonda.Application.Common.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T Insert(T entity);
        T Update(T entity);
        void Delete(T entity);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool isDisableTracking = true);
        Task<IQueryable<T>> FilterAsync(Expression<Func<T, bool>> predicate = null,
                                             Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                             bool isDisableTracking = true);
        public U ExecuteScalar<U>(string query);
        public List<U> ExecuteReader<U>(string query);
    }
}
