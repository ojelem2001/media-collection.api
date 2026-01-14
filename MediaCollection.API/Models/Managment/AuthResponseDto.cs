using MediaCollection.API.Models.Managment;
using System.Text.Json.Serialization;

namespace MediaCollection.API.Models.Auth;

public class AuthResponseDto
{
    [JsonPropertyName("token")]
    public string Token { get; set; }

    [JsonPropertyName("expires")]
    public DateTime Expires { get; set; }

    [JsonPropertyName("user")]
    public AuthUserResponseDto User { get; set; }
}