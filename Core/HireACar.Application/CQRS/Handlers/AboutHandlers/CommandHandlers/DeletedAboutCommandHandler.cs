﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.AboutCommands;
using HireACar.Application.CQRS.Results.AboutResults.CommandResults;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.AboutHandlers.CommandHandlers
{
    public class DeletedAboutCommandHandler:IRequestHandler<DeletedAboutCommand,DeletedAboutCommandResult>
    {
        private readonly IAboutRepository _repository;
        private readonly IMapper _mapper;

        public DeletedAboutCommandHandler(IAboutRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<DeletedAboutCommandResult> Handle(DeletedAboutCommand request, CancellationToken cancellationToken)
        {
            var deletedAbout = await _repository.GetAsync(x => x.Id == request.Id);
            var result = await _repository.DeleteAsync(deletedAbout);
            var mappingAbout = _mapper.Map<DeletedAboutCommandResult>(result);
            return mappingAbout;
        }
    }
}
