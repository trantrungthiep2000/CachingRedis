using CachingRedis.API.Data;
using Microsoft.EntityFrameworkCore;

namespace CachingRedis.API.Installers;

/// <summary>
/// Information of database installer
/// CreatedBy: ThiepTT(26/10/2023)
/// </summary>
public class DatabaseInstaller : IInstaller
{
    /// <summary>
    /// Install services
    /// </summary>
    /// <param name="builder">WebApplicationBuilder</param>
    /// CreatedBy: ThiepTT(26/10/2023)
    public void InstallServices(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
    }
}