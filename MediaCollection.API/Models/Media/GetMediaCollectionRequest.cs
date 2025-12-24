using Microsoft.AspNetCore.Mvc;

namespace MediaCollection.API.Models.Media;

public class GetMediaCollectionRequest
{
    [FromRoute(Name = "userGuid")]
    public required Guid UserGuid { get; set; }
}