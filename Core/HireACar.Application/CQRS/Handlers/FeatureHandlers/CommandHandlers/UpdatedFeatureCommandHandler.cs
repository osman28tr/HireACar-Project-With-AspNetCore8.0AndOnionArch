using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.FeatureCommands;
using HireACar.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.FeatureHandlers.CommandHandlers
{
    public class UpdatedFeatureCommandHandler:IRequestHandler<UpdatedFeatureCommand>
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IMapper _mapper;
        public UpdatedFeatureCommandHandler(IFeatureRepository featureRepository, IMapper mapper)
        {
            _featureRepository = featureRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdatedFeatureCommand request, CancellationToken cancellationToken)
        {
            var feature = await _featureRepository.GetAsync(x => x.Id == request.Id);
            if (feature == null)
                throw new NotFoundException("Güncellemek istediğiniz özellik bulunamadı.");
            try
            {
                var updatedFeature = _mapper.Map(request, feature);
                await _featureRepository.UpdateAsync(updatedFeature);
            }
            catch
            {
                throw new CustomInternalServerException("Özellik güncelleme sırasında bir hata oluştu.");
            }
        }
    }
}
