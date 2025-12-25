namespace MediaCollection.Core.Models.User;

public class ApplicationUser
{
    public long? Id { get; set; }

    public string? Name { get; set; }

    public string? Login { get; set; }

    public Guid Guid { get; set; }

    public string? Password { get; set; }

    public DateTime? Updated { get; set; }

    public DateTime? Created { get; set; }

}