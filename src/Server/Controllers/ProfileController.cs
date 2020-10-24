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
    public class ProfileController : BaseController<ProfileController>
    {
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromRoute] ProfileUserGetCommand command)
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

        [HttpGet("GetView/{IdUserView}")]
        public async Task<IActionResult> GetView([FromRoute] ProfileViewGetCommand command)
        {
            try
            {
                command.IdUser = HttpContext.GetUserId();

                var result = await Mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError("GetView", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListMatch")]
        public async Task<IActionResult> ListMatch([FromRoute] ProfileListMatchCommand command)
        {
            try
            {
                command.IdUser = HttpContext.GetUserId();

                var result = await Mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError("ListMatch", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListSearch")]
        public async Task<IActionResult> ListSearch([FromRoute] ProfileListSearchCommand command)
        {
            try
            {
                command.IdUser = HttpContext.GetUserId();

                var result = await Mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError("ListSearch", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] ProfileAddCommand command)
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
        public async Task<IActionResult> Update([FromBody] ProfileUpdateCommand command)
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