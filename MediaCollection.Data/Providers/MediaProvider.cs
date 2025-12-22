using AutoMapper;
using MediaCollection.Core.Abstract;
using MediaCollection.Core.Models.Media;
using MediaCollection.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace MediaCollection.Data.Providers;
public class MediaProvider(MediaDbContext dbContext, IMapper mapper) : IMediaProvider
{
    public async Task<IEnumerable<MediaItem>> GetUserMediaList(Guid userGuid, CancellationToken cancellationToken)
    {
        var mediaCollection = await dbContext.MediaItems.Include(x=>x.User)
                .Where(m => m.User != null && m.User.Guid == userGuid)
                .ToListAsync(cancellationToken);
        return mediaCollection.Select(m => mapper.Map<MediaItemDbo, MediaItem>(m));
    }
}
