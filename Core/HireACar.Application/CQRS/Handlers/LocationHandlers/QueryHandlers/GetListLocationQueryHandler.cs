using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Queries.LocationQueries;
using HireACar.Application.CQRS.Results.LocationResults.QueryResults;
using HireACar.CrossCuttingConcerns.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HireACar.Application.CQRS.Handlers.LocationHandlers.QueryHandlers
{
    public class GetListLocationQueryHandler : IRequestHandler<GetListLocationQuery, List<GetListLocationQueryResult>>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        public GetListLocationQueryHandler(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }
        public async Task<List<GetListLocationQueryResult>> Handle(GetListLocationQuery request, CancellationToken cancellationToken)
        {
            var locations = await _locationRepository.GetAllAsync(null);
            if (locations == null || locations.Count == 0)
            {
                throw new NotFoundException("Varış veya kalkış noktaları bulunamadı.");
            }
            try
            {
                var mappingLocations = _mapper.Map<List<GetListLocationQueryResult>>(locations);
                return mappingLocations;
            }
            catch
            {
                throw new CustomInternalServerException("Varış veya kalkış noktaları iletilirken bir hata oluştu.");
            }
        }
    }
}
