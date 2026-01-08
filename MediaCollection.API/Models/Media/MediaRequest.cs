using MediaCollection.API.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace MediaCollection.API.Models.Media;

public class MediaRequest
{
    [FromRoute(Name = "userGuid")]
    public Guid? UserGuid { get; set; }

    [FromRoute(Name = "mediaGuid")]
    public required Guid MediaGuid { get; set; }

    [FromBody]
    public MediaItemDto? Media { get; set; }
}