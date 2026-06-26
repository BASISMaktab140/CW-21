using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace CW._21.Services.Redis;

public class RedisService : IRedisService
{
    private readonly IDistributedCache _cache;

    public RedisService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var json = await _cache.GetStringAsync(key);

        if (json is null) return default;

        return JsonSerializer.Deserialize<T>(json);
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
    {
        var json = JsonSerializer.Serialize(value);

        var options = new DistributedCacheEntryOptions();

        options.AbsoluteExpirationRelativeToNow = expiry ?? TimeSpan.FromMinutes(5);

        await _cache.SetStringAsync(key, json, options);
    }

    public async Task RemoveAsync(string key)
    {
        await _cache.RemoveAsync(key);
    }

    public async Task<bool> ExistsAsync(string key)
    {
        var value = await _cache.GetStringAsync(key);
        return value is not null;
    }
}