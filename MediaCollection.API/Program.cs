using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDocument(settings =>
{
    settings.Title = "Media Collection API";
    settings.Version = "v1";
    settings.Description = "API для управления коллекцией медиа";

    settings.DocumentName = "v1";
});

// Register services
builder.Services.AddHttpClient();

builder.Services.ConfigureHttpJsonOptions(options =>
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


app.Run();