using HireACar.API.Helpers;
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
    }
}
