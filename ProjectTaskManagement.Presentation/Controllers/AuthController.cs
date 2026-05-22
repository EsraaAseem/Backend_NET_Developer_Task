
using Microsoft.AspNetCore.Mvc;
using ProjectTaskManagement.Application.Features.Authentication.Login;
using ProjectTaskManagement.Application.Features.Authentication.Register;

namespace ProjectTaskManagement.Presentation.Controllers
{
    public class AuthController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(
            RegisterDto dto)
        {
            var result = await Mediator.Send(
                new RegisterCommand(dto));

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            LoginDto dto)
        {
            var result = await Mediator.Send(
                new LoginCommand(dto));

            return Ok(result);
        }
    }
}
