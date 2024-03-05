using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HireACar.Application.CQRS.Commands.LocationCommands
{
    public class DeletedLocationCommand:IRequest
    {
        public int Id { get; set; }
    }
}
