namespace MediaCollection.API.Models;

public class GetMediaCollectionRequest
{
    public required Guid UserGuid { get; set; }
}