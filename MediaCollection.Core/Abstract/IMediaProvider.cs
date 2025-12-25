using MediaCollection.Core.Models.Media;
using MediaCollection.Core.Models.User;

namespace MediaCollection.Core.Abstract;

/// <summary>
/// Media content management provider
/// </summary>
public interface IMediaProvider
{
    /// <summary>
    /// Add media content to user
    /// </summary>
    public Task AddMediaListAsync(IEnumerable<MediaItem> items, CancellationToken cancellationToken);

    /// <summary>
    /// Get user media content collection
    /// </summary>
    public Task<IEnumerable<MediaItem>> GetUserMediaList(Guid userGuid, CancellationToken cancellationToken);
}