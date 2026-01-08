using FastEndpoints;
using MediaCollection.API.Models.Common;
using MediaCollection.API.Models.Media;
using MediaCollection.Core.Abstract;
using MediaCollection.Core.Models.Media;
using IMapper = AutoMapper.IMapper;

namespace MediaCollection.API.Endpoints.MediaCollection;

public class GetMediaEndpoint(IUserMediaService mediaService, IMapper mapper) : Endpoint<MediaRequest, MediaItemDto>
{
    public override void Configure()
    {
        Get("/api/users/{userGuid}/media/{mediaGuid}");
        AllowAnonymous();
        Summary(s => {
            s.Summary = "Get a user's media content collection";
        });
    }

    public override async Task HandleAsync(MediaRequest request, CancellationToken cancellationToken)
    {
        var media = await mediaService.GetMediaAsync(request.MediaGuid, cancellationToken);
        var result = mapper.Map<MediaItem, MediaItemDto>(media);
        await Send.OkAsync(result, cancellation: cancellationToken);
    }
}