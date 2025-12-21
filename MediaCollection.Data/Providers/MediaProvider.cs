using AutoMapper;
using MediaCollection.Core.Abstract;
using MediaCollection.Core.Models.Media;
using MediaCollection.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;

namespace MediaCollection.Data.Providers;
public class MediaProvider(MediaDbContext dbContext, IMapper mapper) : IMediaProvider
{
    public async Task<IEnumerable<MediaItem>> GetUserMediaList(Guid userGuid, CancellationToken cancellationToken)
    {
        var mediaCollection = await dbContext.MediaItems.Include(x=>x.User)
                .Where(m => m.User.UserGuid == userGuid)
                .ToListAsync(cancellationToken);
        return mediaCollection.Select(m => mapper.Map<MediaItemDbo, MediaItem>(m));
    }
}
