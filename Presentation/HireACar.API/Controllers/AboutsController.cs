using HireACar.API.Helpers;
using HireACar.Application.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : MediatrBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAbout()
        {
            var values = await Mediator.Send(new GetAboutQuery());
            return Ok(values);
        }
    }
}
