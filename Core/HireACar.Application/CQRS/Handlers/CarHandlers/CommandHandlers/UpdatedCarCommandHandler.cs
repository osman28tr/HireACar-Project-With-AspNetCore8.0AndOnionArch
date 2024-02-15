using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.CarCommands;
using HireACar.CrossCuttingConcerns.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HireACar.Application.CQRS.Handlers.CarHandlers.CommandHandlers
{
    public class UpdatedCarCommandHandler:IRequestHandler<UpdatedCarCommand>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public UpdatedCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdatedCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.Query().Include(x => x.CarFeatures)
                .ThenInclude(x => x.Feature).Include(x => x.CarPricings).ThenInclude(x => x.Pricing)
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if (car == null)
                throw new BusinessException("Araç bulunamadı.");
            _mapper.Map(request, car);
            await _carRepository.UpdateAsync(car);
        }
    }
}
