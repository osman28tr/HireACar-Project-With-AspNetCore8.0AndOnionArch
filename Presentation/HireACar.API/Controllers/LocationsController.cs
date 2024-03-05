using HireACar.API.Helpers;
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
    }
}
