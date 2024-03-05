using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.LocationCommands;
using HireACar.CrossCuttingConcerns.Exceptions;
using HireACar.Domain.Entities;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.LocationHandlers.CommandHandlers
{
    public class CreatedLocationCommandHandler:IRequestHandler<CreatedLocationCommand>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        public CreatedLocationCommandHandler(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }
        public async Task Handle(CreatedLocationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var location = _mapper.Map<Location>(request);
                await _locationRepository.AddAsync(location);
            }
            catch
            {
                throw new CustomInternalServerException("Konum ekleme sırasında bir hata oluştu.");
            }
        }
    }
}
