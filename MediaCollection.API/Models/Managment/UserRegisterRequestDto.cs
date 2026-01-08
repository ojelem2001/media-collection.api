using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MediaCollection.API.Models.Auth;

public class UserRegisterRequestDto
{
    [JsonPropertyName("name")]
    [Required]
    public required string Name { get; set; }

    [JsonPropertyName("login")]
    [Required]
    public required string Login { get; set; }

    [JsonPropertyName("password")]
    [Required]
    public required string Password { get; set; }
}