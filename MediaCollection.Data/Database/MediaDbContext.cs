using MediaCollection.Core.Models.Media;
using MediaCollection.Data.Database.Mapping;
using MediaCollection.Data.Models.Media;
using MediaCollection.Data.Models.User;
using Microsoft.EntityFrameworkCore;

namespace MediaCollection.Data.Database;

public class MediaDbContext : DbContext
{
    public const string SCHEME = "app";
    public MediaDbContext(DbContextOptions<MediaDbContext> options) : base(options)
    {
    }

    public DbSet<ApplicationUserDbo> Users { get; set; }
    public DbSet<MediaItemDbo> MediaItems { get; set; }
    public DbSet<AggregatorsDbo> Aggregators { get; set; }
    public DbSet<SeriesInfoDbo> SeriesInfo { get; set; }
    public DbSet<RefreshTokenDbo> RefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.ApplyConfiguration(new MediaItemDboMapping());
        _ = modelBuilder.ApplyConfiguration(new UserDboMapping());
    }
}