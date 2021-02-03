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
using VerusDate.Api.Mediator.Command.Interaction;
using VerusDate.Api.Mediator.Queries.Interaction;
using VerusDate.Server.Mediator.Commands.Interaction;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Function
{
    public class InteractionFunction
    {
        private readonly IMediator _mediator;

        public InteractionFunction(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("InteractionGet")]
        public async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.GET, Route = "Interaction/Get")] HttpRequest req,
            ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var request = req.BuildRequestQuery<InteractionGetCommand, InteractionModel>();

                var result = await _mediator.Send(request, source.Token);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex, null, req.Query.ToList());
                return new BadRequestObjectResult(ex.ProcessException());
            }
        }

        //[FunctionName("InteractionGetList")]
        //public async Task<IActionResult> GetList(
        //   [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.GET, Route = "Interaction/GetList")] HttpRequest req,
        //   ILogger log, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var command = await JsonSerializer.DeserializeAsync<InteractionGetListCommand>(req.Body);

        //        var result = await _mediator.Send(command, req.HttpContext.RequestAborted);

        //        return new OkObjectResult(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.LogError(ex, null, req.Query.ToList());
        //        return new BadRequestObjectResult(ex.Message);
        //    }
        //}

        //[FunctionName("InteractionGetLikes")]
        //public async Task<IActionResult> GetLikes(
        //   [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.GET, Route = "Interaction/GetLikes")] HttpRequest req,
        //   ILogger log, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var command = await JsonSerializer.DeserializeAsync<InteractionGetLikesCommand>(req.Body);

        //        var result = await _mediator.Send(command, req.HttpContext.RequestAborted);

        //        return new OkObjectResult(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.LogError(ex, null, req.Query.ToList());
        //        return new BadRequestObjectResult(ex.Message);
        //    }
        //}

        //[FunctionName("InteractionGetBlinks")]
        //public async Task<IActionResult> GetBlinks(
        //   [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.GET, Route = "Interaction/GetBlinks")] HttpRequest req,
        //   ILogger log, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var command = await JsonSerializer.DeserializeAsync<InteractionGetBlinksCommand>(req.Body);

        //        var result = await _mediator.Send(command, req.HttpContext.RequestAborted);

        //        return new OkObjectResult(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.LogError(ex, null, req.Query.ToList());
        //        return new BadRequestObjectResult(ex.Message);
        //    }
        //}

        //[FunctionName("InteractionGetNewMatches")]
        //public async Task<IActionResult> GetNewMatches(
        //   [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.GET, Route = "Interaction/GetNewMatches")] HttpRequest req,
        //   ILogger log, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var command = await JsonSerializer.DeserializeAsync<InteractionGetNewMatchesCommand>(req.Body);

        //        var result = await _mediator.Send(command, req.HttpContext.RequestAborted);

        //        return new OkObjectResult(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.LogError(ex, null, req.Query.ToList());
        //        return new BadRequestObjectResult(ex.Message);
        //    }
        //}

        //[FunctionName("InteractionGetChatList")]
        //public async Task<IActionResult> GetChatList(
        //  [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.GET, Route = "Interaction/GetChatList")] HttpRequest req,
        //  ILogger log, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var command = await JsonSerializer.DeserializeAsync<InteractionGetChatListCommand>(req.Body);

        //        var result = await _mediator.Send(command, req.HttpContext.RequestAborted);

        //        return new OkObjectResult(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.LogError(ex, null, req.Query.ToList());
        //        return new BadRequestObjectResult(ex.Message);
        //    }
        //}

        [FunctionName("InteractionBlink")]
        public async Task<IActionResult> Blink(
            [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.PUT, Route = "Interaction/Blink")] HttpRequest req,
            ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var request = await req.BuildRequestCommand<InteractionBlinkCommand>(source.Token);

                var result = await _mediator.Send(request, source.Token);

                if (result)
                    return new OkObjectResult(result);
                else
                    return new BadRequestResult();
            }
            catch (Exception ex)
            {
                log.LogError(ex, null, req.Query.ToList());
                return new BadRequestObjectResult(ex.ProcessException());
            }
        }

        [FunctionName("InteractionBlock")]
        public async Task<IActionResult> Block(
            [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.PUT, Route = "Interaction/Block")] HttpRequest req,
            ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var request = await req.BuildRequestCommand<InteractionBlockCommand>(source.Token);

                var result = await _mediator.Send(request, source.Token);

                if (result)
                    return new OkObjectResult(result);
                else
                    return new BadRequestResult();
            }
            catch (Exception ex)
            {
                log.LogError(ex, null, req.Query.ToList());
                return new BadRequestObjectResult(ex.ProcessException());
            }
        }

        [FunctionName("InteractionDeslike")]
        public async Task<IActionResult> Deslike(
            [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.PUT, Route = "Interaction/Deslike")] HttpRequest req,
            ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var request = await req.BuildRequestCommand<InteractionDeslikeCommand>(source.Token);

                var result = await _mediator.Send(request, source.Token);

                if (result)
                    return new OkObjectResult(result);
                else
                    return new BadRequestResult();
            }
            catch (Exception ex)
            {
                log.LogError(ex, null, req.Query.ToList());
                return new BadRequestObjectResult(ex.ProcessException());
            }
        }

        [FunctionName("InteractionLike")]
        public async Task<IActionResult> Like(
            [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.PUT, Route = "Interaction/Like")] HttpRequest req,
            ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var request = await req.BuildRequestCommand<InteractionLikeCommand>(source.Token);

                var result = await _mediator.Send(request, source.Token);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex, null, req.Query.ToList());
                return new BadRequestObjectResult(ex);
            }
        }

        [FunctionName("InteractionGenerateChat")]
        public async Task<IActionResult> GenerateChat(
            [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.PUT, Route = "Interaction/GenerateChat")] HttpRequest req,
            ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var request = await req.BuildRequestCommand<InteractionGenerateChatCommand>(source.Token);

                var result = await _mediator.Send(request, source.Token);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex, null, req.Query.ToList());
                return new BadRequestObjectResult(ex.ProcessException());
            }
        }
    }
}