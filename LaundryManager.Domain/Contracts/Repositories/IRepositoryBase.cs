﻿using System.Linq.Expressions;

namespace LaundryManager.Domain.Contracts.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task AddAsync(T entity);
        Task<IList<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        void Update(T entity);
        void Remove(T entity);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
    }
}
