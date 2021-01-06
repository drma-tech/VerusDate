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
using VerusDate.Shared.Seed;

namespace VerusDate.Api.Function
{
    public class GamificationFunction
    {
        private readonly IMediator _mediator;

        public GamificationFunction(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("GamificationListDestaques")]
        public async Task<IActionResult> ListDestaques(
           [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.GET, Route = "Gamification/ListDestaques")] HttpRequest req,
           ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var result = ProfileSeed.GetProfileSearch().Generate(12);

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