using FastEndpoints;
using MediaCollection.API.Models.Media;
using MediaCollection.Core.Abstract;
using MediaCollection.Core.Models.Media;
using IMapper = AutoMapper.IMapper;

namespace MediaCollection.API.Endpoints.Media;

public class AddMediaCollectionEndpoint(IMediaService mediaService, IMapper mapper) : Endpoint<List<MediaItemDto>>
{

    public override void Configure()
    {
        Post("/api/media");
        Claims("UserGuid");
        Summary(s => {
            s.Summary = "Adding a user's media content collection";
        });
    }

    public override async Task HandleAsync(List<MediaItemDto> items, CancellationToken cancellationToken)
    {
        var userGuid = Guid.Parse(User.Claims.First(c => c.Type == "UserGuid").Value);
        await mediaService.AddMediaListAsync(userGuid, items.Select(mapper.Map<MediaItemDto, MediaItem>), cancellationToken);
        await Send.OkAsync(cancellation: cancellationToken);
    }
}