using LaundryManager.Application.Contracts.Services;
using LaundryManager.Application.Dtos;
using LaundryManager.Domain.Contracts.Repositories;
using LaundryManager.Domain.Contracts.UnitOfWork;

namespace LaundryManager.Application.Services
{
    internal class UserService : IUserService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IUserRepository _UserRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _UnitOfWork = unitOfWork;
            _UserRepository = userRepository;
        }
        public Task<bool> IsUserAdminAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<string> LoginAsync(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public Task RegisterAsync(CreateUserDto createUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
