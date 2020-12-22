using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core;
using VerusDate.Api.Mediator.Command.Profile;
using VerusDate.Api.Mediator.Queries.Profile;

namespace VerusDate.Api.Function
{
    public class ProfileFunction
    {
        private readonly IMediator _mediator;

        public ProfileFunction(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("ProfileGet")]
        public async Task<IActionResult> Get(
           [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.GET, Route = null)] HttpRequest req,
           ILogger log)
        {
            try
            {
                var result = await _mediator.Send(new ProfileUserGetCommand() { Id = req.Query["Id"] }, req.HttpContext.RequestAborted);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex, null, req.Query.ToList());
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("ProfilePost")]
        public async Task<IActionResult> Post(
            [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.POST, Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                var command = await JsonSerializer.DeserializeAsync<ProfileAddCommand>(req.Body);

                var result = await _mediator.Send(command, req.HttpContext.RequestAborted);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex, null, req.Query.ToList());
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}