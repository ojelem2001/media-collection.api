using AutoMapper;
using MediaCollection.Core.Abstract;
using MediaCollection.Core.Models.Media;
using MediaCollection.Data.Database;
using MediaCollection.Data.Models.Media;
using Microsoft.EntityFrameworkCore;

namespace MediaCollection.Data.Providers;

/// <inheritdoc cref="IUserMediaProvider" />
public class UserMediaProvider(MediaDbContext dbContext, IMapper mapper) : IUserMediaProvider
{
    /// <inheritdoc />
    public async Task<MediaItem> GetMediaAsync(Guid mediaGuid, CancellationToken cancellationToken)
    {
        var entity = await dbContext.MediaItems
            .Include(x => x.User)
            .Include(x => x.Aggregators)
            .Include(x => x.SeriesInfo)
            .Where(m => m.User != null && m.Guid == mediaGuid)
            .FirstOrDefaultAsync(cancellationToken);
        
        if (entity == null)
        {
            throw new Exception($"Media {mediaGuid} not found");
        }
        return mapper.Map<MediaItemDbo, MediaItem>(entity);
    }

    public async Task<MediaItem> AddMediaAsync(MediaItem item, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<MediaItem, MediaItemDbo>(item);
        _ = dbContext.MediaItems.AddAsync(entity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return mapper.Map<MediaItemDbo, MediaItem>(entity);
    }

    /// <inheritdoc />
    public async Task AddMediaBatchAsync(IEnumerable<MediaItem> items, CancellationToken cancellationToken)
    {
        var entities = items.Select(mapper.Map<MediaItem, MediaItemDbo>).ToList();

        var entityKeys = entities
              .Select(e => $"{e.OriginalTitle}|{e.Year}|{e.Type}")
              .Distinct()
              .ToList();

        var existingKeys = await dbContext.MediaItems
            .Where(m => m.UserGuid == entities.First().UserGuid)
            .Select(m => $"{m.OriginalTitle}|{m.Year}|{m.Type}")
            .ToListAsync(cancellationToken);

        var duplicates = entityKeys.Where(existingKeys.Contains).ToList();

        if (duplicates.Any())
        {
            var duplicateMessages = duplicates
            .Select(key =>
            {
                var parts = key.Split('|');
                return $"'{parts[0]}' ({parts[1]})";
            });

            throw new InvalidOperationException(
                $"Duplicate media found: {string.Join(", ", duplicateMessages)}");
        }

        _ = dbContext.MediaItems.AddRangeAsync(entities, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteMediaAsync(Guid userGuid, Guid mediaGuid, CancellationToken cancellationToken)
    {
        var entity = await dbContext.MediaItems.FirstOrDefaultAsync(x => x.Guid == mediaGuid && x.UserGuid == userGuid);

        if (entity == null)
        {
            throw new Exception($"Media {mediaGuid} not found for user {userGuid}");
        }
        dbContext.MediaItems.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<MediaItem>> GetMediaCollectionAsync(Guid userGuid, CancellationToken cancellationToken)
    {
        var mediaCollection = await dbContext.MediaItems
            .Include(x => x.User)
            .Include(x => x.Aggregators)
            .Include(x => x.SeriesInfo)
            .Where(m => m.User != null && m.User.Guid == userGuid)
            .ToListAsync(cancellationToken);
        return mediaCollection.Select(m => mapper.Map<MediaItemDbo, MediaItem>(m));
    }

    public async Task<MediaItem> UpdateMediaAsync(MediaItem item, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<MediaItem, MediaItemDbo>(item);
        dbContext.Attach(entity);
        dbContext.Entry(entity).State = EntityState.Modified;
        await dbContext.SaveChangesAsync(cancellationToken);
        return mapper.Map<MediaItemDbo, MediaItem>(entity);
    }
}
