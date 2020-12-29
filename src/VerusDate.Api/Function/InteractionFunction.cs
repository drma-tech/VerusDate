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
using VerusDate.Api.Mediator.Command.Interaction;
using VerusDate.Api.Mediator.Queries.Interaction;
using VerusDate.Server.Mediator.Commands.Interaction;
using VerusDate.Shared.Seed;

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
            ILogger log)
        {
            try
            {
                var command = await JsonSerializer.DeserializeAsync<InteractionGetCommand>(req.Body);

                var result = await _mediator.Send(command, req.HttpContext.RequestAborted);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex, null, req.Query.ToList());
                return new BadRequestObjectResult(ex.Message);
            }
        }

        //[FunctionName("InteractionGetList")]
        //public async Task<IActionResult> GetList(
        //   [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.GET, Route = "Interaction/GetList")] HttpRequest req,
        //   ILogger log)
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
        //   ILogger log)
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
        //   ILogger log)
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
        //   ILogger log)
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
        //  ILogger log)
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
         [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.POST, Route = "Interaction/Blink")] HttpRequest req,
         ILogger log)
        {
            try
            {
                var command = await JsonSerializer.DeserializeAsync<InteractionBlinkCommand>(req.Body);

                var result = await _mediator.Send(command, req.HttpContext.RequestAborted);

                if (result)
                    return new OkObjectResult(result);
                else
                    return new BadRequestResult();
            }
            catch (Exception ex)
            {
                log.LogError(ex, null, req.Query.ToList());
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("InteractionBlock")]
        public async Task<IActionResult> Block(
         [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.POST, Route = "Interaction/Block")] HttpRequest req,
         ILogger log)
        {
            try
            {
                var command = await JsonSerializer.DeserializeAsync<InteractionBlockCommand>(req.Body);

                var result = await _mediator.Send(command, req.HttpContext.RequestAborted);

                if (result)
                    return new OkObjectResult(result);
                else
                    return new BadRequestResult();
            }
            catch (Exception ex)
            {
                log.LogError(ex, null, req.Query.ToList());
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("InteractionDeslike")]
        public async Task<IActionResult> Deslike(
         [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.POST, Route = "Interaction/Deslike")] HttpRequest req,
         ILogger log)
        {
            try
            {
                var command = await JsonSerializer.DeserializeAsync<InteractionDeslikeCommand>(req.Body);

                var result = await _mediator.Send(command, req.HttpContext.RequestAborted);

                if (result)
                    return new OkObjectResult(result);
                else
                    return new BadRequestResult();
            }
            catch (Exception ex)
            {
                log.LogError(ex, null, req.Query.ToList());
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("InteractionLike")]
        public async Task<IActionResult> Like(
         [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.POST, Route = "Interaction/Like")] HttpRequest req,
         ILogger log)
        {
            try
            {
                //var command = await JsonSerializer.DeserializeAsync<InteractionLikeCommand>(req.Body);
                var command = InteractionSeed.GetInteraction<InteractionLikeCommand>().Generate();

                var result = await _mediator.Send(command, req.HttpContext.RequestAborted);

                if (result)
                    return new OkObjectResult(result);
                else
                    return new BadRequestResult();
            }
            catch (Exception ex)
            {
                log.LogError(ex, null, req.Query.ToList());
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("InteractionGenerateChat")]
        public async Task<IActionResult> GenerateChat(
         [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.POST, Route = "Interaction/GenerateChat")] HttpRequest req,
         ILogger log)
        {
            try
            {
                //var command = await JsonSerializer.DeserializeAsync<InteractionGenerateChatCommand>(req.Body);
                var command = InteractionSeed.GetInteraction<InteractionGenerateChatCommand>().Generate();

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