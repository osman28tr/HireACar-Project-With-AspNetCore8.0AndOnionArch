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
    public class GetListPricingQueryHandler:IRequestHandler<GetListPricingQuery,List<GetListPricingQueryResult>>
    {
        private readonly IPricingRepository _pricingRepository;
        private readonly IMapper _mapper;
        public GetListPricingQueryHandler(IPricingRepository pricingRepository, IMapper mapper)
        {
            _pricingRepository = pricingRepository;
            _mapper = mapper;
        }
        public async Task<List<GetListPricingQueryResult>> Handle(GetListPricingQuery request, CancellationToken cancellationToken)
        {
            var pricings = await _pricingRepository.GetAllAsync(null);
            if (pricings == null || pricings.Count == 0)
            {
                throw new NotFoundException("Fiyatlandırma bilgisi bulunamadı.");
            }

            try
            {
                var mappingPricings = _mapper.Map<List<GetListPricingQueryResult>>(pricings);
                return mappingPricings;
            }
            catch
            {
                throw new CustomInternalServerException("Fiyatlandırma bilgisi iletilirken bir hata oluştu.");
            }
        }
    }
}
