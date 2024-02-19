using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HireACar.Application.CQRS.Commands.CategoryCommands
{
    public class DeletedCategoryCommand:IRequest
    {
        public int Id { get; set; }
    }
}
