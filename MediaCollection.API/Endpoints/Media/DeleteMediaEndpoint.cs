using FastEndpoints;
using MediaCollection.API.Models.Media;
using MediaCollection.Core.Abstract;

namespace MediaCollection.API.Endpoints.MediaCollection;

public class DeleteMediaEndpoint(IUserMediaService mediaService) : Endpoint<MediaRequest>
{
    public override void Configure()
    {
        Delete("/api/users/{userGuid}/media/{mediaGuid}");
        Claims("UserGuid");
        Summary(s => {
            s.Summary = "Delete user's media content";
        });
    }

    public override async Task HandleAsync(MediaRequest request, CancellationToken cancellationToken)
    {
        await mediaService.RemoveMediaAsync(request.UserGuid ?? throw new ArgumentNullException(nameof(request.UserGuid)), request.MediaGuid, cancellationToken);
        await Send.OkAsync(cancellation: cancellationToken);
    }
}