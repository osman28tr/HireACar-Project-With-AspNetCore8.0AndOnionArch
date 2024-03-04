using HireACar.API.Helpers;
using HireACar.Application.CQRS.Commands.FooterCommands;
using HireACar.Application.CQRS.Queries.FooterQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootersController : MediatrBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetFooter()
        {
            var result = await Mediator.Send(new GetFooterQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatedFooterCommand command)
        {
            await Mediator.Send(command);
            return Created("", new { message = "Footer başarıyla oluşturuldu." });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatedFooterCommand command)
        {
            await Mediator.Send(command);
            return Ok(new { message = "Footer başarıyla güncellendi." });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeletedFooterCommand command)
        {
            await Mediator.Send(command);
            return Ok(new { message = "Footer başarıyla silindi." });
        }
    }
}
