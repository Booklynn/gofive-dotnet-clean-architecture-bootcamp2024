using Application.Features.Auth.Queries.GetJwtToken;
using Application.Features.Auth.Commands.CreateAccount;
using Application.Models.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        readonly IMediator Mediator = mediator;

        [Authorize]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            var command = new CreateAccountCommand { Request = request };
            var result = await Mediator.Send(command);
            
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var query = new GetJwtTokenQuery 
            { 
                Email = request.Email, 
                Password = request.Password 
            };
            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
