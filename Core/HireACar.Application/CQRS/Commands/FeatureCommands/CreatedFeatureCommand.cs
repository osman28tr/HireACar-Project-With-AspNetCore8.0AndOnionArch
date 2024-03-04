using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HireACar.Application.CQRS.Commands.FeatureCommands
{
    public class CreatedFeatureCommand:IRequest
    {
        public string Name { get; set; }
    }
}
