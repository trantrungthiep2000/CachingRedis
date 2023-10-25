namespace CachingRedis.API.Services;

/// <summary>
/// Information of interface response cache service
/// CreatedBy: ThiepTT(25/10/2023)
/// </summary>
public interface IResponseCacheService
{
    /// <summary>
    /// Set cache response async
    /// </summary>
    /// <param name="cacheKey">Cache key</param>
    /// <param name="response">Response</param>
    /// <param name="timeOut">Time out</param>
    /// <returns>Task</returns>
    /// CreatedBy: ThiepTT(25/10/2023)
    public Task SetCacheResponseAsync(string cacheKey, object response, TimeSpan timeOut);
    
    /// <summary>
    /// Get cache response async
    /// </summary>
    /// <param name="cacheKey">Cache key</param>
    /// <returns>string</returns>
    /// CreatedBy: ThiepTT(25/10/2023)
    public Task<string> GetCacheResponseAsync(string cacheKey);
}
