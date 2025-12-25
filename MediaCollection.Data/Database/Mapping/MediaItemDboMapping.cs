using MediaCollection.Data.Models.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace MediaCollection.Data.Database.Mapping;

public class MediaItemDboMapping : IEntityTypeConfiguration<MediaItemDbo>
{
    public void Configure(EntityTypeBuilder<MediaItemDbo> builder)
    {
        _ = builder
            .HasMany(x => x.Aggregators)
            .WithOne(x => x.MediaItem)
            .HasForeignKey(x => x.MediaItemId);

        _ = builder
            .HasOne(x => x.User)
            .WithMany(x => x.MediaItems)
            .HasForeignKey(x => x.UserId);

        _ = builder
            .HasOne(x => x.SeriesInfo)
            .WithMany(x => x.MediaItems)
            .HasForeignKey(x => x.SeriesInfoId);
    }
}