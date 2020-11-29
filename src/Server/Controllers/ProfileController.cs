using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VerusDate.Server.Core;
using VerusDate.Server.Core.Helper;
using VerusDate.Server.Mediator.Commands.Profile;
using VerusDate.Server.Mediator.Queries.Profile;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : BaseController<ProfileController>
    {
        /// <summary>
        /// Adiciona um novo perfil
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Add([FromBody] ProfileAddCommand command)
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
        /// Recupera o perfil do usuário logado
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("Get")]
        [ProducesResponseType(typeof(ProfileVM), 200)]
        public async Task<IActionResult> Get([FromQuery] ProfileUserGetCommand command)
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
        /// Recupera o perfil de um usuário específico
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("GetView/{IdUserView}")]
        [ProducesResponseType(typeof(ProfileVM), 200)]
        public async Task<IActionResult> GetView([FromRoute] ProfileViewGetCommand command)
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
        /// Lista os perfis que deram match com o usuário logado
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("ListMatch")]
        [ProducesResponseType(typeof(IEnumerable<ProfileVM>), 200)]
        public async Task<IActionResult> ListMatch([FromRoute] ProfileListMatchCommand command)
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
        /// Lista os perfis que batem com a pesquisa do usuário logado
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("ListSearch")]
        [ProducesResponseType(typeof(IEnumerable<ProfileVM>), 200)]
        public async Task<IActionResult> ListSearch([FromRoute] ProfileListSearchCommand command)
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
        /// Atualiza o perfil do usuário logado
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Update([FromBody] ProfileUpdateCommand command)
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