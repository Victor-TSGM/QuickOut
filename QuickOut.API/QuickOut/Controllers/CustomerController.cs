using Microsoft.AspNetCore.Mvc;
using QuickOut.Application.Customers;
using QuickOut.Application.Customers.Queries;
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
        public async Task<IActionResult> GetById([FromServices] GetCustomerByIdQueryHanndler query, [FromBody] GetCustomerByIdParams parameters)
        {
            try
            {
                return Ok(await query.Handle(parameters));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

        [HttpPost("authenticateEstabilishment")]
        public async Task<IActionResult> AuthenticateEstabilishment(AuthenticateEstabilishmentCommand command)
        {
            try
            {
                Result<string> result = await commands.Execute(command);

                if(!result.Succeeded)
                {
                    return BadRequest(result.Messages);
                }

                return Ok(result.Data);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
