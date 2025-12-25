using MediaCollection.Core.Models.Media;

namespace MediaCollection.Core.Abstract;

/// <inheritdoc cref="IMediaService" />
public class MediaService(IMediaProvider provider, IUserProvider userProvider) : IMediaService
{
    /// <inheritdoc />
    public async Task AddMediaListAsync(Guid userGuid, IEnumerable<MediaItem> items, CancellationToken cancellationToken)
    {
        var user = await userProvider.GetUserByGuidAsync(userGuid, cancellationToken);
        if (user is null)
        {
            throw new Exception($"User with guid '{userGuid}' not found");
        }

        var extendedItems = items.Select(item =>
        {
            item.UserId = user.Id;
            return item;
        }).ToList();
        await provider.AddMediaListAsync(extendedItems, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<MediaItem>> GetUserMediaListAsync(Guid userGuid, CancellationToken cancellationToken)
    {
        return await provider.GetUserMediaList(userGuid, cancellationToken);
    }
}