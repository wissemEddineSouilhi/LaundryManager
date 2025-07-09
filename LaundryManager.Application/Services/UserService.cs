using LaundryManager.Application.Contracts.Services;
using LaundryManager.Application.Dtos;
using LaundryManager.Domain.Contracts.Repositories;
using LaundryManager.Domain.Contracts.Security;
using LaundryManager.Domain.Contracts.UnitOfWork;
using LaundryManager.Domain.Entities;
using LaundryManager.Domain.Enums;

namespace LaundryManager.Application.Services
{
    internal class UserService : IUserService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IUserRepository _UserRepository;
        private readonly IRoleRepository _RoleRepository;
        private readonly IPasswordHasher _PasswordHasher;
        private readonly IJwtTokenService _JwtTokenService;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtTokenService jwtTokenService,IRoleRepository roleRepository)
        {
            _UnitOfWork = unitOfWork;
            _UserRepository = userRepository;
            _PasswordHasher = passwordHasher;
            _JwtTokenService = jwtTokenService;
            _RoleRepository = roleRepository;
        }
        public Task<bool> IsUserAdminAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<TokenDto> LoginAsync(LoginDto loginDto)
        {
            var isExist = await _UserRepository.ExistsAsync(u => u.Email == loginDto.UserName);
            if (!isExist)
            {
                throw new Exception("User not found");
            }

            var users = await _UserRepository.FindAsync(u => u.Email == loginDto.UserName);
            if (users == null || !users.Any())
            {
                throw new Exception("User not found");
            }
            if (users.Count() > 1)
            {
                throw new Exception("Multiple users found with the same email");
            }

            var isValidPassword = _PasswordHasher.Verify(loginDto.Password, users.First().Password);
            if (!isValidPassword)
            {
                throw new Exception("Invalid password");
            }

           var token = _JwtTokenService.GenerateToken(users.First().Email);

            return new TokenDto { TokenJwt = token };

        }

        public async Task RegisterAsync(CreateUserDto createUserDto)
        {
            var defaultRole = await _RoleRepository.FindAsync(r => r.Code == (int)RoleEnum.User);
            var user = new User()
            {
                FirstName = createUserDto.firstName,
                LastName = createUserDto.lastName,
                Password = _PasswordHasher.Hash(createUserDto.password),
                Email = createUserDto.email,
                PhoneNumber = createUserDto.PhoneNumber,
                CreationDate = DateTime.UtcNow,
                RoleId = defaultRole.First().Id,

            };

            await _UserRepository.AddAsync(user);
            await _UnitOfWork.SaveChangesAsync();
        }
    }
}
