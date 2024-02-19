using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Queries.AboutQueries;
using HireACar.Application.CQRS.Results.AboutResults.QueryResults;
using HireACar.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HireACar.Application.CQRS.Handlers.AboutHandlers.QueryHandlers
{
    public class GetAboutQueryHandler:IRequestHandler<GetAboutQuery,GetAboutQueryResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAboutQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetAboutQueryResult> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {
            var about = await _unitOfWork.Abouts.Query().FirstOrDefaultAsync();
            var mappingAbout = _mapper.Map<GetAboutQueryResult>(about);
            return mappingAbout;
        }
    }
}
