using MediaCollection.Core.Models.Media;
using MediaCollection.Data.Models.User;
using Microsoft.EntityFrameworkCore;

namespace MediaCollection.Data.Contexts;

public class MediaDbContext : DbContext
{
    public MediaDbContext(DbContextOptions<MediaDbContext> options) : base(options)
    {
    }

    public DbSet<ApplicationUserDbo> Users { get; set; }
    public DbSet<MediaItemDbo> MediaItems { get; set; }
    public DbSet<UserCollectionDbo> UserCollections { get; set; }
    public DbSet<UserCollectionItemDbo> UserCollectionItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}