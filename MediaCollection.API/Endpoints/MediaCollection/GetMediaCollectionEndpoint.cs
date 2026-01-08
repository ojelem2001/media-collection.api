using FastEndpoints;
using MediaCollection.API.Models.Common;
using MediaCollection.API.Models.MediaCollection;
using MediaCollection.Core.Abstract;
using MediaCollection.Core.Models.Media;
using IMapper = AutoMapper.IMapper;

namespace MediaCollection.API.Endpoints.MediaCollection;

public class GetMediaCollectionEndpoint(IUserMediaService mediaService, IMapper mapper) : Endpoint<GetMediaCollectionRequest, IEnumerable<MediaItemDto>>
{
    public override void Configure()
    {
        Get("/api/users/{userGuid}/media");
        AllowAnonymous();
        Summary(s => {
            s.Summary = "Get a user's media content collection";
        });
    }

    public override async Task HandleAsync(GetMediaCollectionRequest request, CancellationToken cancellationToken)
    {
        var mediaCollection = await mediaService.GetMediaCollectionAsync(request.UserGuid, cancellationToken);
        var result = mediaCollection.Select(m => mapper.Map<MediaItem, MediaItemDto>(m));
        await Send.OkAsync(result, cancellation: cancellationToken);
    }
}