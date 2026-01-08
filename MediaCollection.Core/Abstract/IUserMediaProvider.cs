using MediaCollection.Core.Models.Media;
namespace MediaCollection.Core.Abstract;

/// <summary>
/// Media content management provider
/// </summary>
public interface IUserMediaProvider
{
    /// <summary>
    /// Get media content
    /// </summary>
    public Task<MediaItem> GetMediaAsync(Guid mediaGuid, CancellationToken cancellationToken);

    /// <summary>
    /// Add media content to user
    /// </summary>
    public Task<MediaItem> AddMediaAsync(MediaItem item, CancellationToken cancellationToken);

    /// <summary>
    /// Update media content
    /// </summary>
    public Task<MediaItem> UpdateMediaAsync(MediaItem item, CancellationToken cancellationToken);

    /// <summary>
    /// Delete media content
    /// </summary>
    public Task DeleteMediaAsync(Guid userGuid, Guid mediaGuid, CancellationToken cancellationToken);

    /// <summary>
    /// Add media content collection to user
    /// </summary>
    public Task AddMediaBatchAsync(IEnumerable<MediaItem> items, CancellationToken cancellationToken);

    /// <summary>
    /// Get user media content collection
    /// </summary>
    public Task<IEnumerable<MediaItem>> GetMediaCollectionAsync(Guid userGuid, CancellationToken cancellationToken);
}