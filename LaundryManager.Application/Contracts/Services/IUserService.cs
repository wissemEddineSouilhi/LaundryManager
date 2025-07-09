using LaundryManager.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManager.Application.Contracts.Services
{
    public interface IUserService
    {
        Task<bool> IsUserAdminAsync(string userId);
        Task<TokenDto> LoginAsync(LoginDto loginDto);
        Task RegisterAsync(CreateUserDto createUserDto);

    }
}
