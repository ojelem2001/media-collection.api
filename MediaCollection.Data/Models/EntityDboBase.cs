using System.ComponentModel.DataAnnotations.Schema;

namespace MediaCollection.Data.Models;

/// <summary>
/// Базовая модель
/// </summary>
public abstract class EntityDboBase
{

    [Column("created_at")]
    public DateTime Created { get; set; }

    [Column("updated_at")]
    public DateTime? Updated { get; set; }
}