using AutoMapper;
using MediaCollection.Core.Abstract;
using MediaCollection.Core.Models.Media;
using MediaCollection.Core.Models.User;
using MediaCollection.Data.Database;
using MediaCollection.Data.Models.Media;
using Microsoft.EntityFrameworkCore;

namespace MediaCollection.Data.Providers;

/// <inheritdoc cref="IMediaProvider" />
public class MediaProvider(MediaDbContext dbContext, IMapper mapper) : IMediaProvider
{
    /// <inheritdoc />
    public async Task AddMediaListAsync(IEnumerable<MediaItem> items, CancellationToken cancellationToken)
    {
        var entities = items.Select(m => mapper.Map<MediaItem, MediaItemDbo>(m)).ToList();
        _ = dbContext.MediaItems.AddRangeAsync(entities, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<MediaItem>> GetUserMediaList(Guid userGuid, CancellationToken cancellationToken)
    {
        var mediaCollection = await dbContext.MediaItems.Include(x=>x.User)
                .Where(m => m.User != null && m.User.Guid == userGuid)
                .ToListAsync(cancellationToken);
        return mediaCollection.Select(m => mapper.Map<MediaItemDbo, MediaItem>(m));
    }
}
