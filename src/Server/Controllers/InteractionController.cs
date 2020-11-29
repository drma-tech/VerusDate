using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VerusDate.Server.Core;
using VerusDate.Server.Mediator.Commands.Interaction;
using VerusDate.Server.Mediator.Queries.Interaction;
using VerusDate.Shared.ViewModel.Command;
using VerusDate.Shared.ViewModel.Query;

namespace VerusDate.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class InteractionController : BaseController<InteractionController>
    {
        /// <summary>
        /// Recupera a interação entre o usuário logado e um usuário específico
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("Get")]
        [ProducesResponseType(typeof(InteractionVM), 200)]
        public async Task<IActionResult> Get([FromQuery] InteractionGetCommand command)
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
        /// Recupera todas as interações do usuário logado
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("GetList")]
        [ProducesResponseType(typeof(IEnumerable<InteractionVM>), 200)]
        public async Task<IActionResult> GetList([FromQuery] InteractionGetListCommand command)
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
        /// Recupera uma lista de perfis do qual o usuário logado deu like
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("GetLikes")]
        [ProducesResponseType(typeof(IEnumerable<ProfileBasicVM>), 200)]
        public async Task<IActionResult> GetLikes([FromQuery] InteractionGetLikesCommand command)
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
        /// Recupera uma lista de perfis do qual o usuário logado deu blink
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("GetBlinks")]
        [ProducesResponseType(typeof(IEnumerable<ProfileBasicVM>), 200)]
        public async Task<IActionResult> GetBlinks([FromQuery] InteractionGetBlinksCommand command)
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
        /// Recupera uma lista de perfis do qual o usuário logado deu match
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("GetNewMatches")]
        [ProducesResponseType(typeof(IEnumerable<ProfileBasicVM>), 200)]
        public async Task<IActionResult> GetNewMatches([FromQuery] InteractionGetNewMatchesCommand command)
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
        /// Recupera lista de chats disponíveis
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("GetChatList")]
        [ProducesResponseType(typeof(IEnumerable<ProfileChatListVM>), 200)]
        public async Task<IActionResult> GetChatList([FromQuery] InteractionGetChatListCommand command)
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
        /// Interage com outro usuário com um blink
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("Blink")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Blink([FromQuery] InteractionBlinkCommand command)
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
        /// Interage com outro usuário com um block
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("Block")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Block([FromQuery] InteractionBlockCommand command)
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
        /// Interage com outro usuário com um deslike
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("Deslike")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Deslike([FromQuery] InteractionDeslikeCommand command)
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
        /// Interage com outro usuário com um block
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("Like")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Like([FromQuery] InteractionLikeCommand command)
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
        /// Gera um chat entre dois usuários
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("GenerateChat")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GenerateChat([FromQuery] InteractionGenerateChatCommand command)
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