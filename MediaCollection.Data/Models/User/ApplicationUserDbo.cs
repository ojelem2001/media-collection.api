using MediaCollection.Data.Models.Media;
using MediaCollection.Data.Database;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaCollection.Data.Models.User;

[Table("users", Schema = MediaDbContext.SCHEME)]
[PrimaryKey(nameof(Id))]
public class ApplicationUserDbo: EntityDboBase
{
    [Required]
    [MaxLength(100)]
    [Column("name")]
    public string? Name { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(200)]
    [Column("login")]
    public string? Login { get; set; }

    [Required]
    [Column("guid")]
    public Guid Guid { get; set; }

    [Required]
    [Column("password")]
    public string? Password { get; set; }

    public virtual ICollection<RefreshTokenDbo>? RefreshTokens { get; set; }
    public virtual ICollection<MediaItemDbo>? MediaItems { get; set; }
}