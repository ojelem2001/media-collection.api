using FastEndpoints;
using MediaCollection.API.Models.Common;
using MediaCollection.API.Validation;
using MediaCollection.Core.Abstract;
using MediaCollection.Core.Models.Media;
using IMapper = AutoMapper.IMapper;

namespace MediaCollection.API.Endpoints.MediaCollection;

public class PostMediaCollectionEndpoint(IUserMediaService mediaService, IMapper mapper) : Endpoint<List<MediaItemDto>>
{
    public override void Configure()
    {
        Post("/api/users/{userGuid}/media/batch");
        Claims("UserGuid");
        PreProcessor<UserGuidPreProcessor>();
        Summary(s => {
            s.Summary = "Adding a user's media content collection";
        });
    }

    public override async Task HandleAsync(List<MediaItemDto> media, CancellationToken cancellationToken)
    {
        var userGuid = Route<Guid>("userGuid");
        await mediaService.AddMediaBatchAsync(userGuid, media.Select(mapper.Map<MediaItemDto, MediaItem>), cancellationToken);
        await Send.OkAsync(cancellation: cancellationToken);
    }
}