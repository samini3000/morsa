using Application.Account;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Login")]   
        public async Task<IActionResult> Login(string email, CancellationToken cancellationToken)
        {
            var token = await _mediator.Send(new LoginCommand(email), cancellationToken);
            if(token == "invalid")
            {
                return BadRequest(token);
            }
            return Ok(token);   
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] Account account, CancellationToken cancellationToken)
        {
            await _mediator.Send(new AddAccountCommand(account),cancellationToken);
            return Ok();
        }
    }
}