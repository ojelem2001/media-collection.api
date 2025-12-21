using System.ComponentModel.DataAnnotations;

namespace MediaCollection.Data.Models.User;

public class ApplicationUser
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    [Required]
    public Guid UserGuid { get; set; }
    public string PasswordHash { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}