using NewBlogProject.Services.Abstract;
using System;
using System.Runtime.Caching;

namespace NewBlogProject.Services.Concrete
{
    public class CacheService : ICacheService
    {
        private ObjectCache Cache { get { return MemoryCache.Default; } }

        public object Get(string key)
        {
            return Cache[key];
        }

        public void Set(string key, object data, int cacheTime)
        {
            CacheItemPolicy policy = new CacheItemPolicy()
            {
                AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime)
            };
            Cache.Add(new CacheItem(key, data), policy);
        }

        public bool IsExist(string key)
        {
            return Cache[key] != null;
        }
    }
}
