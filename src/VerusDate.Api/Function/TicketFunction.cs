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
using VerusDate.Api.Mediator.Command.Ticket;

namespace VerusDate.Api.Function
{
    public class TicketFunction
    {
        private readonly IMediator _mediator;

        public TicketFunction(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[FunctionName("TicketGetList")]
        //public async Task<IActionResult> GetList(
        //    [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.GET, Route = "Ticket/GetList")] HttpRequest req,
        //    ILogger log)
        //{
        //    try
        //    {
        //        var command = await JsonSerializer.DeserializeAsync<TicketGetListCommand>(req.Body);

        //        var result = await _mediator.Send(command, req.HttpContext.RequestAborted);

        //        return new OkObjectResult(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.LogError(ex, null, req.Query.ToList());
        //        return new BadRequestObjectResult(ex.Message);
        //    }
        //}

        //[FunctionName("TicketGetMyVotes")]
        //public async Task<IActionResult> GetMyVotes(
        //    [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.GET, Route = "Ticket/GetMyVotes")] HttpRequest req,
        //    ILogger log)
        //{
        //    try
        //    {
        //        var command = await JsonSerializer.DeserializeAsync<TicketGetMyVotesCommand>(req.Body);

        //        var result = await _mediator.Send(command, req.HttpContext.RequestAborted);

        //        return new OkObjectResult(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.LogError(ex, null, req.Query.ToList());
        //        return new BadRequestObjectResult(ex.Message);
        //    }
        //}

        [FunctionName("TicketInsert")]
        public async Task<IActionResult> Insert(
            [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.POST, Route = "Ticket/Insert")] HttpRequest req,
            ILogger log)
        {
            try
            {
                var command = await JsonSerializer.DeserializeAsync<TicketInsertCommand>(req.Body);

                var result = await _mediator.Send(command, req.HttpContext.RequestAborted);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex, null, req.Query.ToList());
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("TicketVote")]
        public async Task<IActionResult> Vote(
            [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.POST, Route = "Ticket/Vote")] HttpRequest req,
            ILogger log)
        {
            try
            {
                var command = await JsonSerializer.DeserializeAsync<TicketVoteCommand>(req.Body);

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