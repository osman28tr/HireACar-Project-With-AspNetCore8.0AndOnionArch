using HireACar.API.Helpers;
using HireACar.Application.CQRS.Commands.AboutCommands;
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

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreatedAboutCommand createdAboutCommand)
        {
			var values = await Mediator.Send(createdAboutCommand);
			await _rsAboutCacheService.AddCacheAsync(values);
			return Created("", values);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdatedAboutCommand updatedAboutCommand)
        {
			var values = await Mediator.Send(updatedAboutCommand);
			await _rsAboutCacheService.UpdateCacheAsync(values);
			return Ok(values);
		}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
	        var values = await Mediator.Send(new DeletedAboutCommand() { Id = id });
	        await _rsAboutCacheService.DeleteCacheAsync(id);
	        return Ok(values);
        }
    }
}
