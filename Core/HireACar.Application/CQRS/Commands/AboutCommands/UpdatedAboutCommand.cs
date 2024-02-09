﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HireACar.Application.CQRS.Commands.AboutCommands
{
    public class UpdatedAboutCommand:IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}