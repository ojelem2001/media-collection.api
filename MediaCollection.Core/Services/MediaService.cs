using MediaCollection.Core.Models.Media;

namespace MediaCollection.Core.Abstract;

/// <inheritdoc cref="IMediaService" />
public class MediaService(IMediaProvider provider) : IMediaService
{
    /// <inheritdoc />
    public async Task AddMediaListAsync(Guid userGuid, IEnumerable<MediaItem> items, CancellationToken cancellationToken)
    {
        await provider.AddMediaListAsync(userGuid, items, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<MediaItem>> GetUserMediaListAsync(Guid userGuid, CancellationToken cancellationToken)
    {
        return await provider.GetUserMediaList(userGuid, cancellationToken);
    }
}