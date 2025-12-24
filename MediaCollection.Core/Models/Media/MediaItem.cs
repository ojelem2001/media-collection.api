using MediaCollection.Core.Models.Enum;

namespace MediaCollection.Core.Models.Media;

/// <summary>
/// Информация медиа продукте
/// </summary>
public class MediaItem
{
    public long? Id { get; set; }

    public required string Title { get; set; }

    public string? OriginalTitle { get; set; }

    public required MediaType Type { get; set; }

    public int? Year { get; set; }

    public string? Description { get; set; }

    public string? PosterUrl { get; set; }

    public long? UserId { get; set; }

    public SeriesInfo? SeriesInfo { get; set; }

    public Aggregators? Imdb { get; set; }

    public Aggregators? Letterboxd { get; set; }

    public Aggregators? Kinopoisk { get; set; }

    public DateTime? Updated { get; set; }

    public DateTime? Created { get; set; }
}