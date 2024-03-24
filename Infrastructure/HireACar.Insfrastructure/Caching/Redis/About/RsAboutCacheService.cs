using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.AboutCommands;
using HireACar.Application.CQRS.Results.AboutResults.CommandResults;
using HireACar.Application.CQRS.Results.AboutResults.QueryResults;
using HireACar.Insfrastructure.Caching.Abstract;
using HireACar.Insfrastructure.Caching.Redis.About.Abstract;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace HireACar.Insfrastructure.Caching.Redis.About
{
    public class RsAboutCacheService:RsCacheService,IRsAboutCacheService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IAboutRepository _aboutRepository;
        public RsAboutCacheService(IDistributedCache distributedCache,IAboutRepository aboutRepository) : base(distributedCache)
        {
            _distributedCache = distributedCache;
            _aboutRepository = aboutRepository;
        }

        public async Task AddCacheAsync(AddedAboutCommandResult addedAboutCommandResult)
        {
            string jsonAbout = JsonConvert.SerializeObject(addedAboutCommandResult);
            await _distributedCache.SetStringAsync($"about:{addedAboutCommandResult.Id}", jsonAbout);
        }

        public async Task UpdateCacheAsync(UpdatedAboutCommandResult updatedAboutCommandResult)
        {
			string jsonAbout = JsonConvert.SerializeObject(updatedAboutCommandResult);
			await _distributedCache.SetStringAsync($"about:{updatedAboutCommandResult.Id}", jsonAbout);
		}

        public async Task DeleteCacheAsync(int key)
        {
	        await _distributedCache.RemoveAsync($"about:{key}");
        }

        public async Task<GetAboutQueryResult> GetCacheAsync()
        {
            int id = _aboutRepository.GetAllAsync(null).Result.LastOrDefault().Id;
            var about = await _distributedCache.GetStringAsync($"about:{id}");
            if (about != null)
            {
                return JsonConvert.DeserializeObject<GetAboutQueryResult>(about);
            }
            return null;
        }
    }
}
