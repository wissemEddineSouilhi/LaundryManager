using LaundryManager.Application.Contracts.Services;
using LaundryManager.Application.Dtos;
using LaundryManager.Domain.Contracts.Repositories;
using LaundryManager.Domain.Contracts.UnitOfWork;
using LaundryManager.Domain.Entities;
using System.Security.Cryptography;

namespace LaundryManager.Application.Services
{
    internal class UserService : IUserService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IUserRepository _UserRepository;
        private readonly IPasswordHasher _PasswordHasher;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _UnitOfWork = unitOfWork;
            _UserRepository = userRepository;
            _PasswordHasher = passwordHasher;
        }
        public Task<bool> IsUserAdminAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<TokenDto> LoginAsync(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterAsync(CreateUserDto createUserDto)
        {
            var user = new User()
            {
                FirstName = createUserDto.firstName,
                LastName = createUserDto.lastName,
                Password = _PasswordHasher.Hash(createUserDto.password),

            };

            await _UserRepository.AddAsync(user);
            await _UnitOfWork.SaveChangesAsync();
        }
    }
}
