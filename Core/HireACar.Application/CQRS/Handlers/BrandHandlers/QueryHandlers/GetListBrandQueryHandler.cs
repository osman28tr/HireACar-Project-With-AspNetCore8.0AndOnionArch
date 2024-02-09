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
    public class GetListBrandQueryHandler:IRequestHandler<GetListBrandQuery, List<GetListBrandQueryResult>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetListBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListBrandQueryResult>> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
        {
            var brands = await _brandRepository.GetAllAsync();
            var brandsMapping = _mapper.Map<List<GetListBrandQueryResult>>(brands);
            return brandsMapping;
        }
    }
}
