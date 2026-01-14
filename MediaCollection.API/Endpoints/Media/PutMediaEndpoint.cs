using FastEndpoints;
using MediaCollection.API.Models.Common;
using MediaCollection.API.Models.Media;
using MediaCollection.API.Validation;
using MediaCollection.Core.Abstract;
using MediaCollection.Core.Models.Media;
using IMapper = AutoMapper.IMapper;

namespace MediaCollection.API.Endpoints.MediaCollection;

public class PutMediaEndpoint(IUserMediaService mediaService, IMapper mapper) : Endpoint<MediaRequest, MediaItemDto>
{
    public override void Configure()
    {
        Put("/api/users/{userGuid}/media/{mediaGuid}");
        Claims("UserGuid");
        PreProcessor<UserGuidPreProcessor>();
        Summary(s => {
            s.Summary = "Update user's media content";
        });
    }

    public override async Task HandleAsync(MediaRequest request, CancellationToken cancellationToken)
    {
        var media = mapper.Map<MediaItemDto, MediaItem>(request.Media ?? throw new ArgumentNullException(nameof(request.Media)));
        var updatedMedia = await mediaService.UpdateMediaAsync(
            request.UserGuid ?? throw new ArgumentNullException(nameof(request.UserGuid)), 
            media, 
            cancellationToken);
        var result = mapper.Map<MediaItem, MediaItemDto>(updatedMedia);
        await Send.OkAsync(result, cancellation: cancellationToken);
    }
}