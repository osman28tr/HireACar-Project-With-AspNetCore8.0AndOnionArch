﻿using HireACar.API.Helpers;
using HireACar.Application.CQRS.Commands.ContactCommands;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatedContactCommand command)
        {
            await Mediator.Send(command);
            return Created("", new { message = "Mesajınız başarıyla iletildi." });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatedContactCommand command)
        {
            await Mediator.Send(command);
            return Ok(new { message = "Mesajınız başarıyla güncellendi." });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeletedContactCommand command)
        {
            await Mediator.Send(command);
            return Ok(new { message = "Mesajınız başarıyla silindi." });
        }
    }
}
