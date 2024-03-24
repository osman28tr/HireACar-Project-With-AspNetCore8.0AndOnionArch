using System;
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
    public class UpdatedAboutCommandHandler : IRequestHandler<UpdatedAboutCommand,UpdatedAboutCommandResult>
    {
        private readonly IAboutRepository _repository;
        private readonly IMapper _mapper;
        public UpdatedAboutCommandHandler(IAboutRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UpdatedAboutCommandResult> Handle(UpdatedAboutCommand request, CancellationToken cancellationToken)
        {
            var about = await _repository.GetAsync(x => x.Id == request.Id);
            var mappingAbout = _mapper.Map(request, about);
            var updatedAbout = await _repository.UpdateAsync(mappingAbout);
            var resultMapping = _mapper.Map<UpdatedAboutCommandResult>(updatedAbout);
            return resultMapping;
        }
    }
}
