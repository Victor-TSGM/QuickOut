using Microsoft.AspNetCore.Mvc;
using QuickOut.Domain.Common.Interfaces;
using QuickOut.Infrastructure.Common;
using System.Security.Claims;

namespace QuickOut.Controllers
{
    public class VicthorController : ControllerBase
    {

        protected readonly VicthotMediator commands;
        protected readonly JwtTokenManager jwtTokenManager;

        public VicthorController(VicthotMediator commands, JwtTokenManager jwtTokenManager)
        {
            this.commands = commands;
            this.jwtTokenManager = jwtTokenManager;
        }

        protected List<int>? GetUserPrivileges()
        {

            string token = null;

            if (HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                token = HttpContext.Request.Headers.First(h => h.Key == "Authorization").Value;
            }

            ClaimsPrincipal claimsPrinciple = jwtTokenManager.ValidateToken(token);

            if (claimsPrinciple.Identity == null)
            {
                return null;
            }

            Claim? userRoleClaim = claimsPrinciple.Claims.FirstOrDefault(s => s.Type == ClaimTypes.Role);


            if (userRoleClaim == null)
            {
                return null;
            }

            UserRole role;

            if (!Enum.TryParse(userRoleClaim.Value, out role))
            {
                return null;
            }

            return RoleHelper.GetPrivilegesFromRole(role);
        }
    }
}
