using AutoMapper;
using MediaCollection.Core.Abstract;
using MediaCollection.Core.Models.Media;
using MediaCollection.Core.Models.User;
using MediaCollection.Data.Database;
using MediaCollection.Data.Models.User;
using Microsoft.EntityFrameworkCore;

namespace MediaCollection.Data.Providers;

/// <inheritdoc cref="IUserProvider" />
public class UserProvider(MediaDbContext dbContext, IMapper mapper) : IUserProvider
{
    /// <inheritdoc />
    public async Task<ApplicationUser?> GetUserByGuidAsync(Guid userGuid, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Users
                .Where(m => m.Guid == userGuid)
                .FirstOrDefaultAsync(cancellationToken);
        return entity is null ? null : mapper.Map<ApplicationUserDbo, ApplicationUser>(entity);
    }
}
