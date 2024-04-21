using Microsoft.AspNetCore.Mvc;
using QuickOut.Application.Users;
using QuickOut.Infrastructure.Common;
using QuickOut.Library;

namespace QuickOut.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : VicthorController
    {
        public UserController(VicthotMediator commands, JwtTokenManager jwtTokenManager) : base(commands, jwtTokenManager)
        {
        }

        [HttpGet]
        public IActionResult HelloWorkTask()
        {
            return Ok("Hello World");
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserCommand command)
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
