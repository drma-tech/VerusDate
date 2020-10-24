using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using VerusDate.Server.Core;
using VerusDate.Server.Mediator.Commands;
using VerusDate.Server.Mediator.Queries;

namespace VerusDate.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ChatController : BaseController<ChatController>
    {
        [HttpGet("Get/{IdChat}/{IdUser}")]
        public async Task<IActionResult> Get([FromRoute] ChatGetCommand command)
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

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] ChatInsertCommand command)
        {
            try
            {
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
    }
}