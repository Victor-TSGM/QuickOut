using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using QuickOut.Library;

namespace QuickOut.Infrastructure.Common
{
    public class CacheStore : ICacheStore
    {
        private readonly IMemoryCache memoryCache;
        private readonly IConfiguration configuration;

        public CacheStore(IMemoryCache memoryCache, IConfiguration configuration)
        {
            this.memoryCache = memoryCache;
            this.configuration = configuration;
        }

        public async Task<T> GetOrAdd<T>(ICacheKey key, Func<Task<T>> insertAction, int expirationSeconds = 600)
        {
            T? value;

            if (memoryCache.TryGetValue(key.GetCacheKey(), out value))
            {
                return value;
            }

            value = await insertAction();

            memoryCache.Set(key.GetCacheKey(), value, TimeSpan.FromSeconds(expirationSeconds));

            return value;
        }
    }
}
