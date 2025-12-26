using MediaCollection.Data.Database;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaCollection.Data.Models.Media;

/// <summary>
/// Информация о сериале
/// </summary>
[Table("series_info", Schema = MediaDbContext.SCHEME)]
[PrimaryKey(nameof(Id))]
public class SeriesInfoDbo: EntityDboBase
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public long Id { get; set; }

    [Column("seasons")]
    public int? Seasons { get; set; }

    [Column("episodes")]
    public int? Episodes { get; set; }

    [Column("end_year")]
    public int? EndYear { get; set; }

    public virtual ICollection<MediaItemDbo>? MediaItems { get; set; }
}