using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.CQRS.Results.BrandResults.CommandResults;
using MediatR;

namespace HireACar.Application.CQRS.Commands.BrandCommands
{
    public class UpdatedBrandCommand:IRequest<UpdatedBrandCommandResult>
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
    }
}
