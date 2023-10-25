namespace CachingRedis.API.Installers;

/// <summary>
/// Information of system installer
/// CreatedBy: ThiepTT(25/10/2023)
/// </summary>
public class SystemInstaller : IInstaller
{
    /// <summary>
    /// Install services
    /// </summary>
    /// <param name="services">IServiceCollection</param>
    /// CreatedBy: ThiepTT(25/10/2023)
    public void InstallServices(IServiceCollection services)
    {
        services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();
    }
}