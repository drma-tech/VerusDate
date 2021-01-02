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
using VerusDate.Api.Mediator.Command.Chat;
using VerusDate.Api.Mediator.Queries.Chat;

namespace VerusDate.Api.Function
{
    public class ChatFunction
    {
        private readonly IMediator _mediator;

        public ChatFunction(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("ChatGet")]
        public async Task<IActionResult> Get(
           [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.GET, Route = "Chat/Get")] HttpRequest req,
           ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var result = await _mediator.Send(new ChatGetCommand() { IdUserInteraction = req.Query["Id"] }, source.Token);

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

        [FunctionName("ChatSync")]
        public async Task<IActionResult> Sync(
            [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.POST, Route = "Chat/Sync")] HttpRequest req,
            ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var command = await JsonSerializer.DeserializeAsync<ChatSyncCommand>(req.Body, null, source.Token);

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