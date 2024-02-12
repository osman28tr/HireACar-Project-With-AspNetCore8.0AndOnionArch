using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.CQRS.Results.BrandResults.CommandResults;
using MediatR;

namespace HireACar.Application.CQRS.Commands.BrandCommands
{
    public class DeletedBrandCommand:IRequest<DeletedBrandCommandResult>
    {
        public int BrandId { get; set; }
    }
}
