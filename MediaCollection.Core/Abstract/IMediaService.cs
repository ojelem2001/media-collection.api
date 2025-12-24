using MediaCollection.Core.Models.Media;

namespace MediaCollection.Core.Abstract;

/// <summary>
/// Media content management service
/// </summary>
public interface IMediaService
{
    public Task AddMediaListAsync(Guid userGuid, IEnumerable<MediaItem> items, CancellationToken cancellationToken);
    public Task<IEnumerable<MediaItem>> GetUserMediaListAsync(Guid userGuid, CancellationToken cancellationToken);
}