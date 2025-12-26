using MediaCollection.Core.Models.Enum;
using MediaCollection.Core.Models.User;

namespace MediaCollection.Core.Models.Media;

/// <summary>
/// Информация медиа продукте
/// </summary>
public class MediaItem
{
    public Guid Guid { get; set; }

    public required string Title { get; set; }

    public string? OriginalTitle { get; set; }

    public required MediaType Type { get; set; }

    public int? Year { get; set; }

    public string? Description { get; set; }

    public string? PosterUrl { get; set; }

    public Guid? UserGuid { get; set; }

    public long IsWatched { get; set; }

    public ApplicationUser? User { get; set; }

    public SeriesInfo? SeriesInfo { get; set; }

    public IEnumerable<Aggregators>? Aggregators { get; set; }

    public DateTime? Updated { get; set; }

    public DateTime? Created { get; set; }
}