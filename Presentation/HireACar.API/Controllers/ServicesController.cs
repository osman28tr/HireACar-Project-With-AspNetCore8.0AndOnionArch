using HireACar.API.Helpers;
using HireACar.Application.CQRS.Queries.ServiceQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : MediatrBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await Mediator.Send(new GetListServiceQuery());
            return Ok(new { message = "Servis verileri getirildi.", data = result });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await Mediator.Send(new GetServiceByIdQuery() { Id = id });
            return Ok(new { message = "Servis verisi getirildi.", data = result });
        }
    }
}
