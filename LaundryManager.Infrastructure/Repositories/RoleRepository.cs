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
    internal class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(LaundaryDbContext laundaryDbContext) : base(laundaryDbContext)
        {
        }
    }
}
