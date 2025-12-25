using MediaCollection.Core.Models.Media;

namespace MediaCollection.Core.Abstract;

/// <summary>
/// Media content management service
/// </summary>
public interface IMediaService
{
    /// <summary>
    /// Add media content to user
    /// </summary>
    public Task AddMediaListAsync(Guid userGuid, IEnumerable<MediaItem> items, CancellationToken cancellationToken);

    /// <summary>
    /// Get user media content collection
    /// </summary>
    public Task<IEnumerable<MediaItem>> GetUserMediaListAsync(Guid userGuid, CancellationToken cancellationToken);
}