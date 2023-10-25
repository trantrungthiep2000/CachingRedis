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
    private readonly IConfiguration _configuration; 

    public CacheInstaller(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void InstallServices(IServiceCollection services)
    {
        var redisConfiguration = new RedisConfiguration();
        _configuration.GetSection("RedisConfiguration").Bind(redisConfiguration);

        services.AddSingleton(redisConfiguration);

        if (!redisConfiguration.Enabled)
            return;

        services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(redisConfiguration.ConnectionString));
        services.AddStackExchangeRedisCache(option => option.Configuration = redisConfiguration.ConnectionString);
        services.AddSingleton<IResponseCacheService, ResponseCacheService>();
    }
}
