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

namespace HireACar.Application.CQRS.Handlers.AboutHandlers.CommandHandlers
{
    public class CreatedAboutCommandHandler
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;
        public CreatedAboutCommandHandler(IRepository<About> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AddedAboutCommandResult> Handle(CreatedAboutCommand request)
        {
            var about = _mapper.Map<About>(request);
            var result = await _repository.AddAsync(about);
            var mappingAbout = _mapper.Map<AddedAboutCommandResult>(result);
            return mappingAbout;
        }
    }
}
