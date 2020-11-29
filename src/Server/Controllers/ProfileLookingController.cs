using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using VerusDate.Server.Core;
using VerusDate.Server.Core.Helper;
using VerusDate.Server.Mediator.Commands.ProfileLooking;
using VerusDate.Server.Mediator.Queries.ProfileLooking;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProfileLookingController : BaseController<ProfileController>
    {
        /// <summary>
        /// Adiciona um novo perfil de busca do usuário logado
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Add([FromBody] ProfileLookingAddCommand command)
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
        /// Recupera o perfil de busca do usuário logado
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("Get")]
        [ProducesResponseType(typeof(ProfileLookingVM), 200)]
        public async Task<IActionResult> Get([FromRoute] ProfileLookingGetCommand command)
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
        /// Atualiza o perfil de busca do usuário logado
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Update([FromBody] ProfileLookingUpdateCommand command)
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