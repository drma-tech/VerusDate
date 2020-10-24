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
    public class TicketController : BaseController<TicketController>
    {
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromRoute] TicketGetListCommand command)
        {
            try
            {
                var result = await Mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError("GetList", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetMyVotes")]
        public async Task<IActionResult> GetMyVotes([FromRoute] TicketGetMyVotesCommand command)
        {
            try
            {
                command.IdUser = HttpContext.GetUserId();

                var result = await Mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError("GetMyVotes", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] TicketInsertCommand command)
        {
            try
            {
                command.IdUserOwner = HttpContext.GetUserId();

                var result = await Mediator.Send(command);

                if (result)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                Logger.LogError("Insert", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Vote")]
        public async Task<IActionResult> Vote([FromBody] TicketVoteCommand command)
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
                Logger.LogError("Vote", ex);
                return BadRequest(ex.Message);
            }
        }
    }
}