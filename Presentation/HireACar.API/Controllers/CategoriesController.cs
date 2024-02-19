using HireACar.API.Helpers;
using HireACar.Application.CQRS.Commands.CategoryCommands;
using HireACar.Application.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : MediatrBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await Mediator.Send(new GetListCategoryQuery());
            return result.Count == 0 ? NotFound(new { message = "Blog kategorileri bulunamadı." }) : Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await Mediator.Send(new GetCategoryByIdQuery() { Id = id });
            return result == null ? NotFound(new { message = "Blog kategorisi bulunamadı." }) : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatedCategoryCommand createdCategoryCommand)
        {
            await Mediator.Send(createdCategoryCommand);
            return Created("", new { message = "Blog kategorisi başarıyla eklendi." });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatedCategoryCommand updatedCategoryCommand)
        {
            await Mediator.Send(updatedCategoryCommand);
            return Ok(new { message = "Blog kategorisi başarıyla güncellendi." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeletedCategoryCommand() { Id = id });
            return Ok(new { message = "Blog kategorisi başarıyla silindi." });
        }
    }
}
