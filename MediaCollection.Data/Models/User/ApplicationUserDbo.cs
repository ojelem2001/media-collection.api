using MediaCollection.Core.Models.Media;
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
    [Column("username")]
    public string? Username { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(200)]
    [Column("email")]
    public string? Email { get; set; }

    [Required]
    [Column("guid")]
    public Guid Guid { get; set; }

    [Required]
    [Column("password")]
    public string? Password { get; set; }

    public virtual ICollection<MediaItemDbo>? MediaItems { get; set; }
}