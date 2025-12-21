using System.ComponentModel.DataAnnotations;

namespace MediaCollection.Data.Models.User;

public class UserCollectionDbo
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }

    public bool IsPublic { get; set; } = true;

    [MaxLength(50)]
    public string? CollectionType { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public int UserId { get; set; }
    public virtual ApplicationUserDbo User { get; set; } = null!;

    public virtual ICollection<UserCollectionItemDbo> CollectionItems { get; set; } = [];
}