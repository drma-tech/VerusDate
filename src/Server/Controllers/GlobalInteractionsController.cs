using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using VerusDate.Server.Core;
using VerusDate.Server.Mediator.Queries.GlobalInteraction;
using VerusDate.Shared.ViewModel.Query;

namespace VerusDate.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GlobalInteractionsController : BaseController<GlobalInteractionsController>
    {
        /// <summary>
        /// Recupera um resumo (totais) de todas as interações feitas pelo usuário logado
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("Get")]
        [ProducesResponseType(typeof(GlobalInteractionsVM), 200)]
        public async Task<IActionResult> Get([FromQuery] GlobalInteractionsGetCommand command)
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