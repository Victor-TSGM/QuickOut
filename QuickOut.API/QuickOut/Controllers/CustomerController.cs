using Microsoft.AspNetCore.Mvc;
using QuickOut.Application.Customers;
using QuickOut.Infrastructure.Common;
using QuickOut.Library;

namespace QuickOut.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : VicthorController
    {
        public CustomerController(VicthotMediator commands, JwtTokenManager jwtTokenManager) : base(commands, jwtTokenManager)
        {
        }

        [HttpGet]
        public IActionResult HelloWorkTask()
        {
            return Ok("Hello World");
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomerCommand command)
        {
            try
            {
                Result<Guid> result = await commands.Execute(command);

                if(!result.Succeeded) {
                    return BadRequest(result.Messages);
                }

                return Ok(result.Data);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
