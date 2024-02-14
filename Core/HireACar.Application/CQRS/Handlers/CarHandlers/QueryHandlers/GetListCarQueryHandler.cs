using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Queries.CarQueries;
using HireACar.Application.CQRS.Results.CarResults.QueryResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HireACar.Application.CQRS.Handlers.CarHandlers.QueryHandlers
{
    public class GetListCarQueryHandler:IRequestHandler<GetListCarQuery,List<GetListCarQueryResult>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        public GetListCarQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }
        public async Task<List<GetListCarQueryResult>> Handle(GetListCarQuery request, CancellationToken cancellationToken)
        {
            var cars = await _carRepository.Query()/*.Include(x => x.Features).Include(x => x.Pricings)*/
                .Include(x => x.Brand).ToListAsync();
            var carsMapping = _mapper.Map<List<GetListCarQueryResult>>(cars);
            return carsMapping;
        }
    }
}
