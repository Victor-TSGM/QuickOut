using Microsoft.AspNetCore.Mvc;
using QuickOut.Application.Estabilishments;
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