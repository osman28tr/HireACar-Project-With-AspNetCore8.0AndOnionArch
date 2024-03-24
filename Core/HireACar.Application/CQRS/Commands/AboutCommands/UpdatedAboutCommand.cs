using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.CQRS.Results.AboutResults.CommandResults;
using MediatR;

namespace HireACar.Application.CQRS.Commands.AboutCommands
{
    public class UpdatedAboutCommand:IRequest<UpdatedAboutCommandResult>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
