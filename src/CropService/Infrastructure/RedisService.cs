using System;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace CropService.Infrastructure;

public class RedisService
{
    private readonly IDistributedCache _cache;

    public RedisService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<T> GetAsync<T>(string key, CancellationToken cancellationToken)
    {
        var value = await _cache.GetStringAsync(key, cancellationToken);

        if (value != null)
        {
            return JsonSerializer.Deserialize<T>(value);
        }

        return default;
    }

    public async Task SetAsync<T>(string key, T value, CancellationToken cancellationToken)
    {
        var timeOut = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24),
            SlidingExpiration = TimeSpan.FromMinutes(60)
        };

        await _cache.SetStringAsync(key, JsonSerializer.Serialize(value), timeOut);
    }
}
