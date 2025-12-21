namespace MediaCollection.Core.Models.Options;
public class JwtSettingsOptions
{
    public string SecretKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int ExpireDays { get; set; }
}
