using System.ComponentModel.DataAnnotations;

namespace MediaCollection.Core.Models.User;

public class UserCollection
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
    public virtual ApplicationUser User { get; set; } = null!;

    public virtual ICollection<UserCollectionItem> CollectionItems { get; set; } = new List<UserCollectionItem>();
}