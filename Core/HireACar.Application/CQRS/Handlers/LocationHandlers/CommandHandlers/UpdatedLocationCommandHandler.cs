using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.LocationCommands;
using HireACar.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.LocationHandlers.CommandHandlers
{
    public class UpdatedLocationCommandHandler: IRequestHandler<UpdatedLocationCommand>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        public UpdatedLocationCommandHandler(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdatedLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _locationRepository.GetAsync(x => x.Id == request.Id);
            if(location == null)
                throw new NotFoundException("Güncellemek istediğiniz konum bulunamadı.");
            try
            {
                _mapper.Map(request, location);
                await _locationRepository.UpdateAsync(location);
            }
            catch
            {
                throw new CustomInternalServerException("Konum güncelleme sırasında bir hata oluştu.");
            }
        }
    }
}
