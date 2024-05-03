using Microsoft.AspNetCore.Mvc;
using QuickOut.Application.Orders.Commands;
using QuickOut.Infrastructure.Common;
using QuickOut.Library;

namespace QuickOut.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderController : VicthorController
    {
        public OrderController(VicthotMediator commands, JwtTokenManager jwtTokenManager) : base(commands, jwtTokenManager)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(AddOrderCommand command)
        {
            try
            {
                Result<Guid> result = await commands.Execute(command);

                if(!result.Succeeded)
                {
                    return BadRequest(result.Messages);
                }

                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}