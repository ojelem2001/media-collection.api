using MediaCollection.Core.Models.Options;
using MediaCollection.Data.Models.User;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MediaCollection.Core.Abstract;

public class AuthService(IOptions<JwtSettingsOptions> options) : IAuthService
{
    private JwtSettingsOptions _options = options.Value;
    public string GenerateJwtToken(ApplicationUser user)
    {
        var key = Encoding.UTF8.GetBytes(_options.SecretKey);
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("UserGuid", user.UserGuid.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
            Expires = DateTime.UtcNow.AddDays(7),
            Issuer = _options.Issuer,
            Audience = _options.Audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}