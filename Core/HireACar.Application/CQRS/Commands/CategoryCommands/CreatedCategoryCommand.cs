using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireACar.Application.CQRS.Commands.CategoryCommands
{
    public class CreatedCategoryCommand:IRequest
    {
        public string Name { get; set; }
    }
}
