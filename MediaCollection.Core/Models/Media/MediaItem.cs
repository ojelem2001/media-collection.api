namespace MediaCollection.Core.Models.Media;

public class MediaItem
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string? OriginalTitle { get; set; }

    public MediaType Type { get; set; }

    public int? Year { get; set; }

    public string? Description { get; set; }

    public string? PosterUrl { get; set; }

    public string? PosterUrl2 { get; set; }

    public SeriesInfo? SeriesInfo { get; set; }

    public ExternalMetadata ExternalMetadata { get; set; }

    public List<string> Genres { get; set; } = new List<string>();

    public Dictionary<string, object>? AdditionalData { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int UserId { get; set; }
}