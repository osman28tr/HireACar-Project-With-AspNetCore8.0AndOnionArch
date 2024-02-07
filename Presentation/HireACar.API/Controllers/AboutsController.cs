using HireACar.API.Helpers;
using HireACar.Application.CQRS.Queries.AboutQueries;
using HireACar.Insfrastructure.Caching.Redis.About;
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
            var values = await Mediator.Send(new GetAboutQuery());
            return Ok(values);
        }
    }
}
