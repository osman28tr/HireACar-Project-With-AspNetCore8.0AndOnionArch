using HireACar.API.Helpers;
using HireACar.Application.CQRS.Commands.PricingCommands;
using HireACar.Application.CQRS.Queries.PricingQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : MediatrBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await Mediator.Send(new GetListPricingQuery());
            return Ok(new { message = "Fiyatlandırma verileri getirildi.", data = result });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await Mediator.Send(new GetPricingByIdQuery() { Id = id });
            return Ok(new { message = "Fiyatlandırma verisi getirildi.", data = result });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatedPricingCommand command)
        {
            await Mediator.Send(command);
            return Ok(new { message = "Fiyatlandırma verisi eklendi." });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatedPricingCommand command)
        {
            await Mediator.Send(command);
            return Ok(new { message = "Fiyatlandırma verisi güncellendi." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeletedPricingCommand() { Id = id });
            return Ok(new { message = "Fiyatlandırma verisi silindi." });
        }
    }
}
