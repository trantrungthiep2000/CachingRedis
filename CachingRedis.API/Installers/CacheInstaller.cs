using CachingRedis.API.Configurations;
using CachingRedis.API.Services;
using StackExchange.Redis;

namespace CachingRedis.API.Installers;

/// <summary>
/// Information of cache installer
/// CreatedBy: ThiepTT(25/10/2023)
/// </summary>
public class CacheInstaller : IInstaller
{
    /// <summary>
    /// Install services
    /// </summary>
    /// <param name="builder">WebApplicationBuilder</param>
    /// CreatedBy: ThiepTT(25/10/2023)
    public void InstallServices(WebApplicationBuilder builder)
    {
        var redisConfiguration = new RedisConfiguration();
        redisConfiguration.Enabled = Convert.ToBoolean(builder.Configuration["RedisConfiguration:Enabled"]!);
        redisConfiguration.ConnectionString = builder.Configuration["RedisConfiguration:ConnectionString"]!;

        builder.Services.AddSingleton(redisConfiguration);

        if (!redisConfiguration.Enabled)
            return;

        builder.Services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(redisConfiguration.ConnectionString));
        builder.Services.AddStackExchangeRedisCache(option => option.Configuration = redisConfiguration.ConnectionString);
        builder.Services.AddSingleton<IResponseCacheService, ResponseCacheService>();
    }
}