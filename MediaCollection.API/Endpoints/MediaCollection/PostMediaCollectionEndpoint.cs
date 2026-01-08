using FastEndpoints;
using MediaCollection.API.Models.Common;
using MediaCollection.API.Models.MediaCollection;
using MediaCollection.Core.Abstract;
using MediaCollection.Core.Models.Media;
using IMapper = AutoMapper.IMapper;

namespace MediaCollection.API.Endpoints.MediaCollection;

public class PostMediaCollectionEndpoint(IUserMediaService mediaService, IMapper mapper) : Endpoint<PostMediaCollectionRequest>
{
    public override void Configure()
    {
        Post("/api/users/{userGuid}/media/batch");
        Claims("UserGuid");
        Summary(s => {
            s.Summary = "Adding a user's media content collection";
        });
    }

    public override async Task HandleAsync(PostMediaCollectionRequest request, CancellationToken cancellationToken)
    {
        var userGuid = Guid.Parse(User.Claims.First(c => c.Type == "UserGuid").Value);
        if (userGuid != request.UserGuid)
        {
            throw new Exception("Only the owner can add");
        }
        await mediaService.AddMediaBatchAsync(userGuid, request.Media.Select(mapper.Map<MediaItemDto, MediaItem>), cancellationToken);
        await Send.OkAsync(cancellation: cancellationToken);
    }
}