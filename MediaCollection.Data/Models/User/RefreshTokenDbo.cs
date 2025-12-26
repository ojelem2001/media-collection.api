using MediaCollection.Data.Database;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaCollection.Data.Models.User;

[Table("refresh_tokens", Schema = MediaDbContext.SCHEME)]
[PrimaryKey(nameof(Id))]
public class RefreshTokenDbo : EntityDboBase
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public long Id { get; set; }

    [Column("token")]
    public required string Token { get; set; }

    [Column("expires")]
    public DateTime Expires { get; set; }

    [Column("is_revoked")]
    public bool IsRevoked { get; set; }

    [Column("user_guid")]
    public Guid UserGuid { get; set; }
    public required ApplicationUserDbo User { get; set; }
}