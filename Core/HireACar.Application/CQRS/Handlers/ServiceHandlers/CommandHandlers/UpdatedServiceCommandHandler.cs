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
    public class UpdatedServiceCommandHandler : IRequestHandler<UpdatedServiceCommand>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;
        public UpdatedServiceCommandHandler(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdatedServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetAsync(x => x.Id == request.Id);
            if (service == null)
                throw new NotFoundException("Sistemde kayıtlı hizmet bulunamadı.");
            var updatedService = _mapper.Map(request, service);
            try
            {
                await _serviceRepository.UpdateAsync(updatedService);
            }
            catch
            {
                throw new CustomInternalServerException("Hizmet güncelleme işlemi sırasında bir hata oluştu.");
            }
        }
    }
}
