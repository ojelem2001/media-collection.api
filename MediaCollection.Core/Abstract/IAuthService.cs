using MediaCollection.Core.Models.Options;
using MediaCollection.Data.Models.User;

namespace MediaCollection.Core.Abstract;

public interface IAuthService
{
    public string GenerateJwtToken(ApplicationUser user);
}