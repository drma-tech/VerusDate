using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VerusDate.Server.Core;
using VerusDate.Server.Mediator.Commands.Ticket;
using VerusDate.Server.Mediator.Queries.Ticket;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TicketController : BaseController<TicketController>
    {
        /// <summary>
        /// Recupera uma lista com todos os tickets existentes
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("GetList")]
        [ProducesResponseType(typeof(IEnumerable<TicketVM>), 200)]
        public async Task<IActionResult> GetList([FromRoute] TicketGetListCommand command)
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
        /// Recupera uma lista com os votos de tickets dados pelo usuário logado
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("GetMyVotes")]
        [ProducesResponseType(typeof(IEnumerable<TicketVoteVM>), 200)]
        public async Task<IActionResult> GetMyVotes([FromRoute] TicketGetMyVotesCommand command)
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
        /// Insere um novo ticket
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Insert")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Insert([FromBody] TicketInsertCommand command)
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

        /// <summary>
        /// Voto do usuário logado em um ticket específico
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("Vote")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Vote([FromBody] TicketVoteCommand command)
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