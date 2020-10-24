using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using VerusDate.Server.Core;
using VerusDate.Server.Core.Helper;
using VerusDate.Server.Mediator.Commands;
using VerusDate.Server.Mediator.Queries;

namespace VerusDate.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProfileLookingController : BaseController<ProfileLookingController>
    {
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromRoute] ProfileLookingGetCommand command)
        {
            try
            {
                command.IdUser = HttpContext.GetUserId();

                var result = await Mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError("Get", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] ProfileLookingAddCommand command)
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
                Logger.LogError("Add", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] ProfileLookingUpdateCommand command)
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
                Logger.LogError("Update", ex);
                return BadRequest(ex.Message);
            }
        }
    }
}