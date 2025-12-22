using MediaCollection.Core.Models.Enum;
using MediaCollection.Data.Database;
using MediaCollection.Data.Models;
using MediaCollection.Data.Models.Media;
using MediaCollection.Data.Models.User;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaCollection.Core.Models.Media;

/// <summary>
/// Информация медиа продукте
/// </summary>
[Table("media_item", Schema = MediaDbContext.SCHEME)]
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

    [Column("imdb_id")]
    public long? ImdbId { get; set; }

    [Column("letterboxd_id")]
    public long? LetterboxdId { get; set; }

    [Column("kinopoisk_id")]
    public long? KinopoiskId { get; set; }

    /// <summary>
    /// Сссылка на пользователя
    /// </summary>
    public virtual ApplicationUserDbo? User { get; set; }
    public virtual SeriesInfoDbo? SeriesInfo { get; set; }
    public virtual AggregatorsDbo? Imdb { get; set; }
    public virtual AggregatorsDbo? Kinopoisk { get; set; }
    public virtual AggregatorsDbo? Letterboxd { get; set; }
}