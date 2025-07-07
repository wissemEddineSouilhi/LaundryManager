using LaundryManager.Domain.Contracts.Repositories;
using LaundryManager.Domain.Entities;
using LaundryManager.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManager.Infrastructure.Repositories
{
    internal class CommandRepository : RepositoryBase<Command>, ICommandRepository
    {
        public CommandRepository(LaundaryDbContext laundaryDbContext) : base(laundaryDbContext)
        {
        }
    }
}
