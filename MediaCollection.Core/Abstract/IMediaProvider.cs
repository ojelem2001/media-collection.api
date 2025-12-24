using MediaCollection.Core.Models.Media;

namespace MediaCollection.Core.Abstract;

/// <summary>
/// Media content management provider
/// </summary>
public interface IMediaProvider
{
    public Task AddMediaListAsync(Guid userGuid, IEnumerable<MediaItem> items, CancellationToken cancellationToken);

    public Task<IEnumerable<MediaItem>> GetUserMediaList(Guid userGuid, CancellationToken cancellationToken);
}