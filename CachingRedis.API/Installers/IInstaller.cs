namespace CachingRedis.API.Installers;

/// <summary>
/// Information of interface installer
/// CreatedBy: ThiepTT(25/10/2023)
/// </summary>
public interface IInstaller
{
    /// <summary>
    /// Install services
    /// </summary>
    /// <param name="builder">WebApplicationBuilder</param>
    /// CreatedBy: ThiepTT(25/10/2023)
    public void InstallServices(WebApplicationBuilder builder);
}