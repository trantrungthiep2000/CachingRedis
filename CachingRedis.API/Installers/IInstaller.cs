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
    /// <param name="services">IServiceCollection</param>
    /// CreatedBy: ThiepTT(25/10/2023)
    public void InstallServices(IServiceCollection services);
}
