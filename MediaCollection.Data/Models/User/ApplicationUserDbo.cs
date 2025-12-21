using MediaCollection.Core.Models.Media;
using System.ComponentModel.DataAnnotations;

namespace MediaCollection.Data.Models.User;

public class ApplicationUserDbo
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(200)]
    public string Email { get; set; } = string.Empty;

    [Required]
    public Guid UserGuid { get; set; } = Guid.NewGuid();

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<MediaItemDbo> MediaItems { get; set; } = [];
    public virtual ICollection<UserCollectionDbo> Collections { get; set; } = [];
}