using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickOut.Application.Users.Commands;
using QuickOut.Infrastructure.Common;
using QuickOut.Library;

namespace QuickOut.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : VicthorController
    {
        private readonly JwtTokenManager jwtTokenManager;
        public AccountController(VicthotMediator commands, JwtTokenManager jwtTokenManager) : base(commands, jwtTokenManager)
        {
            this.jwtTokenManager = jwtTokenManager;
        }

        [HttpPost, AllowAnonymous] 
        public async Task<IActionResult> Login(LoginCommand command)
        {
            try
            {
                Result<LoginResult> response = await commands.Execute(command);

                if(!response.Succeeded)
                {
                    return BadRequest(response.Messages);
                }

                (string jwt, DateTime expiresAt) = jwtTokenManager.NewToken(response.Data.Id, response.Data.UserName, response.Data.UserRole);

                return Ok(new
                {
                    UserId = response.Data.Id,
                    UserName = response.Data.UserName,
                    jwt = jwt,
                    expiresAt = expiresAt,
                    Role = response.Data.UserRole
                });

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("user")]
        public async Task<IActionResult> AddUser(AddUserCommand command)
        {
            try
            {
                Result<Guid> response = await commands.Execute(command);

                if(!response.Succeeded)
                {
                    return BadRequest("Erro ao adicionar usuário");
                }

                return Ok(response.Data);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
