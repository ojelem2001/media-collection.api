using MediaCollection.Core.Models.Auth;
using MediaCollection.Core.Models.User;

namespace MediaCollection.Core.Abstract;

/// <summary>
/// User management provider
/// </summary>
public interface IUserProvider
{
    /// <summary>
    /// Get user by guid
    /// </summary>
    public Task<ApplicationUser?> GetUserByGuidAsync(Guid userGuid, CancellationToken cancellationToken);

    /// <summary>
    /// Get user by login
    /// </summary>
    public Task<ApplicationUser?> GetUserByLoginAsync(string login, CancellationToken cancellationToken);

    /// <summary>
    /// Create new user
    /// </summary>
    public Task<ApplicationUser> CreateAsync(UserRegisterRequest request, CancellationToken cancellationToken);
}