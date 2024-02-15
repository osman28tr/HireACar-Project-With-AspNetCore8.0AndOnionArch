using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Queries.CarQueries;
using HireACar.Application.CQRS.Results.CarResults.QueryResults;
using HireACar.CrossCuttingConcerns.Exceptions;
using HireACar.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HireACar.Application.CQRS.Handlers.CarHandlers.QueryHandlers
{
    public class GetCarByIdQueryHandler:IRequestHandler<GetCarByIdQuery, GetCarByIdQueryResult>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetCarByIdQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.Query().Include(x => x.CarFeatures).ThenInclude(f => f.Feature)
                .Include(x => x.CarPricings).ThenInclude(p => p.Pricing).Include(x => x.Brand)
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if (car == null)
                throw new Exception("Araç bulunamadı.");
            var carMapping = _mapper.Map<GetCarByIdQueryResult>(car);
            return carMapping;
        }
    }
}
