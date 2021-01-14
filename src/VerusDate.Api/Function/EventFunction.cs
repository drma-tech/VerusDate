using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core;
using VerusDate.Api.Seed;

namespace VerusDate.Api.Function
{
    public class EventFunction
    {
        private readonly IMediator _mediator;

        public EventFunction(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("EventGetAll")]
        public async Task<IActionResult> GetAll(
           [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.GET, Route = "Event/GetAll")] HttpRequest req,
           ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var result = EventSeed.GetEventVM().Generate(5);

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