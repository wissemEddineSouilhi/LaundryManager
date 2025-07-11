using LaundryManager.Application.Contracts.Services;
using LaundryManager.Application.Dtos;
using LaundryManager.Domain.Contracts.Repositories;
using LaundryManager.Domain.Contracts.Security;
using LaundryManager.Domain.Contracts.UnitOfWork;
using LaundryManager.Domain.Entities;
using LaundryManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManager.Application.Services
{
    internal class CommandService : ICommandService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly ICommandRepository _CommandRepository;
        private readonly ICommandStatusRepository _CommandStatusRepository;
        private readonly IArticleRepository _ArticleRepository;
        private readonly IUserRepository _UserRepository;
        private readonly IJwtTokenService _JwtTokenService;

        public CommandService(IUnitOfWork unitOfWork, ICommandRepository commandRepository, ICommandStatusRepository commandStatusRepository, IArticleRepository articleRepository, IUserRepository userRepository, IJwtTokenService jwtTokenService)
        {
            _UnitOfWork = unitOfWork;
            _CommandRepository = commandRepository;
            _CommandStatusRepository = commandStatusRepository;
            _ArticleRepository = articleRepository;
            _JwtTokenService = jwtTokenService;
            _UserRepository = userRepository;

        }

        public async Task CreateCommmandAsync(CreateCommandDto commandDto)
        {
            var commandStatuses = await _CommandStatusRepository.FindAsync(x => x.Code == (int)CommandStatusEnum.Pending);
            if (commandStatuses == null || !commandStatuses.Any())
            {
                throw new InvalidOperationException("Pending command status not found.");
            }
            if (commandStatuses.Count() > 1)
            {
                throw new InvalidOperationException("Multiple pending command statuses found. Expected only one.");
            }

            var statusId = commandStatuses.First().Id;

            Guid userId = await GetCurrentUserId();

            var command = new Command()
            {
                Id = Guid.NewGuid(),
                Comment = commandDto.Comment,
                Reason = commandDto.Reason,
                CreationDate = DateTime.Now,
                UserId = userId,
                StatusId = statusId,

            };
            await _CommandRepository.AddAsync(command);

            foreach (var articleDto in commandDto.Articles)
            {
                var article = new Article()
                {
                    ArticleTypeId = articleDto.ArticleTypeId,
                    CommandId = command.Id,
                    Name = articleDto.Name,
                    Description = articleDto.Description,
                    CreationDate = DateTime.UtcNow
                };
                await _ArticleRepository.AddAsync(article);
            }


            await _UnitOfWork.SaveChangesAsync();
        }

        private async Task<Guid> GetCurrentUserId()
        {
            var userName = _JwtTokenService.GetCurrentUsername();
            var users = await _UserRepository.FindAsync(u => u.Email == userName);
            var userId = users.First().Id;
            return userId;
        }


        public async Task<CommandDto> GetCommandDetails(Guid commandId)
        {
            var commands = await _CommandRepository.FindAsync(c => c.Id == commandId);
            if (commands == null || !commands.Any())
            {
                throw new KeyNotFoundException($"Command with ID {commandId} not found.");
            }

            if (commands.Count() > 1)
            {
                throw new InvalidOperationException($"Multiple commands found with ID {commandId}. Expected only one.");
            }

            return commands
                .Select(c => new CommandDto
                {
                    Id = c.Id,
                    Reason = c.Reason,
                    Comment = c.Comment
                })
                .First();
        }

        public async Task<IList<CommandDto>> GetCurrentUserCommandsListAsync()
        {
            var commandsDtos = new List<CommandDto>();

            Guid userId = await GetCurrentUserId();
            var currentUserCommands = await _CommandRepository.FindAsync(c => c.UserId == userId, c => c.Status, c => c.Articles);

            commandsDtos = currentUserCommands.Select(
                c => new CommandDto
                {
                    Id = c.Id,
                    Reason = c.Reason,
                    Comment = c.Comment,
                    StatusName = c.Status?.Name!,
                }).ToList();

            return commandsDtos;
        }

        public async Task SetCommandStatusAsync(Guid commandId, CommandStatusEnum commandStatusEnum)
        {
            throw new NotImplementedException();
        }
    }
}
