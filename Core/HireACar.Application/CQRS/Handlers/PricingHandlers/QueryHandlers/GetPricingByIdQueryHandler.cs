using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Queries.PricingQueries;
using HireACar.Application.CQRS.Results.PricingResults.QueryResults;
using HireACar.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.PricingHandlers.QueryHandlers
{
    public class GetPricingByIdQueryHandler: IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        private readonly IPricingRepository _pricingRepository;
        private readonly IMapper _mapper;
        public GetPricingByIdQueryHandler(IPricingRepository pricingRepository, IMapper mapper)
        {
            _pricingRepository = pricingRepository;
            _mapper = mapper;
        }
        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var pricing = await _pricingRepository.GetAsync(x => x.Id == request.Id);
            return pricing == null
                ? throw new NotFoundException("Fiyatlandırma bilgisi bulunamadı.")
                : _mapper
                    .Map<GetPricingByIdQueryResult>(pricing);
        }
    }
}
