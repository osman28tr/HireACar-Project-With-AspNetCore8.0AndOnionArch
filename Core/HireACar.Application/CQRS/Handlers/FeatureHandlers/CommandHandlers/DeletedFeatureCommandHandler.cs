using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.FeatureCommands;
using HireACar.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.FeatureHandlers.CommandHandlers
{
    public class DeletedFeatureCommandHandler:IRequestHandler<DeletedFeatureCommand>
    {
        private readonly IFeatureRepository _featureRepository;
        public DeletedFeatureCommandHandler(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }
        public async Task Handle(DeletedFeatureCommand request, CancellationToken cancellationToken)
        {
            var feature = await _featureRepository.GetAsync(x => x.Id == request.Id);
            if (feature == null)
                throw new NotFoundException("Silmek istediğiniz özellik bulunamadı.");
            try
            {
                await _featureRepository.DeleteAsync(feature);
            }
            catch
            {
                throw new CustomInternalServerException("Özellik silme sırasında bir hata oluştu.");
            }
        }
    }
}
