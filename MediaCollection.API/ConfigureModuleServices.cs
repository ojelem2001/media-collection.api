using MediaCollection.API.Models.Options;
using MediaCollection.Core.Abstract;
using MediaCollection.Data.Database;
using MediaCollection.Data.Interceptors;
using MediaCollection.Data.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Npgsql;

namespace MediaCollection.API;

public static class ConfigureModuleServices
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IMediaService, MediaService>();
        services.AddScoped<IMediaProvider, MediaProvider>();

        services.AddSingleton<MediaDbSaveChangesInterceptor>();
        services.AddNpgSql();
    }

    private static IServiceCollection AddNpgSql(this IServiceCollection services)
    {
        _ = services.PostConfigureAll<MediaDbOptions>((opt) =>
        {
            var builder = new NpgsqlConnectionStringBuilder(opt.ConnectionString);
            foreach(var param in opt.ConnectionParams)
            {
                builder[param.Key] = param.Value;
            }
            opt.ConnectionString = builder.ToString();
        });

        _ = services.AddDbContext<MediaDbContext>((di, options) =>
        {
            var interceptor = di.GetRequiredService<MediaDbSaveChangesInterceptor>();
            var dbOptions = di.GetRequiredService<IOptions<MediaDbOptions>>().Value;
            _ = options.UseNpgsql(dbOptions?.ConnectionString)
            .AddInterceptors(interceptor);
        });
        return services;
    }
}