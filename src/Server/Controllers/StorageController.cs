using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using VerusDate.Server.Core;
using VerusDate.Server.Core.Helper;
using VerusDate.Server.Mediator.Commands;

namespace VerusDate.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class StorageController : BaseController<InteractionController>
    {
        [HttpPost("UploadPhotoFace")]
        public async Task<IActionResult> UploadPhotoFace([FromBody] UploadPhotoFaceCommand command)
        {
            try
            {
                command.Id = HttpContext.GetUserId();

                var result = await Mediator.Send(command);

                if (result)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                Logger.LogError("UploadPhotoFace", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UploadPhotoGallery")]
        public async Task<IActionResult> UploadPhotoGallery([FromBody] UploadPhotoGalleryCommand command)
        {
            try
            {
                command.Id = HttpContext.GetUserId();

                var result = await Mediator.Send(command);

                if (result)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                Logger.LogError("UploadPhotoGallery", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UploadPhotoValidation")]
        public async Task<IActionResult> UploadPhotoValidation([FromBody] UploadPhotoValidationCommand command)
        {
            try
            {
                command.Id = HttpContext.GetUserId();

                var result = await Mediator.Send(command);

                if (result)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                Logger.LogError("UploadPhotoValidation", ex);
                return BadRequest(ex.Message);
            }
        }
    }
}