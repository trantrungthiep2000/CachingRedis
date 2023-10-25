namespace CachingRedis.API.Configurations;

/// <summary>
/// Information of redis configuration
/// CreatedBy: ThiepTT(25/10/2023)
/// </summary>
public class RedisConfiguration
{
    /// <summary>
    /// Enabled
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// Connection string
    /// </summary>
    public string ConnectionString { get; set; } = string.Empty;
}