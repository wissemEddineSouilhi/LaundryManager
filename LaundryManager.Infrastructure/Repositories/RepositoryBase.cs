using LaundryManager.Domain.Contracts.Repositories;
using LaundryManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManager.Infrastructure.Repositories
{
    internal abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly LaundaryDbContext _LaundaryDbContext;
        protected readonly DbSet<T> _DbSet;
        public RepositoryBase(LaundaryDbContext laundaryDbContext)
        {
            _LaundaryDbContext = laundaryDbContext;
            _DbSet = _LaundaryDbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _DbSet.AddAsync(entity);
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _DbSet.AnyAsync(predicate);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _DbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.Where(predicate).ToListAsync();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _DbSet.ToListAsync();
        }

        public void Remove(T entity)
        {
            _DbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _DbSet.Update(entity);
        }
    }
}
