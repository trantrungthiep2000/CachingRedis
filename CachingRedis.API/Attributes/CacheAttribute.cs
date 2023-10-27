using CachingRedis.API.Configurations;
using CachingRedis.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace CachingRedis.API.Attributes;

/// <summary>
/// Information of cache attribute
/// CreatedBy: ThiepTT(26/10/2023)
/// </summary>
public class CacheAttribute : Attribute, IAsyncActionFilter
{
    private readonly int _timeToLiveSeconds;

    public CacheAttribute(int timeToLiveSeconds = 1000)
    {
        _timeToLiveSeconds = timeToLiveSeconds;
    }

    /// <summary>
    /// On action execution async
    /// </summary>
    /// <param name="context">ActionExecutingContext</param>
    /// <param name="next">ActionExecutionDelegate</param>
    /// <returns>Task</returns>
    /// CreatedBy: ThiepTT(26/10/2023)
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var cacheConfiguration = context.HttpContext.RequestServices.GetRequiredService<RedisConfiguration>();

        if (!cacheConfiguration.Enabled)
        {
            await next();
            return;
        }

        var cacheService = context.HttpContext.RequestServices.GetRequiredService<IResponseCacheService>();

        var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);

        var cacheResponse = await cacheService.GetCacheResponseAsync(cacheKey);

        // check cache is not null
        if (!string.IsNullOrWhiteSpace(cacheResponse))
        {
            var contentResult = new ContentResult
            {
                Content = cacheResponse,
                ContentType = "application/json",
                StatusCode = 200
            };

            context.Result = contentResult;
            return;
        }

        var executedContext = await next();

        if (executedContext.Result is OkObjectResult objectResult)
            await cacheService.SetCacheResponseAsync(cacheKey, objectResult.Value!, TimeSpan.FromSeconds(_timeToLiveSeconds));
    }

    /// <summary>
    /// Generate cache key from request
    /// </summary>
    /// <param name="request">HttpRequest</param>
    /// <returns>string</returns>
    /// CreatedBy: ThiepTT(26/10/2023)
    private static string GenerateCacheKeyFromRequest(HttpRequest request)
    {
        var keyBuilder = new StringBuilder();
        keyBuilder.Append($"{request.Path}");

        foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
        {
            keyBuilder.Append($"|{key}-{value}");
        }

        return keyBuilder.ToString();
    }
}