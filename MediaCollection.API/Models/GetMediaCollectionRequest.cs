using Microsoft.AspNetCore.Mvc;

namespace MediaCollection.API.Models;

public class GetMediaCollectionRequest
{
    [FromRoute(Name = "userGuid")]
    public required Guid UserGuid { get; set; }
}