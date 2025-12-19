using MediaCollection.Core.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaCollection.Core.Models.Media;

public class MediaItem
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? OriginalTitle { get; set; }

    public MediaType Type { get; set; } = MediaType.Movie;

    public int? Year { get; set; }

    [MaxLength(2000)]
    public string? Description { get; set; }

    [MaxLength(500)]
    public string? PosterUrl { get; set; }

    [MaxLength(500)]
    public string? PosterUrl2 { get; set; }

    [Column(TypeName = "jsonb")]
    public SeriesInfo? SeriesInfo { get; set; }

    [Column(TypeName = "jsonb")]
    public ExternalMetadata ExternalMetadata { get; set; } = new ExternalMetadata();

    public List<string> Genres { get; set; } = new List<string>();

    [Column(TypeName = "jsonb")]
    public Dictionary<string, object>? AdditionalData { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public int UserId { get; set; }
    public virtual ApplicationUser User { get; set; } = null!;

    public virtual ICollection<UserCollectionItem> CollectionItems { get; set; } = new List<UserCollectionItem>();
}