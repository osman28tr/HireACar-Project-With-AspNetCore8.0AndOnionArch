using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.FeatureCommands;
using HireACar.CrossCuttingConcerns.Exceptions;
using HireACar.Domain.Entities;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.FeatureHandlers.CommandHandlers
{
    public class CreatedFeatureCommandHandler:IRequestHandler<CreatedFeatureCommand>
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IMapper _mapper;
        public CreatedFeatureCommandHandler(IFeatureRepository featureRepository, IMapper mapper)
        {
            _featureRepository = featureRepository;
            _mapper = mapper;
        }
        public async Task Handle(CreatedFeatureCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var feature = _mapper.Map<Feature>(request);
                await _featureRepository.AddAsync(feature);
            }
            catch
            {
                throw new CustomInternalServerException("Özellik ekleme sırasında bir hata oluştu.");
            }
        }
    }
}
