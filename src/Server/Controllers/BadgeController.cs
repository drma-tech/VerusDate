using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using VerusDate.Server.Core;
using VerusDate.Server.Mediator.Commands.Badge;
using VerusDate.Server.Mediator.Queries.Badge;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BadgeController : BaseController<BadgeController>
    {
        /// <summary>
        /// Recupera os badges do usuário logado
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("Get")]
        [ProducesResponseType(typeof(BadgeVM), 200)]
        public async Task<IActionResult> Get([FromQuery] BadgeGetCommand command)
        {
            try
            {
                var result = await Mediator.Send(command);

                if (result == null)
                    return NotFound();
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, null, command);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Insere um novo badge
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Insert")]
        [ProducesResponseType(typeof(BadgeVM), 200)]
        public async Task<IActionResult> Insert([FromBody] BadgeInsertCommand command)
        {
            try
            {
                var result = await Mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, null, command);
                return BadRequest(ex.Message);
            }
        }
    }
}