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
    public class GamificationController : BaseController<GamificationController>
    {
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromRoute] GamificationGetCommand command)
        {
            try
            {
                command.IdUser = HttpContext.GetUserId();

                var result = await Mediator.Send(command);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError("Get", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetView/{IdUser}")]
        public async Task<IActionResult> GetView([FromRoute] GamificationGetCommand command)
        {
            try
            {
                var result = await Mediator.Send(command);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError("Get", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddDiamond")]
        public async Task<IActionResult> AddDiamond([FromBody] GamificationAddDiamondCommand command)
        {
            try
            {
                command.IdUser = HttpContext.GetUserId();

                var result = await Mediator.Send(command);

                if (result)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                Logger.LogError("AddDiamond", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ExchangeFood")]
        public async Task<IActionResult> ExchangeFood([FromBody] GamificationExchangeFoodCommand command)
        {
            try
            {
                command.IdUser = HttpContext.GetUserId();

                var result = await Mediator.Send(command);

                if (result)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                Logger.LogError("ExchangeFood", ex);
                return BadRequest(ex.Message);
            }
        }
    }
}