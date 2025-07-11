using LaundryManager.Application.Dtos;
using LaundryManager.Domain.Entities;
using LaundryManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManager.Application.Contracts.Services
{
    public interface ICommandService
    {
        Task CreateCommmandAsync(CreateCommandDto command);
        Task SetCommandStatusAsync(Guid commandId, CommandStatusEnum commandStatusEnum);
        Task<IList<CommandDto>> GetCurrentUserCommandsListAsync();
        Task<IList<CommandDto>> GetAllCommandsListAsync();
        Task<CommandDto> GetCommandDetails(Guid commandId);
    }
}
