using LaundryManager.Domain.Contracts.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManager.Infrastructure.Data
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly LaundaryDbContext _Context;

        public UnitOfWork(LaundaryDbContext context)
        {
            _Context = context;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _Context.SaveChangesAsync(cancellationToken);
        }
    }
}
