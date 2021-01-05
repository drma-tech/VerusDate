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
using VerusDate.Api.Mediator.Command.Profile;
using VerusDate.Api.Mediator.Queries.Profile;

namespace VerusDate.Api.Function
{
    public class ProfileFunction
    {
        private readonly IMediator _mediator;

        public ProfileFunction(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("ProfileGet")]
        public async Task<IActionResult> Get(
           [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.GET, Route = "Profile/Get")] HttpRequest req,
           ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var command = new ProfileGetCommand
                {
                    IdLoggedUser = req.GetUserId()
                };

                var result = await _mediator.Send(command, source.Token);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex, null, req.Query.ToList());
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("ProfileGetView")]
        public async Task<IActionResult> GetView(
           [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.GET, Route = "Profile/GetView")] HttpRequest req,
           ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var command = new ProfileGetViewCommand()
                {
                    IdLoggedUser = req.GetUserId(),
                    IdUserView = req.Query["Id"]
                };

                var result = await _mediator.Send(command, source.Token);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex, null, req.Query.ToList());
                return new BadRequestObjectResult(ex.Message);
            }
        }

        //[FunctionName("ProfileListMatch")]
        //public async Task<IActionResult> ListMatch(
        //   [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.GET, Route = "Profile/ListMatch")] HttpRequest req,
        //   ILogger log)
        //{
        //    try
        //    {
        //        var result = await _mediator.Send(new ProfileListMatchCommand() { Id = req.Query["Id"] }, req.HttpContext.RequestAborted);

        //        return new OkObjectResult(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.LogError(ex, null, req.Query.ToList());
        //        return new BadRequestObjectResult(ex.Message);
        //    }
        //}

        //[FunctionName("ProfileListMatch")]
        //public async Task<IActionResult> ListSearch(
        //   [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.GET, Route = "Profile/ListMatch")] HttpRequest req,
        //   ILogger log)
        //{
        //    try
        //    {
        //        var result = await _mediator.Send(new ProfileListMatchCommand() { Id = req.Query["Id"] }, req.HttpContext.RequestAborted);

        //        return new OkObjectResult(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.LogError(ex, null, req.Query.ToList());
        //        return new BadRequestObjectResult(ex.Message);
        //    }
        //}

        [FunctionName("ProfileAdd")]
        public async Task<IActionResult> Add(
            [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.POST, Route = "Profile/Add")] HttpRequest req,
            ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var command = await JsonSerializer.DeserializeAsync<ProfileAddCommand>(req.Body);
                //var command = ProfileSeed.GetProfile<ProfileAddCommand>(null).Generate();

                command.SetIds(req.GetUserId());

                var result = await _mediator.Send(command, source.Token);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex, null, req.Query.ToList());
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("ProfileUpdate")]
        public async Task<IActionResult> Update(
            [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.PUT, Route = "Profile/Update")] HttpRequest req,
            ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var command = await JsonSerializer.DeserializeAsync<ProfileUpdateCommand>(req.Body);
                //var command = ProfileSeed.GetProfile<ProfileUpdateCommand>(req.Query["Id"]).Generate();

                command.SetIds(req.GetUserId());

                var result = await _mediator.Send(command, source.Token);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex, null, req.Query.ToList());
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("ProfileUpdateLooking")]
        public async Task<IActionResult> UpdateLooking(
            [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.PUT, Route = "Profile/UpdateLooking")] HttpRequest req,
            ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var command = await JsonSerializer.DeserializeAsync<ProfileUpdateLookingCommand>(req.Body);
                //var command = ProfileSeed.GetProfile<ProfileUpdateLookingCommand>(req.Query["Id"]).Generate();

                command.SetIds(req.GetUserId());

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