using HireACar.API.Helpers;
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
    }
}
