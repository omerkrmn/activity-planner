using ActivityPlanner.Services.Contracts;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ActivityPlanner.Services
{
    public class RedisCacheService : IRedisCacheService
    {

        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _database;

        public RedisCacheService(IConnectionMultiplexer redis)
        {
            _redis = redis ?? throw new ArgumentNullException(nameof(redis));
            _database = _redis.GetDatabase();
        }

        public async Task SetCacheAsync<T>(string key, T value, TimeSpan? expirationTime = null)
        {
            var serializedValue = JsonSerializer.Serialize(value);
            var expiration = expirationTime ?? TimeSpan.FromSeconds(10);

            await _database.StringSetAsync(key, serializedValue, expiration);
        }

        public async Task<T> GetCacheAsync<T>(string key)
        {
            var cachedValue = await _database.StringGetAsync(key);
            if (cachedValue.IsNullOrEmpty)
                return default;

            return JsonSerializer.Deserialize<T>(cachedValue);
        }

        public async Task RemoveCacheAsync(string key)
        {
            await _database.KeyDeleteAsync(key);
        }
    }
}
