using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using VerusDate.Server.Core;
using VerusDate.Server.Core.Helper;
using VerusDate.Server.Mediator.Commands;
using VerusDate.Server.Mediator.Queries;

namespace VerusDate.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class InteractionController : BaseController<InteractionController>
    {
        [HttpGet("Get/{IdUserInteraction}")]
        public async Task<IActionResult> Get([FromRoute] InteractionGetCommand command)
        {
            try
            {
                command.IdUser = HttpContext.GetUserId();

                var result = await Mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError("Get", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromRoute] InteractionGetListCommand command)
        {
            try
            {
                command.IdUser = HttpContext.GetUserId();

                var result = await Mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError("GetList", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetLikes")]
        public async Task<IActionResult> GetLikes([FromRoute] InteractionGetLikesCommand command)
        {
            try
            {
                command.IdUser = HttpContext.GetUserId();

                var result = await Mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError("GetLikes", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetBlinks")]
        public async Task<IActionResult> GetBlinks([FromRoute] InteractionGetBlinksCommand command)
        {
            try
            {
                command.IdUser = HttpContext.GetUserId();

                var result = await Mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError("GetBlinks", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetNewMatches")]
        public async Task<IActionResult> GetNewMatches([FromRoute] InteractionGetNewMatchesCommand command)
        {
            try
            {
                command.IdUser = HttpContext.GetUserId();

                var result = await Mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError("GetNewMatches", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetChatList")]
        public async Task<IActionResult> GetChatList([FromRoute] InteractionGetChatListCommand command)
        {
            try
            {
                command.IdUser = HttpContext.GetUserId();

                var result = await Mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError("GetChatList", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Blink")]
        public async Task<IActionResult> Blink([FromBody] InteractionBlinkCommand command)
        {
            try
            {
                command.IdUser = HttpContext.GetUserId();

                var result = await Mediator.Send(command);

                if (result)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                Logger.LogError("Blink", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Block")]
        public async Task<IActionResult> Block([FromBody] InteractionBlockCommand command)
        {
            try
            {
                command.IdUser = HttpContext.GetUserId();

                var result = await Mediator.Send(command);

                if (result)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                Logger.LogError("Block", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Deslike")]
        public async Task<IActionResult> Deslike([FromBody] InteractionDeslikeCommand command)
        {
            try
            {
                command.IdUser = HttpContext.GetUserId();

                var result = await Mediator.Send(command);

                if (result)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                Logger.LogError("Deslike", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Like")]
        public async Task<IActionResult> Like([FromBody] InteractionLikeCommand command)
        {
            try
            {
                command.IdUser = HttpContext.GetUserId();

                var result = await Mediator.Send(command);

                if (result)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                Logger.LogError("Like", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("GenerateChat")]
        public async Task<IActionResult> GenerateChat([FromBody] InteractionGenerateChatCommand command)
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
                Logger.LogError("GenerateChat", ex);
                return BadRequest(ex.Message);
            }
        }
    }
}