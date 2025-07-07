using LaundryManager.Application.Contracts.Services;
using LaundryManager.Application.Dtos;
using LaundryManager.Domain.Contracts.Repositories;
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

        public CommandService(IUnitOfWork unitOfWork, ICommandRepository commandRepository, ICommandStatusRepository commandStatusRepository)
        {
            _UnitOfWork = unitOfWork;
            _CommandRepository = commandRepository;
            _CommandStatusRepository = commandStatusRepository;
        }

        public async Task CreateCommmandAsync(CreateCommandDto commandDto)
        {
            var commandStatuses = await _CommandStatusRepository.FindAsync(x=>x.Code == (int)CommandStatusEnum.Pending);
            if (commandStatuses == null || !commandStatuses.Any())
            {
                throw new InvalidOperationException("Pending command status not found.");
            }
            if (commandStatuses.Count() > 1)
            {
                throw new InvalidOperationException("Multiple pending command statuses found. Expected only one.");
            }

            var statusId = commandStatuses.First().Id;

            var command = new Command()
            {
                Comment = commandDto.Comment,
                Reason = commandDto.Reason,
                CreationDate = DateTime.Now,
               // UserId = commandDto.UserId,//currentUser
                StatusId = statusId
            };

            await _CommandRepository.AddAsync(command);
            await _UnitOfWork.SaveChangesAsync();
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
                    Comment = c.Comment,
                    UserId = c.UserId,         
                })
                .First();
        }

        public async Task<IList<CommandDto>> GetUserCommandsListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task SetCommandStatusAsync(Guid commandId, CommandStatusEnum commandStatusEnum)
        {
            throw new NotImplementedException();
        }
    }
}
