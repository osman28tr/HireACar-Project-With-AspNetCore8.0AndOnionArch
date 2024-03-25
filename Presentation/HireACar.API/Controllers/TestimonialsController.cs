using HireACar.API.Helpers;
using HireACar.Application.CQRS.Commands.TestimonialCommands;
using HireACar.Application.CQRS.Queries.TestimonialQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : MediatrBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await Mediator.Send(new GetListTestimonialQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var value = await Mediator.Send(new GetTestimonialByIdQuery() { Id = id });
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatedTestimonialCommand createdTestimonialCommand)
        {
            await Mediator.Send(createdTestimonialCommand);
            return Created("", new { message = "Referans ekleme işlemi başarıyla tamamlandı." });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatedTestimonialCommand updatedTestimonialCommand)
        {
            await Mediator.Send(updatedTestimonialCommand);
            return Ok(new { message = "Referans güncelleme işlemi başarıyla tamamlandı." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeletedTestimonialCommand() { Id = id });
            return Ok(new { message = "Referans silme işlemi başarıyla tamamlandı." });
        }
    }
}
