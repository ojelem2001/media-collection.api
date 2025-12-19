using FastEndpoints;
using MediaCollection.API.Models;

namespace MediaCollection.API.Endpoints.Media;

public class GetMediaEndpoint : Endpoint<GetMediaRequest, MediaItemListResponse>
{

    public override void Configure()
    {
        Get("/api/media");
        Claims("UserId");
    }

    public override async Task HandleAsync(GetMediaRequest req, CancellationToken ct)
    {
        var userId = int.Parse(User.Claims.First(c => c.Type == "UserId").Value);

        throw new NotImplementedException();
    }
}