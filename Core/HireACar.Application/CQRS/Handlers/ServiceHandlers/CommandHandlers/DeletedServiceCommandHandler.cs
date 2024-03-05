using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.ServiceCommands;
using HireACar.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.ServiceHandlers.CommandHandlers
{
    public class DeletedServiceCommandHandler:IRequestHandler<DeletedServiceCommand>
    {
        private readonly IServiceRepository _serviceRepository;
        public DeletedServiceCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task Handle(DeletedServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetAsync(x => x.Id == request.Id);
            if (service == null)
                throw new NotFoundException("Sistemde kayıtlı hizmet bulunamadı.");
            try
            {
                await _serviceRepository.DeleteAsync(service);
            }
            catch
            {
                throw new CustomInternalServerException("Hizmet silme işlemi sırasında bir hata oluştu.");
            }
        }
    }
}
