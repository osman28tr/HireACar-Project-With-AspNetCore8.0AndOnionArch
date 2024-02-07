using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Queries.AboutQueries;
using HireACar.Application.CQRS.Results.AboutResults;
using HireACar.Domain.Entities;

namespace HireACar.Application.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;
        public GetAboutQueryHandler(IRepository<About> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetAboutQueryResult> Handle(GetAboutQuery request)
        {
            var about = await _repository.GetByIdAsync(1);
            var mappingAbout = _mapper.Map<GetAboutQueryResult>(about);
            return mappingAbout;
        }
    }
}
