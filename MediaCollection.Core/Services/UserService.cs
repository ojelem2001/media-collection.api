using MediaCollection.Core.Models.Auth;
using MediaCollection.Core.Models.Options;
using MediaCollection.Core.Models.User;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MediaCollection.Core.Abstract;

/// <inheritdoc cref="IMediaService" />
public class UserService(IUserProvider userProvider, IRefreshTokenProvider refreshTokenProvider, IOptions<JwtSettingsOptions> options) : IUserService
{
    private JwtSettingsOptions _options = options.Value;


    /// <inheritdoc />
    public async Task<RefreshToken> AuthenticateAsync(UserLoginRequest request, CancellationToken cancellationToken)
    {
        var existsUser = await userProvider.GetUserByLoginAsync(request.Login, cancellationToken);
        if (existsUser is null || !BCrypt.Net.BCrypt.Verify(request.Password, existsUser.Password)) throw new Exception("Invalid email or password");

        await refreshTokenProvider.RemoveAllAsync(existsUser.Guid, cancellationToken);
        
        var jwtToken = GenerateJwtToken(existsUser);

        var refreshTokenEntity = new RefreshToken()
        {
            Token = jwtToken,
            UserId = existsUser.Id ?? throw new ArgumentNullException(nameof(existsUser.Id)),
            Expires = DateTime.UtcNow.AddDays(_options.ExpireDays)
        };
        await refreshTokenProvider.CreateAsync(refreshTokenEntity, cancellationToken);
        return refreshTokenEntity;
    }

    /// <inheritdoc />
    public async Task<ApplicationUser> RegisterAsync(UserRegisterRequest request, CancellationToken cancellationToken)
    {
        var existsUser = await userProvider.GetUserByLoginAsync(request.Login, cancellationToken);
        if (existsUser is not null) throw new Exception("Login already registered");

        return await userProvider.CreateAsync(request, cancellationToken);
    }

    private string GenerateJwtToken(ApplicationUser user)
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
                    new Claim("UserGuid", user.Guid.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Login)
                }),
            Expires = DateTime.UtcNow.AddDays(_options.ExpireDays),
            Issuer = _options.Issuer,
            Audience = _options.Audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private int? ValidateJwtToken(string token)
    {
        if (string.IsNullOrEmpty(token))
            return null;

        var secretKey = _options.SecretKey;

        if (string.IsNullOrEmpty(secretKey))
            return null;

        var key = Encoding.UTF8.GetBytes(secretKey);
        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = _options.Issuer,
                ValidateAudience = true,
                ValidAudience = _options.Audience,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(
                jwtToken.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

            return userId;
        }
        catch
        {
            return null;
        }
    }
}