using MediaCollection.Core.Models.Media;

namespace MediaCollection.Core.Abstract;

/// <inheritdoc cref="IUserMediaService" />
public class UserMediaService(IUserMediaProvider provider) : IUserMediaService
{
    /// <inheritdoc />
    public async Task AddMediaBatchAsync(IEnumerable<MediaItem> items, CancellationToken cancellationToken)
    {
        await provider.AddMediaBatchAsync(items, cancellationToken);
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