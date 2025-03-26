using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Services.Contracts
{
    public interface IRedisCacheService
    {
        Task SetCacheAsync<T>(string key, T value, TimeSpan? expirationTime = null);
        Task<T> GetCacheAsync<T>(string key);
        Task RemoveCacheAsync(string key);
    }
}
