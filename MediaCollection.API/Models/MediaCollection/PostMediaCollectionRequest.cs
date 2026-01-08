using MediaCollection.API.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace MediaCollection.API.Models.MediaCollection;

public class PostMediaCollectionRequest
{
    [FromRoute(Name = "userGuid")]
    public required Guid UserGuid { get; set; }

    [FromBody]
    public required List<MediaItemDto> Media { get; set; }
}