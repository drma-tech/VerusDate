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
using VerusDate.Api.Mediator.Command.Store;

namespace VerusDate.Api.Function
{
    public class StoreFunction
    {
        private readonly IMediator _mediator;

        public StoreFunction(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("StoreExchangeFood")]
        public async Task<IActionResult> ExchangeFood(
            [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.PATCH, Route = "Store/ExchangeFood")] HttpRequest req,
            ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var command = await JsonSerializer.DeserializeAsync<StoreExchangeFoodCommand>(req.Body, null, source.Token);

                command.Id = req.GetUserId();

                var result = await _mediator.Send(command, source.Token);

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