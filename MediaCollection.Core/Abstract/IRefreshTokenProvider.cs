using MediaCollection.Core.Models.Auth;
namespace MediaCollection.Core.Abstract;

public interface IRefreshTokenProvider
{
    public Task RemoveAllAsync(Guid userGuid, CancellationToken cancellationToken);

    public Task<RefreshToken> CreateAsync(RefreshToken refreshToken, CancellationToken cancellationToken);
}