using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.BusinessLayer.Features.Mediator.Commands.UserCommands;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.UserQueries;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.UserResult;

namespace TaskManagementApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kullanıcı başarıyla oluşturuldu.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserQuery query)
        {
            TokenResult token = await _mediator.Send(query);
            if (token == null)
                return Unauthorized("E-posta veya şifre hatalı!");

            return Ok(token);
        }
    }
}
