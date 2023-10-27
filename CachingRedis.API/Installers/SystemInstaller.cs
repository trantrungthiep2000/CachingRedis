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
    /// <param name="builder">WebApplicationBuilder</param>
    /// CreatedBy: ThiepTT(25/10/2023)
    public void InstallServices(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        builder.Services.AddAutoMapper(typeof(Program));
    }
}