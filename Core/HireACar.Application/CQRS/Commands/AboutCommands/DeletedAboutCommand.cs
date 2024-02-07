using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HireACar.Application.CQRS.Commands.AboutCommands
{
    public class DeletedAboutCommand:IRequest<DeletedAboutCommand>
    {
        public int Id { get; set; }
    }
}
