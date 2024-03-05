using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.LocationCommands;
using HireACar.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.LocationHandlers.CommandHandlers
{
    public class DeletedLocationCommandHandler:IRequestHandler<DeletedLocationCommand>
    {
        private readonly ILocationRepository _locationRepository;
        public DeletedLocationCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public async Task Handle(DeletedLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _locationRepository.GetAsync(x => x.Id == request.Id);
            if(location == null)
                throw new NotFoundException("Silmek istediğiniz konum bulunamadı.");
            try
            {
                await _locationRepository.DeleteAsync(location);
            }
            catch
            {
                throw new CustomInternalServerException("Konum silme sırasında bir hata oluştu.");
            }
        }
    }
}
