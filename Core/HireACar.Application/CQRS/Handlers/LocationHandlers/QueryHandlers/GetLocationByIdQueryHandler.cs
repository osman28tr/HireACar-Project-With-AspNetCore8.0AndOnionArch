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

namespace HireACar.Application.CQRS.Handlers.LocationHandlers.QueryHandlers
{
    public class GetLocationByIdQueryHandler:IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        public GetLocationByIdQueryHandler(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }
        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var location = await _locationRepository.GetAsync(x => x.Id == request.Id);
            return location == null
                ? throw new NotFoundException("Konum bulunamadı.")
                : _mapper
                    .Map<GetLocationByIdQueryResult>(location);
        }
    }
}
