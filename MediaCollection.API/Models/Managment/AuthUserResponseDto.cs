using System.Text.Json.Serialization;

namespace MediaCollection.API.Models.Managment;

public class AuthUserResponseDto
{
    [JsonPropertyName("id")]
    public Guid Guid { get; set; }

    [JsonPropertyName("username")]
    public string? Name { get; set; }
}