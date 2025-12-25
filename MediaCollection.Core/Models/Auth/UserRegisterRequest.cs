namespace MediaCollection.Core.Models.Auth;

public class UserRegisterRequest
{
    public required string Name { get; set; }
    public required string Login { get; set; }
    public required string Password { get; set; }
}