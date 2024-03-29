﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.CarCommands;
using HireACar.Domain.Entities;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.CarHandlers.CommandHandlers
{
    public class CreatedCarCommandHandler:IRequestHandler<CreatedCarCommand>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CreatedCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreatedCarCommand request, CancellationToken cancellationToken)
        {
            var car = _mapper.Map<Car>(request);
            await _carRepository.AddAsync(car);
        }
    }
}
