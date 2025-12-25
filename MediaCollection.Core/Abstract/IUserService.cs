using MediaCollection.Core.Models.Auth;
using MediaCollection.Core.Models.User;

namespace MediaCollection.Core.Abstract;

/// <summary>
/// User management service
/// </summary>
public interface IUserService
{
    /// <summary>
    /// User management service
    /// </summary>
    public Task<ApplicationUser> RegisterAsync(UserRegisterRequest request, CancellationToken cancellationToken);


    /// <summary>
    /// User management service
    /// </summary>
    public Task<RefreshToken> AuthenticateAsync(UserLoginRequest request, CancellationToken cancellationToken);
}