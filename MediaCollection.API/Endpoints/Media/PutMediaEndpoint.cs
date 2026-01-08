using FastEndpoints;
using MediaCollection.API.Models.Common;
using MediaCollection.API.Models.Media;
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
        Summary(s => {
            s.Summary = "Get a user's media content collection";
        });
    }

    public override async Task HandleAsync(MediaRequest request, CancellationToken cancellationToken)
    {
        var media = mapper.Map<MediaItemDto, MediaItem>(request.Media ?? throw new ArgumentNullException(nameof(request.Media)));
        var userGuid = Guid.Parse(User.Claims.First(c => c.Type == "UserGuid").Value);
        if (userGuid != request.UserGuid || userGuid != media.UserGuid)
        {
            throw new Exception("Only the owner can modify media");
        }
        var updatedMedia = await mediaService.UpdateMediaAsync(
            request.UserGuid ?? throw new ArgumentNullException(nameof(request.UserGuid)), 
            media, 
            cancellationToken);
        var result = mapper.Map<MediaItem, MediaItemDto>(updatedMedia);
        await Send.OkAsync(result, cancellation: cancellationToken);
    }
}