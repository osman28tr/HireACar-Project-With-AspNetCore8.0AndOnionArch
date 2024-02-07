using HireACar.API.Helpers;
using HireACar.Application.CQRS.Queries.AboutQueries;
using HireACar.Application.CQRS.Results.AboutResults.CommandResults;
using HireACar.Insfrastructure.Caching.Redis.About.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : MediatrBaseController
    {
        private readonly IRsAboutCacheService _rsAboutCacheService;

        public AboutsController(IRsAboutCacheService reAboutCacheService)
        {
            _rsAboutCacheService = reAboutCacheService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAbout()
        {
            //var values = await Mediator.Send(new GetAboutQuery());
            //await _rsAboutCacheService.AddCacheAsync(new AddedAboutCommandResult()
            //    { Id = 1, Title = "About title 1", Description = "About description 1" });
            var cacheValue = await _rsAboutCacheService.GetCacheAsync();
            return Ok(cacheValue);
        }
    }
}
