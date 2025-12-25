using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MediaCollection.API.Models.Auth;

public class UserRegisterResponseDto
{
    [JsonPropertyName("name")]
    [Required]
    public required string Name { get; set; }

    [JsonPropertyName("guid")]
    [Required]
    public required Guid Guid { get; set; }
}