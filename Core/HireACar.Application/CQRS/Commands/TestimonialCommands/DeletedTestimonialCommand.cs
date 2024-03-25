using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireACar.Application.CQRS.Commands.TestimonialCommands
{
    public class DeletedTestimonialCommand: IRequest
    {
        public int Id { get; set; }
    }
}
