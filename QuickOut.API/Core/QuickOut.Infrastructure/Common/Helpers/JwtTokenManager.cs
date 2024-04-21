using System.IdentityModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuickOut.Domain.Common.Interfaces;

public class JwtTokenManager
{
    private readonly byte[] _secret;
    private readonly String _issuer;
    private readonly String _audience;
    private readonly JwtSecurityTokenHandler _tokenHandler;

    public JwtTokenManager(IConfiguration configuration)
    {
        _tokenHandler = new JwtSecurityTokenHandler();

        IConfigurationSection jwt = configuration.GetSection("JWT");

        _issuer = jwt.GetSection("ValidIssuer").Value;
        _audience = jwt.GetSection("ValidAudience").Value;
        _secret = Encoding.UTF8.GetBytes(jwt.GetSection("Secret").Value);
    }

    public (string, DateTime) NewToken(Guid userId, string userName, UserRole userRole)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name, userName),
            new Claim(ClaimTypes.Role, userRole.ToString())
        };

        SecurityToken token = _tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(9),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256
            )
        });

        return (_tokenHandler.WriteToken(token), token.ValidTo);
    }

    public ClaimsPrincipal ValidateToken(string token)
    {
        return _tokenHandler.ValidateToken(token,
            new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(_secret),
                ValidateLifetime = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);
    }
}