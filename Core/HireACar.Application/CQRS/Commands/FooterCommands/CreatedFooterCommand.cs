using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HireACar.Application.CQRS.Commands.FooterCommands
{
    public class CreatedFooterCommand:IRequest
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
