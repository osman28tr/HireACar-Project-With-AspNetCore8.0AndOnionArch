using HireACar.API.Helpers;
using HireACar.Application.CQRS.Commands.SocialMediaCommands;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatedSocialMediaCommand command)
        {
            await Mediator.Send(command);
            return Created("",new { message = "Sosyal medya verisi başarıyla eklendi." });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatedSocialMediaCommand command)
        {
            await Mediator.Send(command);
            return Ok(new { message = "Sosyal medya verisi başarıyla güncellendi." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeletedSocialMediaCommand { Id = id });
            return Ok(new { message = "Sosyal medya verisi başarıyla silindi." });
        }
    }
}
