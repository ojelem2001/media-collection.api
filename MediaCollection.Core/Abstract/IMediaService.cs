using MediaCollection.Core.Models.Media;

namespace MediaCollection.Core.Abstract;

public interface IMediaService
{
    public Task<IEnumerable<MediaItem>> GetUserMediaList(Guid userGuid, CancellationToken cancellationToken);
}