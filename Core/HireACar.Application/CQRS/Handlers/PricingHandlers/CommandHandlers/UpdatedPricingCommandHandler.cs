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
    public class UpdatedPricingCommandHandler : IRequestHandler<UpdatedPricingCommand>
    {
        private readonly IPricingRepository _pricingRepository;
        private readonly IMapper _mapper;
        public UpdatedPricingCommandHandler(IPricingRepository pricingRepository, IMapper mapper)
        {
            _pricingRepository = pricingRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdatedPricingCommand request, CancellationToken cancellationToken)
        {
            var pricing = await _pricingRepository.GetAsync(x => x.Id == request.Id);
            if (pricing == null)
                throw new NotFoundException("Güncellemek istediğiniz fiyatlandırma bilgisi sistemde bulunamadı.");
            try
            {
                var updatedPricing = _mapper.Map(request, pricing);
                await _pricingRepository.UpdateAsync(updatedPricing);
            }
            catch
            {
                throw new CustomInternalServerException(
                                       "Fiyatlandırma bilgisi güncelleme işlemi sırasında bir hata oluştu.");
            }
        }
    }
}
