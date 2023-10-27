namespace CachingRedis.API.Installers;

/// <summary>
/// Information installer extensions
/// CreatedBy: ThiepTT(25/10/2023)
/// </summary>
public static class InstallerExtensions
{
    /// <summary>
    /// Installer services in assembly
    /// </summary>
    /// <param name="builder">WebApplicationBuilder</param>
    /// CreatedBy: ThiepTT(25/10/2023)
    public static void InstallerServicesInAssembly(this WebApplicationBuilder builder)
    {
        var installer = typeof(Program).Assembly.ExportedTypes.Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface
            && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

        installer.ForEach(installer => installer.InstallServices(builder));
    }
}