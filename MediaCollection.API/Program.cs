using FastEndpoints;
using FastEndpoints.Swagger;
using MediaCollection.API;
using MediaCollection.API.Models.Options;
using MediaCollection.Core.Models.Options;
using MediaCollection.Data.Database;
using MediaCollection.Data.Maps;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

services.AddCors();
services.AddApplicationServices(configuration);

services.AddFastEndpoints();
services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
services.SwaggerDocument();

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddAutoMapper(
    typeof(UserDboProfile).Assembly,
    typeof(MediaDboProfile).Assembly);

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

// Включаем детальное логирование для JSON ошибок
services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNameCaseInsensitive = true;
    options.SerializerOptions.WriteIndented = true;
    options.SerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString;
    options.SerializerOptions.IncludeFields = false;
});
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettingsOptions>();

services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwtSettings.Issuer,

        ValidateAudience = true,
        ValidAudience = jwtSettings.Audience,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),

        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});
services.AddAuthorization();

var app = builder.Build();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseOpenApi(c => c.Path = "/api/swagger/swagger.json");
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/api/swagger/swagger.json", "Media Collection API V1");
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MediaDbContext>();
}
app.Run();