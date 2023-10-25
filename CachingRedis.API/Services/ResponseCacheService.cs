using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StackExchange.Redis;

namespace CachingRedis.API.Services;

/// <summary>
/// Information of response cache service
/// CreatedBy: ThiepTT(25/10/2023)
/// </summary>
public class ResponseCacheService : IResponseCacheService
{
    private readonly IDistributedCache _distributedCache;
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public ResponseCacheService(IDistributedCache distributedCache, IConnectionMultiplexer connectionMultiplexer)
    {
        _distributedCache = distributedCache;
        _connectionMultiplexer = connectionMultiplexer;
    }

    public async Task<string> GetCacheResponseAsync(string cacheKey)
    {
        var cacheResponse = await _distributedCache.GetStringAsync(cacheKey);

        return string.IsNullOrWhiteSpace(cacheResponse) ? string.Empty : cacheResponse;


    }

    /// <summary>
    /// Set cache response async
    /// </summary>
    /// <param name="cacheKey">Cache key</param>
    /// <param name="response">Response</param>
    /// <param name="timeOut">Time out</param>
    /// <returns></returns>
    public async Task SetCacheResponseAsync(string cacheKey, object response, TimeSpan timeOut)
    {
        if (response is null)
            return;

        var serializerResponse = JsonConvert.SerializeObject(response, new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        });

        await _distributedCache.SetStringAsync(cacheKey, serializerResponse, new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = timeOut
        });
    }
}