using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.PricingCommands;
using HireACar.CrossCuttingConcerns.Exceptions;
using HireACar.Domain.Entities;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.PricingHandlers.CommandHandlers
{
    public class CreatedPricingCommandHandler:IRequestHandler<CreatedPricingCommand>
    {
        private readonly IPricingRepository _pricingRepository;
        private readonly IMapper _mapper;
        public CreatedPricingCommandHandler(IPricingRepository pricingRepository, IMapper mapper)
        {
            _pricingRepository = pricingRepository;
            _mapper = mapper;
        }
        public async Task Handle(CreatedPricingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pricing = _mapper.Map<Pricing>(request);
                await _pricingRepository.AddAsync(pricing);
            }
            catch
            {
                throw new CustomInternalServerException(
                    "Fiyatlandırma bilgisi ekleme işlemi sırasında bir hata oluştu.");
            }
        }
    }
}
