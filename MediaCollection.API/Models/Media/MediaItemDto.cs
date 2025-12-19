namespace MediaCollection.API.Models.Media;

public class MediaItemDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? OriginalTitle { get; set; }
    public string Type { get; set; } = string.Empty;
    public int? Year { get; set; }
    public List<string> Genres { get; set; } = new List<string>();
    public string? Description { get; set; }
    public string? PosterUrl { get; set; }
    public string? PosterUrl2 { get; set; }
    public SeriesInfoDto? SeriesInfo { get; set; }
    public ExternalMetadataDto ExternalMetadata { get; set; } = new ExternalMetadataDto();
    public DateTime CreatedAt { get; set; }
}