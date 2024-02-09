using HireACar.API.Helpers;
using HireACar.Application.CQRS.Commands.WebSiteSettingCommands;
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
        public async Task<IActionResult> Get()
        {
            var webSiteSettings = await Mediator.Send(new GetWebSiteSettingQuery());
            return Ok(new { Message = "Web site ayarı ile ilgili veriler başarıyla alındı.", data = webSiteSettings });
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdatedWebSiteSettingCommand updatedWebSiteSettingCommand)
        {
            await Mediator.Send(updatedWebSiteSettingCommand);
            return Ok(new { Message = "Web site ayarlarınız başarıyla güncellendi." });
        }
    }
}
