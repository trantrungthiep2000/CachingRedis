using CachingRedis.API.Services;

namespace CachingRedis.API.Installers;

/// <summary>
/// Information of service installer
/// CreatedBy: ThiepTT(25/10/2023)
/// </summary>
public class ServiceInstaller : IInstaller
{
    /// <summary>
    /// Install services
    /// </summary>
    /// <param name="builder">WebApplicationBuilder</param>
    /// CreatedBy: ThiepTT(25/10/2023)
    public void InstallServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IResponseCacheService, ResponseCacheService>();
    }
}