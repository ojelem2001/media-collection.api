using System.Text.Json.Serialization;

namespace MediaCollection.API.Models.User;

public class ApplicationUserDto
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("guid")]
    public Guid Guid { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("updated")]
    public DateTime? Updated { get; set; }

    [JsonPropertyName("created")]
    public DateTime? Created { get; set; }

}