using System.Diagnostics.CodeAnalysis;
using HireACar.API.Helpers;
using HireACar.Application.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : MediatrBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            var result = await Mediator.Send(new GetListBrandQuery());
            return result == null
                ? NotFound()
                : Ok(new { Message = "Marka verileri başarıyla getirildi.", data = result });
        }
    }
}
