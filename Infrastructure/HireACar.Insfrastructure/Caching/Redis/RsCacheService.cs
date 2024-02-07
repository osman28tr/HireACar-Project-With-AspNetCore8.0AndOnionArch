using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Insfrastructure.Caching.Abstract;
using Microsoft.Extensions.Caching.Distributed;

namespace HireACar.Insfrastructure.Caching.Redis
{
    public class RsCacheService:ICacheService
    {
        private readonly IDistributedCache _distributedCache;
        public RsCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public void Set(string key, string value)
        {
            _distributedCache.SetString(key, value);
        }

        public string Get(string key)
        {
            return _distributedCache.GetString(key);
        }
    }
}
