using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using VerusDate.Server.Core;
using VerusDate.Server.Core.Helper;
using VerusDate.Server.Mediator.Queries;

namespace VerusDate.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GlobalInteractionsController : BaseController<GlobalInteractionsController>
    {
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromRoute] GlobalInteractionsGetCommand command)
        {
            try
            {
                command.Id = HttpContext.GetUserId();

                var result = await Mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError("Get", ex);
                return BadRequest(ex.Message);
            }
        }
    }
}