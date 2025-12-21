using MediaCollection.Core.Models.Media;

namespace MediaCollection.Core.Abstract;

public class MediaService(IMediaProvider provider) : IMediaService
{
    public async Task<IEnumerable<MediaItem>> GetUserMediaList(Guid userGuid, CancellationToken cancellationToken)
    {
        return await provider.GetUserMediaList(userGuid, cancellationToken);
    }
}