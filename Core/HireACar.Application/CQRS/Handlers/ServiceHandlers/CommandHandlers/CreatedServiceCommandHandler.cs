using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.ServiceCommands;
using HireACar.CrossCuttingConcerns.Exceptions;
using HireACar.Domain.Entities;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.ServiceHandlers.CommandHandlers
{
    public class CreatedServiceCommandHandler:IRequestHandler<CreatedServiceCommand>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;
        public CreatedServiceCommandHandler(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }
        public async Task Handle(CreatedServiceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var service = _mapper.Map<Service>(request);
                await _serviceRepository.AddAsync(service);
            }
            catch
            {
                throw new CustomInternalServerException(
                                       "Hizmet ekleme işlemi sırasında bir hata oluştu.");
            }
        }
    }
}
