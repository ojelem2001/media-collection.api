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
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserMediaService, UserMediaService>();
        services.AddScoped<IUserMediaProvider, UserMediaProvider>();
        services.AddScoped<IUserProvider, UserProvider>();
        services.AddScoped<IRefreshTokenProvider, RefreshTokenProvider>();

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
                Console.WriteLine(param);
                builder[param.Key] = param.Value;
            }
            opt.ConnectionString = builder.ToString();
        });

        _ = services.AddSingleton<NpgsqlDataSource>(sp =>
        {
            var dbOptions = sp.GetRequiredService<IOptions<MediaDbOptions>>().Value;
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(dbOptions.ConnectionString);
            dataSourceBuilder.EnableDynamicJson();
            return dataSourceBuilder.Build();
        });

        _ = services.AddDbContext<MediaDbContext>((di, options) =>
        {
            var interceptor = di.GetRequiredService<MediaDbSaveChangesInterceptor>();
            var dataSource = di.GetRequiredService<NpgsqlDataSource>();
            _ = options.UseNpgsql(dataSource)
            .AddInterceptors(interceptor);
        });
        return services;
    }
}