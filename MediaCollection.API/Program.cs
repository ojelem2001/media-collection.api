using FastEndpoints;
using FastEndpoints.Swagger;
using MediaCollection.API;
using MediaCollection.API.Models.Options;
using MediaCollection.Core.Models.Options;
using MediaCollection.Data.Database;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

services.AddApplicationServices(configuration);

services.AddFastEndpoints();
services.SwaggerDocument();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { 
        Title = "Media Collection API",
        Description = "API для управления коллекцией медиа",
        Version = "v1"
    });
    c.CustomSchemaIds(x => x.FullName);
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
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "swagger/{documentName}/swagger.json";
    });
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Media Collection API V1");
    });
}

app.UseFastEndpoints();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MediaDbContext>();
}
app.Run();