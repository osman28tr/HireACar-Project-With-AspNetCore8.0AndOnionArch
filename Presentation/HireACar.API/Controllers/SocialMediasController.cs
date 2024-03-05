using HireACar.API.Helpers;
using HireACar.Application.CQRS.Queries.SocialMediaQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : MediatrBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await Mediator.Send(new GetListSocialMediaQuery());
            return Ok(new { message = "Sosyal medya verileri başarıyla getirildi.", data = result });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await Mediator.Send(new GetSocialMediaByIdQuery { Id = id });
            return Ok(new { message = "Sosyal medya verisi başarıyla getirildi.", data = result });
        }
    }
}
