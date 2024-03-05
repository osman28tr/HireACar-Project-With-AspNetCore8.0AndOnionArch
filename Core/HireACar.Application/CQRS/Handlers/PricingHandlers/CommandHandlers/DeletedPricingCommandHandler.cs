using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.PricingCommands;
using HireACar.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.PricingHandlers.CommandHandlers
{
    public class DeletedPricingCommandHandler:IRequestHandler<DeletedPricingCommand>
    {
        private readonly IPricingRepository _pricingRepository;
        private readonly IMapper _mapper;
        public DeletedPricingCommandHandler(IPricingRepository pricingRepository, IMapper mapper)
        {
            _pricingRepository = pricingRepository;
            _mapper = mapper;
        }
        public async Task Handle(DeletedPricingCommand request, CancellationToken cancellationToken)
        {
            var pricing = await _pricingRepository.GetAsync(x => x.Id == request.Id);
            if (pricing == null)
                throw new NotFoundException("Silmek istediğiniz fiyatlandırma bilgisi sistemde bulunamadı.");
            try
            {
                await _pricingRepository.DeleteAsync(pricing);
            }
            catch
            {
                throw new CustomInternalServerException(
                                       "Fiyatlandırma bilgisi silme işlemi sırasında bir hata oluştu.");
            }
        }
    }
}
