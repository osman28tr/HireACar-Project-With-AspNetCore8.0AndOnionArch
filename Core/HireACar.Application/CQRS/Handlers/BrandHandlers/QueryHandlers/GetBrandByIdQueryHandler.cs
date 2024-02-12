using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Queries.BrandQueries;
using HireACar.Application.CQRS.Results.BrandResults.QueryResults;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.BrandHandlers.QueryHandlers
{
    public class GetBrandByIdQueryHandler:IRequestHandler<GetBrandByIdQuery,GetBrandByIdQueryResult>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        public GetBrandByIdQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetAsync(x => x.Id == request.BrandId);
            var brandMapping = _mapper.Map<GetBrandByIdQueryResult>(brand);
            return brandMapping;
        }
    }
}
