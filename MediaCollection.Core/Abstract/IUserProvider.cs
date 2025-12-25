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
}