using LaundryManager.Application.Contracts.Services;
using LaundryManager.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LaundryManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommandController: ControllerBase
    {
        private readonly ICommandService _CommandService;
        public CommandController(ICommandService commandService)
        {
            _CommandService = commandService;
        }

        [HttpPost("CreateCommand")]
        public async Task<IActionResult> CreateCommand([FromBody] CreateCommandDto dto)
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
