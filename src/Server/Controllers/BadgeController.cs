using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using VerusDate.Server.Core;
using VerusDate.Server.Core.Helper;
using VerusDate.Server.Mediator.Queries;

namespace VerusDate.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BadgeController : BaseController<BadgeController>
    {
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromRoute] BadgeGetCommand command)
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

        [HttpGet("GetView/{IdUser}")]
        public async Task<IActionResult> GetView([FromRoute] BadgeGetCommand command)
        {
            try
            {
                var result = await Mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError("Get", ex);
                return BadRequest(ex.Message);
            }
        }
    }
}