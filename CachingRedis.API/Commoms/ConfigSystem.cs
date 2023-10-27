namespace CachingRedis.API.Commoms;

/// <summary>
/// Information of config system
/// CreatedBy: ThiepTT(27/10/2023)
/// </summary>
public static class ConfigSystem
{
    /// <summary>
    /// Generate pattern
    /// </summary>
    /// <param name="controllerName">Name of controller</param>
    /// <returns>Pattern</returns>
    /// CreatedBy: ThiepTT(27/10/2023)
    public static string GeneratePattern(string controllerName)
    {
        if (controllerName.EndsWith("Controller"))
        {
            controllerName = controllerName.Substring(0, controllerName.Length - "Controller".Length);
        }

        var pattern = $"/{ApiRouter.Api}/{controllerName}/{ApiRouter.User.GetAllUsersDapper}";

        return pattern;
    }
}