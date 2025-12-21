namespace MediaCollection.API.Models.Options;

public class MediaDbOptions
{
    public required string ConnectionString { get; set; }
    public required Dictionary<string ,object> ConnectionParams { get; set; }
}