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
using VerusDate.Api.Mediator.Command.ProfileLooking;
using VerusDate.Api.Mediator.Queries.Profile;

namespace VerusDate.Api.Function
{
    public class ProfileLookingFunction
    {
        private readonly IMediator _mediator;

        public ProfileLookingFunction(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("ProfileLookingGet")]
        public async Task<IActionResult> Get(
           [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.GET, Route = "profileLooking/get")] HttpRequest req,
           ILogger log)
        {
            try
            {
                var result = await _mediator.Send(new ProfileLookingGetCommand() { Id = req.Query["Id"] }, req.HttpContext.RequestAborted);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex, null, req.Query.ToList());
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("ProfileLookingPost")]
        public async Task<IActionResult> Post(
            [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.POST, Route = "profileLooking/post")] HttpRequest req,
            ILogger log)
        {
            try
            {
                var command = await JsonSerializer.DeserializeAsync<ProfileLookingAddCommand>(req.Body);

                var result = await _mediator.Send(command, req.HttpContext.RequestAborted);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex, null, req.Query.ToList());
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("ProfileLookingPut")]
        public async Task<IActionResult> Put(
            [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.PUT, Route = "profileLooking/put")] HttpRequest req,
            ILogger log)
        {
            try
            {
                var command = await JsonSerializer.DeserializeAsync<ProfileLookingUpdateCommand>(req.Body);

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