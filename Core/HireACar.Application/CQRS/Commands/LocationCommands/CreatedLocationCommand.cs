﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HireACar.Application.CQRS.Commands.LocationCommands
{
    public class CreatedLocationCommand:IRequest
    {
        public string Name { get; set; }
    }
}
