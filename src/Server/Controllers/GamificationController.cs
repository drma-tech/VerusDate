using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using VerusDate.Server.Core;
using VerusDate.Server.Mediator.Commands.Gamification;
using VerusDate.Server.Mediator.Queries.Gamification;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GamificationController : BaseController<GamificationController>
    {
        /// <summary>
        /// Recupera o gamification do usuário logado
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("Get")]
        [ProducesResponseType(typeof(GamificationVM), 200)]
        public async Task<IActionResult> Get([FromQuery] GamificationGetCommand command)
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
                Logger.LogError(ex, null, command);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Troca maças por diamante
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("ExchangeFood")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> ExchangeFood([FromQuery] GamificationExchangeFoodCommand command)
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
                Logger.LogError(ex, null, command);
                return BadRequest(ex.Message);
            }
        }
    }
}