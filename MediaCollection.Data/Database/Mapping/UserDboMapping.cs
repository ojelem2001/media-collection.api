using MediaCollection.Data.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediaCollection.Data.Database.Mapping;

public class UserDboMapping : IEntityTypeConfiguration<ApplicationUserDbo>
{
    public void Configure(EntityTypeBuilder<ApplicationUserDbo> builder)
    {
        _ = builder.HasMany(rt => rt.RefreshTokens)
                  .WithOne(u => u.User)
                  .HasForeignKey(rt => rt.UserGuid)
                  .OnDelete(DeleteBehavior.Cascade);
    }
}