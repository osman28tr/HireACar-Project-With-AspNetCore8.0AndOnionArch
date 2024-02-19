using HireACar.API.Helpers;
using HireACar.Application.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : MediatrBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await Mediator.Send(new GetListContactQuery());
            return Ok(result);
        }
    }
}
