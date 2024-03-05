using HireACar.API.Helpers;
using HireACar.Application.CQRS.Commands.LocationCommands;
using HireACar.Application.CQRS.Queries.LocationQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : MediatrBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetListLocationQuery());
            return Ok(new { message = "Konum verileri getirildi.", data = result });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await Mediator.Send(new GetLocationByIdQuery() { Id = id });
            return Ok(new { message = "Konum verisi getirildi.", data = result });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatedLocationCommand command)
        {
            await Mediator.Send(command);
            return Created("", new { message = "Konum başarıyla eklendi." });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatedLocationCommand command)
        {
            await Mediator.Send(command);
            return Ok(new { message = "Konum başarıyla güncellendi." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeletedLocationCommand() { Id = id });
            return Ok(new { message = "Konum başarıyla silindi." });
        }
    }
}
