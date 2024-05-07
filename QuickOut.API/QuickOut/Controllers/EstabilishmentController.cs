using Microsoft.AspNetCore.Mvc;
using QuickOut.Application.Estabilishments;
using QuickOut.Application.Estabilishments.Queries;
using QuickOut.Infrastructure.Common;
using QuickOut.Library;

namespace QuickOut.Controllers
{
    [ApiController]
    [Route("estabilishment")]
    public class EstabilishmentController : VicthorController
    {
        public EstabilishmentController(VicthotMediator commands, JwtTokenManager jwtTokenManager) : base(commands, jwtTokenManager)
        {
        }

        [HttpGet("read")]
        public async Task<IActionResult> ReadEstabilishments(
            [FromServices] ReadEstabilishmentsQueryHandler query,
            [FromQuery] ReadEstabilishmentsParams parameters)
        {
            try
            {
                return Ok(await query.Handle(parameters));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> AddEstabilishment(AddEstabilishmentCommand command)
        {
            try
            {
                Result<Guid> result = await commands.Execute(command);

                if(!result.Succeeded)
                {
                    return BadRequest(result.Messages);
                }

                return Ok(result.Data);
            } catch (Exception ex)
            {
                return BadRequest($"Failed to add {ex.Message}");
            }
        }
        
    }
}