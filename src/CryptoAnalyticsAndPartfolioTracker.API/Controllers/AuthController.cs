using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.API.DTOs.Requests.Login;
using CryptoAnalyticsAndPartfolioTracker.API.DTOs.Requests.Register;
using CryptoAnalyticsAndPartfolioTracker.Application.Users.Login;
using CryptoAnalyticsAndPartfolioTracker.Application.Users.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CryptoAnalyticsAndPartfolioTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new RegisterUserCommand(request.UserName, request.Email, request.Password), cancellationToken);

            return NoContent();
        }

        [HttpGet]
        [Route("login")]
        public async Task<ActionResult<string>> LoginAsync([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            var token = await _mediator.Send(new LoginUserCommand(request.Email, request.Password), cancellationToken);

            return Ok(token);
        }
    }
}