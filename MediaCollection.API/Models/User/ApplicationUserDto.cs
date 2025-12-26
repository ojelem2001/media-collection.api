using System.Text.Json.Serialization;

namespace MediaCollection.API.Models.User;

public class ApplicationUserDto
{
    [JsonPropertyName("username")]
    public string? Name { get; set; }

    [JsonPropertyName("login")]
    public string? Login { get; set; }

    [JsonPropertyName("guid")]
    public Guid Guid { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("updated")]
    public DateTime? Updated { get; set; }

    [JsonPropertyName("created")]
    public DateTime? Created { get; set; }

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; }

}