using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CryptoAnalyticsAndPartfolioTracker.API.Extensions;
using CryptoAnalyticsAndPartfolioTracker.Application.Partfolios;
using CryptoAnalyticsAndPartfolioTracker.Application.Partfolios.Get;
using CryptoAnalyticsAndPartfolioTracker.Application.Partfolios.Import;
using CryptoAnalyticsAndPartfolioTracker.Application.Users.Get;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CryptoAnalyticsAndPartfolioTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartfoliosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PartfoliosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        [Route("me")]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var userId = User.GetUserId();
            var result = await _mediator.Send(new GetPartfolioQuery(userId), cancellationToken);

            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        [Route("import")]
        [RequestSizeLimit(100 * 1024 * 1024)]
        [RequestFormLimits(MultipartBodyLengthLimit = 100 * 1024 * 1024)]
        public async Task<IActionResult> ImportAsync([FromForm] IFormFileCollection files, CancellationToken cancellationToken)
        {
            if (files is null || files.Count is 0)
                return BadRequest("The files are not uploaded");

            var userId = User.GetUserId();
            await _mediator.Send(
                new ImportCommand(userId, files.Select(f =>
                    new FileUpload(
                        f.OpenReadStream(),
                        f.FileName,
                        f.ContentType))),
                        cancellationToken);
            return Ok();
        }
    }
}