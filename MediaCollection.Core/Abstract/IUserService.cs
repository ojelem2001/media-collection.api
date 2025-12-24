using MediaCollection.Core.Models.Auth;

namespace MediaCollection.Core.Abstract;

public interface IUserService
{
    public AuthResponse Register(string email, string password, CancellationToken cancellationToken);
    public AuthResponse Login(string email, string password, CancellationToken cancellationToken);
}