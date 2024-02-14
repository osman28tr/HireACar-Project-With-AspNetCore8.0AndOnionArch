using HireACar.API.Helpers;
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
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetListCarQuery());
            return result.Count == 0
                ? NotFound(new { Message = "Veriler alınamadı.", data = result })
                : Ok(new { Message = "Otomobil verileri başarıyla getirildi.", data = result });
        }
    }
}
