using System.Text.Json.Serialization;

namespace MediaCollection.API.Models.User;

public class ApplicationUserDto
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

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

}