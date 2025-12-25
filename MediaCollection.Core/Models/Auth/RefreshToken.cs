namespace MediaCollection.Core.Models.Auth;

public class RefreshToken
{
    public long Id { get; set; }

    public required string Token { get; set; }

    public DateTime Expires { get; set; }

    public bool IsRevoked { get; set; }

    public long UserId { get; set; }
}