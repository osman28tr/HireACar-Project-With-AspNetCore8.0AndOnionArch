using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.AboutCommands;
using HireACar.Application.CQRS.Results.AboutResults.CommandResults;
using HireACar.Domain.Entities;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.AboutHandlers.CommandHandlers
{
    public class CreatedAboutCommandHandler:IRequestHandler<CreatedAboutCommand,AddedAboutCommandResult>
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;
        public CreatedAboutCommandHandler(IRepository<About> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AddedAboutCommandResult> Handle(CreatedAboutCommand request, CancellationToken cancellationToken)
        {
            var about = _mapper.Map<About>(request);
            var result = await _repository.AddAsync(about);
            var mappingAbout = _mapper.Map<AddedAboutCommandResult>(result);
            return mappingAbout;
        }
    }
}
