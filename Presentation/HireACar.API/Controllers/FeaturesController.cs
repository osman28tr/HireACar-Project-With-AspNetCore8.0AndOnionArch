using HireACar.API.Helpers;
using HireACar.Application.CQRS.Queries.FeatureQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : MediatrBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await Mediator.Send(new GetListFeatureQuery());
            return Ok(new { message = "Özellikler başarıyla getirildi.", data = result });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetFeatureByIdQuery { Id = id });
            return Ok(new { message = "Özellik başarıyla getirildi.", data = result });
        }
    }
}
