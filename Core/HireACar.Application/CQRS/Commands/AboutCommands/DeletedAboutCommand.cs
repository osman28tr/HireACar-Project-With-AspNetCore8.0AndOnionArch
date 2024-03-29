﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.CQRS.Results.AboutResults.CommandResults;
using MediatR;

namespace HireACar.Application.CQRS.Commands.AboutCommands
{
    public class DeletedAboutCommand:IRequest<DeletedAboutCommandResult>
    {
        public int Id { get; set; }
    }
}
