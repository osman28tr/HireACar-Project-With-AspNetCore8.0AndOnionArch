﻿using System.Diagnostics.CodeAnalysis;
using HireACar.API.Helpers;
using HireACar.Application.CQRS.Commands.BrandCommands;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            var result = await Mediator.Send(new GetBrandByIdQuery { BrandId = id });
            return result == null
                ? NotFound()
                : Ok(new { Message = "Marka verisi başarıyla getirildi.", data = result });
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand([FromBody] CreatedBrandCommand createdBrandCommand)
        {
            var addedBrand = await Mediator.Send(createdBrandCommand);
            return addedBrand == null
                ? BadRequest()
                : Created("", new { Message = $"{addedBrand.Name} markanız başarıyla eklendi." });
        }
    }
}