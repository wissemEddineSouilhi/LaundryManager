using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManager.Domain.Contracts.Security
{
    public interface IJwtTokenService
    {
        public string GetCurrentUsername();
         string GenerateToken(string userName);
    }
}
