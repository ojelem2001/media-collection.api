using MediaCollection.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MediaCollection.Data.Interceptors;

public class MediaDbSaveChangesInterceptor: SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        foreach (var entityEntry in eventData.Context?.ChangeTracker.Entries() ?? [])
        {
            if(entityEntry.Entity is EntityDboBase entityBase)
            {
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        entityBase.Created = now;
                        entityBase.Updated = now;
                        break;
                    case EntityState.Modified:
                        entityBase.Updated = now;
                        break;
                }
            }
        }
        return new ValueTask<InterceptionResult<int>>(result);
    }
}