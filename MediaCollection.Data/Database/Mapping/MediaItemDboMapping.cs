using MediaCollection.Core.Models.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediaCollection.Data.Database.Mapping;

public class MediaItemDboMapping : IEntityTypeConfiguration<MediaItemDbo>
{
    public void Configure(EntityTypeBuilder<MediaItemDbo> builder)
    {
        _ = builder
            .HasOne(x => x.Kinopoisk)
            .WithMany(x => x.KinopoiskMediaItems)
            .HasForeignKey(x => x.KinopoiskId);

        _ = builder
            .HasOne(x => x.Letterboxd)
            .WithMany(x => x.LetterboxdMediaItems)
            .HasForeignKey(x => x.LetterboxdId);

        _ = builder
            .HasOne(x => x.Imdb)
            .WithMany(x => x.ImdbMediaItems)
            .HasForeignKey(x => x.ImdbId);

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