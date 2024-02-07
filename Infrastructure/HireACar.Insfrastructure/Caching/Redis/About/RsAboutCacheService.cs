using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Insfrastructure.Caching.Abstract;
using Microsoft.Extensions.Caching.Distributed;

namespace HireACar.Insfrastructure.Caching.Redis.About
{
    public class RsAboutCacheService:RsCacheService,IRsAboutCacheService
    {
        public RsAboutCacheService(IDistributedCache distributedCache) : base(distributedCache)
        {
        }
    }
}
