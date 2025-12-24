using MediaCollection.Core.Models.Enum;
using MediaCollection.Data.Database;
using MediaCollection.Data.Models.User;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaCollection.Data.Models.Media;

/// <summary>
/// Информация медиа продукте
/// </summary>
[Table("media_items", Schema = MediaDbContext.SCHEME)]
[PrimaryKey(nameof(Id))]
public class MediaItemDbo: EntityDboBase
{
    [Required]
    [MaxLength(200)]
    [Column("title")]
    public required string Title { get; set; }

    [MaxLength(200)]
    [Column("original_title")]
    public string? OriginalTitle { get; set; }

    [Column("type")]
    public required MediaType Type { get; set; }

    [Column("year")]
    public int? Year { get; set; }

    [MaxLength(2000)]
    [Column("description")]
    public string? Description { get; set; }

    [MaxLength(500)]
    [Column("poster_url")]
    public string? PosterUrl { get; set; }

    [Column("user_id")]
    public long? UserId { get; set; }

    [Column("series_info_id")]
    public long? SeriesInfoId { get; set; }

    /// <summary>
    /// Сссылка на пользователя
    /// </summary>
    public virtual ApplicationUserDbo? User { get; set; }
    public virtual SeriesInfoDbo? SeriesInfo { get; set; }
    public virtual ICollection<AggregatorsDbo>? Aggregators { get; set; }
}