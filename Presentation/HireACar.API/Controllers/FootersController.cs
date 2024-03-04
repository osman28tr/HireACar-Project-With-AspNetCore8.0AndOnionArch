using HireACar.API.Helpers;
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
    }
}
