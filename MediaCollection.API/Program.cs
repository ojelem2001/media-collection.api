using FastEndpoints;
using MediaCollection.API;
using MediaCollection.API.Models.Options;
using MediaCollection.Core.Models.Options;
using MediaCollection.Data.Contexts;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

services.AddApplicationServices(configuration);

services.AddFastEndpoints();
services.AddSwaggerDocument(settings =>
{
    settings.Title = "Media Collection API";
    settings.Version = "v1";
    settings.Description = "API для управления коллекцией медиа";

    settings.DocumentName = "v1";
});

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Register services
services.AddHttpClient();
services.AddOptions();
services.AddOptions<JwtSettingsOptions>()
    .Bind(configuration.GetSection("JwtSettings"))
    .ValidateDataAnnotations();
services.AddOptions<MediaDbOptions>()
    .Bind(configuration.GetSection("MediaDbOptions:Database"))
    .ValidateDataAnnotations();

services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
    options.SerializerOptions.WriteIndented = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseOpenApi();
    app.UseSwaggerUi(settings =>
    {
        settings.Path = "/swagger";
        settings.DocumentPath = "/swagger/{documentName}/swagger.json";
        settings.DocExpansion = "list";
    });
}

app.UseFastEndpoints();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MediaDbContext>();
}
app.Run();