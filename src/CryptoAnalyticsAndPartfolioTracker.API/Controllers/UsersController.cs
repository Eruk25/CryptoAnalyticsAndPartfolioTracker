using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.API.Extensions;
using CryptoAnalyticsAndPartfolioTracker.Application.Users.Get;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CryptoAnalyticsAndPartfolioTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        [Route("me")]
        public async Task<IActionResult> GetProfileAsync(CancellationToken cancellationToken)
        {
            var userId = User.GetUserId();
            var result = await _mediator.Send(new GetProfileQuery(userId), cancellationToken);

            return Ok(result);
        }

    }
}