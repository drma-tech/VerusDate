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

        [FunctionName("StorageUploadPhotoFace")]
        public async Task<IActionResult> UploadPhotoFace(
            [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.POST, Route = "Storage/UploadPhotoFace")] HttpRequest req,
            ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var command = await JsonSerializer.DeserializeAsync<UploadPhotoFaceCommand>(req.Body);

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

        //[FunctionName("StorageUploadPhotoGallery")]
        //public async Task<IActionResult> UploadPhotoGallery(
        //    [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.POST, Route = "Storage/UploadPhotoGallery")] HttpRequest req,
        //    ILogger log, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var command = await JsonSerializer.DeserializeAsync<UploadPhotoGalleryCommand>(req.Body);

        //        var result = await _mediator.Send(command, source.Token);

        //        if (result)
        //            return new OkObjectResult(result);
        //        else
        //            return new BadRequestResult();
        //    }
        //    catch (Exception ex)
        //    {
        //        log.LogError(ex, null, req.Query.ToList());
        //        return new BadRequestObjectResult(ex.Message);
        //    }
        //}

        //[FunctionName("StorageUploadPhotoValidation")]
        //public async Task<IActionResult> UploadPhotoValidation(
        //   [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.POST, Route = "Storage/UploadPhotoValidation")] HttpRequest req,
        //   ILogger log, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var command = await JsonSerializer.DeserializeAsync<UploadPhotoValidationCommand>(req.Body);

        //        var result = await _mediator.Send(command, source.Token);

        //        if (result)
        //            return new OkObjectResult(result);
        //        else
        //            return new BadRequestResult();
        //    }
        //    catch (Exception ex)
        //    {
        //        log.LogError(ex, null, req.Query.ToList());
        //        return new BadRequestObjectResult(ex.Message);
        //    }
        //}
    }
}