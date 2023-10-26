namespace CachingRedis.API.Entities;

/// <summary>
/// Information of user
/// CreatedBy: ThiepTT(26/10/2023)
/// </summary>
public class User
{
    /// <summary>
    /// Id of user
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Full name
    /// </summary>
    public string FullName { get; set; } = string.Empty;
}