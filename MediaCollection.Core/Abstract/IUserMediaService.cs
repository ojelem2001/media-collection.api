using MediaCollection.Core.Models.Media;

namespace MediaCollection.Core.Abstract;

/// <summary>
/// Media content management service
/// </summary>
public interface IUserMediaService
{
    /// <summary>
    /// Get media content
    /// </summary>
    public Task<MediaItem> GetMediaAsync(Guid mediaGuid, CancellationToken cancellationToken);

    /// <summary>
    /// Update media content
    /// </summary>
    public Task<MediaItem> UpdateMediaAsync(Guid userGuid, MediaItem item, CancellationToken cancellationToken);

    /// <summary>
    /// Delete media content
    /// </summary>
    public Task RemoveMediaAsync(Guid userGuid, Guid mediaGuid, CancellationToken cancellationToken);
    
    /// <summary>
    /// Add media content to user
    /// </summary>
    public Task<MediaItem> AddMediaAsync(MediaItem item, CancellationToken cancellationToken);

    /// <summary>
    /// Add media content to user
    /// </summary>
    public Task AddMediaBatchAsync(IEnumerable<MediaItem> items, CancellationToken cancellationToken);

    /// <summary>
    /// Get user media content collection
    /// </summary>
    public Task<IEnumerable<MediaItem>> GetMediaCollectionAsync(Guid userGuid, CancellationToken cancellationToken);
}