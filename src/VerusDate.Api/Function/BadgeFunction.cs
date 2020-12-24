using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using VerusDate.Api.Core;
using VerusDate.Api.Mediator.Command.Badge;
using VerusDate.Api.Mediator.Queries.Badge;

namespace VerusDate.Api.Function
{
    public class BadgeFunction
    {
        private readonly IMediator _mediator;

        public BadgeFunction(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("BadgeGet")]
        public async Task<IActionResult> Get(
           [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.GET, Route = "Badge/get")] HttpRequest req,
           ILogger log)
        {
            try
            {
                var result = await _mediator.Send(new BadgeGetCommand() { Id = req.Query["Id"] }, req.HttpContext.RequestAborted);

                if (result == null)
                    return new NotFoundResult();
                else
                    return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex, null, req.Query.ToList());
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("BadgePost")]
        public async Task<IActionResult> Post(
            [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.POST, Route = "Badge/post")] HttpRequest req,
            ILogger log)
        {
            try
            {
                var command = await JsonSerializer.DeserializeAsync<BadgeInsertCommand>(req.Body);

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