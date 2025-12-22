using System.ComponentModel.DataAnnotations.Schema;

namespace MediaCollection.Data.Models;

/// <summary>
/// Базовая модель
/// </summary>
public abstract class EntityDboBase
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public long Id { get; set; }

    [Column("created_at")]
    public DateTime Created { get; set; }

    [Column("updated_at")]
    public DateTime? Updated { get; set; }
}