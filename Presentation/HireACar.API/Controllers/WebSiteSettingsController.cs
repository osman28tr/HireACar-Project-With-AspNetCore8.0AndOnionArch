using HireACar.API.Helpers;
using HireACar.Application.CQRS.Queries.WebSiteSettingQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebSiteSettingsController : MediatrBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetWebSiteSettings()
        {
            var webSiteSettings = await Mediator.Send(new GetWebSiteSettingQuery());
            return Ok(webSiteSettings);
        }
    }
}
