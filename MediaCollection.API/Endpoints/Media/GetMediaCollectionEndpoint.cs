using FastEndpoints;
using MediaCollection.API.Models.Media;
using MediaCollection.Core.Abstract;
using MediaCollection.Core.Models.Media;
using IMapper = AutoMapper.IMapper;

namespace MediaCollection.API.Endpoints.Media;

public class GetMediaCollectionEndpoint(IMediaService mediaService, IMapper mapper) : Endpoint<GetMediaCollectionRequest, IEnumerable<MediaItemDto>>
{
    public override void Configure()
    {
        Get("/api/media/{userGuid}");
        AllowAnonymous();
        Summary(s => {
            s.Summary = "Get a user's media content collection";
        });
    }

    public override async Task HandleAsync(GetMediaCollectionRequest request, CancellationToken cancellationToken)
    {
        var mediaCollection = await mediaService.GetUserMediaListAsync(request.UserGuid, cancellationToken);
        var result = mediaCollection.Select(m => mapper.Map<MediaItem, MediaItemDto>(m));
        await Send.OkAsync(result, cancellation: cancellationToken);
    }
}