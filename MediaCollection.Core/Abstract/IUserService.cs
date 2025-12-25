using MediaCollection.Core.Models.Auth;

namespace MediaCollection.Core.Abstract;

/// <summary>
/// User management service
/// </summary>
public interface IUserService
{
    /// <summary>
    /// User management service
    /// </summary>
    public Task<AuthResponse> RegisterAsync(string email, string password, CancellationToken cancellationToken);


    /// <summary>
    /// User management service
    /// </summary>
    public Task<AuthResponse> AuthenticateAsync(string email, string password, CancellationToken cancellationToken);
}