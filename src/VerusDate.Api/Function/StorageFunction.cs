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
using VerusDate.Api.Mediator.Command.Store;
using VerusDate.Server.Mediator.Commands.Profile;

namespace VerusDate.Api.Function
{
    public class StorageFunction
    {
        private readonly IMediator _mediator;

        public StorageFunction(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("StorageUploadPhotoGallery")]
        public async Task<IActionResult> UploadPhotoGallery(
            [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.POST, Route = "Storage/UploadPhotoGallery")] HttpRequest req,
            ILogger log)
        {
            try
            {
                var command = await JsonSerializer.DeserializeAsync<UploadPhotoGalleryCommand>(req.Body);

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

        [FunctionName("StorageUploadPhotoValidation")]
        public async Task<IActionResult> UploadPhotoValidation(
           [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.POST, Route = "Storage/UploadPhotoValidation")] HttpRequest req,
           ILogger log)
        {
            try
            {
                var command = await JsonSerializer.DeserializeAsync<UploadPhotoValidationCommand>(req.Body);

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
    }
}