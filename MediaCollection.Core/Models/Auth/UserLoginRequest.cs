namespace MediaCollection.Core.Models.Auth;

public class UserLoginRequest
{
    public required string Login { get; set; }

    public required string Password { get; set; }
}