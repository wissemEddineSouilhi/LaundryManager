using LaundryManager.Application.Contracts.Services;
using LaundryManager.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace LaundryManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IUserService _UserService;
        public UserController(IUserService userService)
        {
            _UserService = userService;
        }


        [HttpPost("[action]")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(TokenDto))]
        public async Task<ActionResult<TokenDto>> Login(LoginDto loginDto)
        {
            var token = await _UserService.LoginAsync(loginDto);
            return Ok(token);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto createUserDto)
        {
            await _UserService.RegisterAsync(createUserDto);
            return Created();
        }

    }
}
