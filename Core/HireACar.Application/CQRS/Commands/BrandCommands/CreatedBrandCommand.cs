using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.CQRS.Dtos;
using HireACar.Application.CQRS.Results.BrandResults.CommandResults;
using MediatR;

namespace HireACar.Application.CQRS.Commands.BrandCommands
{
    public class CreatedBrandCommand:IRequest<CreatedBrandCommandResult>
    {
        public CreatedBrandCommand()
        {
            CreatedModelDtos = new List<CreatedModelDto>();
        }
        public string Name { get; set; }
        public List<CreatedModelDto> CreatedModelDtos { get; set; }
    }
}
