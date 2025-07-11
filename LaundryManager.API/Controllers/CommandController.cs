using LaundryManager.Application.Contracts.Services;
using LaundryManager.Application.Dtos;
using LaundryManager.Domain.Contracts.Security;
using LaundryManager.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaundryManager.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CommandController: ControllerBase
    {
        private readonly ICommandService _CommandService;

        public CommandController(ICommandService commandService, IJwtTokenService jwtTokenService)
        {
            _CommandService = commandService;
        }

        [HttpPost("CreateCommand")]
        public async Task<IActionResult> CreateCommand(CreateCommandDto dto)
        {
            await _CommandService.CreateCommmandAsync(dto);
            return Created();
        }

        [HttpGet("GetCommands")]
        public async Task<ActionResult<IList<CommandDto>>> GetCurrentUserCommands()
        {
            var commands = await _CommandService.GetCurrentUserCommandsListAsync();
            return Ok(commands);
        }
        [Authorize(Roles = nameof(RoleEnum.Admin))]
        [HttpGet("GetAllCommandsForAdmin")]
        public async Task<ActionResult<IList<CommandDto>>> GetAllCommandsForAdmin()
        {
            var commands = await _CommandService.GetAllCommandsListAsync();
            return Ok(commands);
        }

        [Authorize(Roles = nameof(RoleEnum.Admin))]
        [HttpPost("ValidateCommand")]
        public async Task<ActionResult> ValidateCommand(ValidateCommandDto validateCommandDto)
        {
            await _CommandService.ValidateCommandAsync(validateCommandDto.CommandId);
            return Ok();
        }

        [Authorize(Roles = nameof(RoleEnum.Admin))]
        [HttpPost("RejectCommand")]
        public async Task<ActionResult> RejectCommand(RejectCommandDto rejectCommandDto)
        {
            await _CommandService.RejectCommandAsync(rejectCommandDto.CommandId);
            return Ok();
        }
    }
}
