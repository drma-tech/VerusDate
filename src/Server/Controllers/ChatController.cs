using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VerusDate.Server.Core;
using VerusDate.Server.Mediator.Commands.Chat;
using VerusDate.Server.Mediator.Queries.Chat;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ChatController : BaseController<ChatController>
    {
        /// <summary>
        /// Lista todas as conversas de um determinado chat e marca como lidas todas as conversas do usuário logado deste chat
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("Get")]
        [ProducesResponseType(typeof(IEnumerable<ChatVM>), 200)]
        public async Task<IActionResult> Get([FromQuery] ChatGetCommand command)
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

        /// <summary>
        /// Atualiza o chat no servidor
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Insert")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Insert([FromBody] ChatInsertCommand command)
        {
            try
            {
                var result = await Mediator.Send(command);

                if (result > 0)
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