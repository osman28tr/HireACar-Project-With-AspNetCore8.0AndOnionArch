using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.CQRS.Commands.AboutCommands;
using HireACar.Application.CQRS.Results.AboutResults.CommandResults;
using HireACar.Application.CQRS.Results.AboutResults.QueryResults;
using HireACar.Insfrastructure.Caching.Abstract;

namespace HireACar.Insfrastructure.Caching.Redis.About.Abstract
{
    public interface IRsAboutCacheService : ICacheService
    {
        Task AddCacheAsync(AddedAboutCommandResult addedAboutCommandResult);
        Task<GetAboutQueryResult> GetCacheAsync();
        Task UpdateCacheAsync(UpdatedAboutCommandResult updatedAboutCommandResult);
        Task DeleteCacheAsync(int key);
    }
}
