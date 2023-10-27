namespace CachingRedis.API.Dtos.Requests;

/// <summary>
/// Information of user request
/// CreatedBy: ThiepTT(27/10/2023)
/// </summary>
public class UserRequest
{
    /// <summary>
    /// Full name
    /// </summary>
    public string FullName { get; set; } = string.Empty;
}