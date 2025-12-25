using System.Text.Json.Serialization;

namespace MediaCollection.API.Models.Auth;

public class AuthResponseDto
{
    [JsonPropertyName("token")]
    public string Token { get; set; }

    
    [JsonPropertyName("expires")]
    public DateTime Expires { get; set; }
}