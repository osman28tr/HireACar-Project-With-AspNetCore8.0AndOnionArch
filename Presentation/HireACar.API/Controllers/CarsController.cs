using HireACar.API.Helpers;
using HireACar.Application.CQRS.Commands.CarCommands;
using HireACar.Application.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : MediatrBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await Mediator.Send(new GetListCarQuery());
            return result.Count == 0
                ? NotFound(new { Message = "Veriler alınamadı.", data = result })
                : Ok(new { Message = "Otomobil verileri başarıyla getirildi.", data = result });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await Mediator.Send(new GetCarByIdQuery { Id = id });
            return Ok(new { Message = "Otomobil verisi başarıyla getirildi.", data = result });
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatedCarCommand command)
        {
            await Mediator.Send(command);
            return Created("",
                new
                {
                    Message = "Otomobiliniz yayına alınmak üzere admin'e gönderildi, en kısa sürede yayına alınacaktır."
                });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatedCarCommand command)
        {
            await Mediator.Send(command);
            return Ok(new { Message = "Otomobiliniz başarıyla güncellendi." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeletedCarCommand() { Id = id });
            return Ok(new { Message = "Otomobiliniz yayından kaldırıldı. En kısa sürede sistemden silinecek." });
        }
    }
}
