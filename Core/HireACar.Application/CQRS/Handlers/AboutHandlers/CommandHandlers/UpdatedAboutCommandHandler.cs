using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.AboutCommands;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.AboutHandlers.CommandHandlers
{
    public class UpdatedAboutCommandHandler : IRequestHandler<UpdatedAboutCommand>
    {
        private readonly IAboutRepository _repository;
        private readonly IMapper _mapper;
        public UpdatedAboutCommandHandler(IAboutRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(UpdatedAboutCommand request, CancellationToken cancellationToken)
        {
            var about = await _repository.GetAsync(x => x.Id == request.Id);
            await _repository.UpdateAsync(about);
        }
    }
}
