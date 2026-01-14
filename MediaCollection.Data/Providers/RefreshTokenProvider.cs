using AutoMapper;
using MediaCollection.Core.Abstract;
using MediaCollection.Core.Models.Auth;
using MediaCollection.Data.Database;
using MediaCollection.Data.Models.User;
using Microsoft.EntityFrameworkCore;

namespace MediaCollection.Data.Providers;

/// <inheritdoc cref="IRefreshTokenProvider" />
public class RefreshTokenProvider(MediaDbContext dbContext, IMapper mapper) : IRefreshTokenProvider
{
    /// <inheritdoc />
    public async Task RemoveAllAsync(Guid userGuid, CancellationToken cancellationToken)
    {
        var oldTokens = await dbContext.RefreshTokens.Include(x => x.User).Where(x => x.User.Guid == userGuid).ToListAsync(cancellationToken);
        dbContext.RefreshTokens.RemoveRange(oldTokens);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<RefreshToken> CreateAsync(RefreshToken refreshToken, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<RefreshToken, RefreshTokenDbo>(refreshToken);
        _ = dbContext.RefreshTokens.AddAsync(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return mapper.Map<RefreshTokenDbo, RefreshToken>(entity);
    }
}
