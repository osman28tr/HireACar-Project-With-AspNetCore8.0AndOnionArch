using HireACar.API.Helpers;
using HireACar.Application.CQRS.Commands.ServiceCommands;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatedServiceCommand command)
        {
            await Mediator.Send(command);
            return Created("", new { message = "Servis verisi eklendi." });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatedServiceCommand command)
        {
            await Mediator.Send(command);
            return Ok(new { message = "Servis verisi güncellendi." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeletedServiceCommand() { Id = id });
            return Ok(new { message = "Servis verisi silindi." });
        }
    }
}
