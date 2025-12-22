using MediaCollection.Core.Models.Enum;
using MediaCollection.Core.Models.Media;
using MediaCollection.Data.Database;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaCollection.Data.Models.Media;

/// <summary>
/// Аггрегатор информации о медиа продукте
/// </summary>
[Table("aggregators", Schema = MediaDbContext.SCHEME)]
[PrimaryKey(nameof(Id))]
public class AggregatorsDbo: EntityDboBase
{
    [Column("number")]
    public required string Number { get; set; }

    [Column("type")]
    public AggregatorType Type { get; set; }

    [Column("rating")]
    public decimal? Rating { get; set; }

    [Column("genres", TypeName = "jsonb")]
    public List<string>? Genres { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    public virtual ICollection<MediaItemDbo>? ImdbMediaItems { get; set; }
    public virtual ICollection<MediaItemDbo>? KinopoiskMediaItems { get; set; }
    public virtual ICollection<MediaItemDbo>? LetterboxdMediaItems { get; set; }
}