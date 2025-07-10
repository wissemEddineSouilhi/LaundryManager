using LaundryManager.Application.Contracts.Services;
using LaundryManager.Application.Dtos;
using LaundryManager.Domain.Contracts.Security;
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
        public async Task<IActionResult> GetCommands()
        {
            var commands = await _CommandService.GetUserCommandsListAsync();
            return Ok(commands);
        }
    }
}
