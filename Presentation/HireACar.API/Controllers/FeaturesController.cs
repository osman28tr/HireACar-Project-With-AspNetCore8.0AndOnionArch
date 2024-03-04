using HireACar.API.Helpers;
using HireACar.Application.CQRS.Commands.FeatureCommands;
using HireACar.Application.CQRS.Queries.FeatureQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : MediatrBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await Mediator.Send(new GetListFeatureQuery());
            return Ok(new { message = "Özellikler başarıyla getirildi.", data = result });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetFeatureByIdQuery { Id = id });
            return Ok(new { message = "Özellik başarıyla getirildi.", data = result });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatedFeatureCommand command)
        {
            await Mediator.Send(command);
            return Ok(new { message = "Özellik başarıyla eklendi." });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatedFeatureCommand command)
        {
            await Mediator.Send(command);
            return Ok(new { message = "Özellik başarıyla güncellendi." });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeletedFeatureCommand command)
        {
            await Mediator.Send(command);
            return Ok(new { message = "Özellik başarıyla silindi." });
        }
    }
}
