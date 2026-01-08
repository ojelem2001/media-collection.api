using MediaCollection.Core.Models.Media;

namespace MediaCollection.Core.Abstract;

/// <inheritdoc cref="IUserMediaService" />
public class UserMediaService(IUserMediaProvider provider, IUserProvider userProvider) : IUserMediaService
{
    /// <inheritdoc />
    public async Task AddMediaBatchAsync(Guid userGuid, IEnumerable<MediaItem> items, CancellationToken cancellationToken)
    {
        var user = await userProvider.GetUserByGuidAsync(userGuid, cancellationToken);
        if (user is null)
        {
            throw new Exception($"User with guid '{userGuid}' not found");
        }

        var extendedItems = items.Select(item =>
        {
            item.UserGuid = user.Guid;
            return item;
        }).ToList();
        await provider.AddMediaBatchAsync(extendedItems, cancellationToken);
    }

    public async Task<MediaItem> AddMediaAsync(MediaItem item, CancellationToken cancellationToken)
    {
        return await provider.AddMediaAsync(item, cancellationToken);
    }

    public async Task<MediaItem> GetMediaAsync(Guid mediaGuid, CancellationToken cancellationToken)
    {
        return await provider.GetMediaAsync(mediaGuid, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<MediaItem>> GetMediaCollectionAsync(Guid userGuid, CancellationToken cancellationToken)
    {
        return await provider.GetMediaCollectionAsync(userGuid, cancellationToken);
    }

    public async Task RemoveMediaAsync(Guid userGuid, Guid mediaGuid, CancellationToken cancellationToken)
    {
        await provider.DeleteMediaAsync(userGuid, mediaGuid, cancellationToken);
    }

    public async Task<MediaItem> UpdateMediaAsync(Guid userGuid, MediaItem item, CancellationToken cancellationToken)
    {
        return await provider.UpdateMediaAsync(item, cancellationToken);
    }
}