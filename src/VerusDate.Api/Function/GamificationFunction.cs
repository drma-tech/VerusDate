using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using VerusDate.Api.Core;
using VerusDate.Api.Mediator.Queries.Gamification;

namespace VerusDate.Api.Function
{
    public class GamificationFunction
    {
        private readonly IMediator _mediator;

        public GamificationFunction(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("GamificationGet")]
        public async Task<IActionResult> Get(
           [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.GET, Route = "Gamification/get")] HttpRequest req,
           ILogger log)
        {
            try
            {
                var result = await _mediator.Send(new GamificationGetCommand() { Id = req.Query["Id"] }, req.HttpContext.RequestAborted);

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
    }
}