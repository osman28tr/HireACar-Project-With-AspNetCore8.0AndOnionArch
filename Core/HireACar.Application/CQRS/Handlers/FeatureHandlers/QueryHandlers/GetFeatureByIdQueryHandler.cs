using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Queries.FeatureQueries;
using HireACar.Application.CQRS.Results.FeatureResults.QueryResults;
using HireACar.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.FeatureHandlers.QueryHandlers
{
    public class GetFeatureByIdQueryHandler:IRequestHandler<GetFeatureByIdQuery,GetFeatureByIdQueryResult>
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IMapper _mapper;
        public GetFeatureByIdQueryHandler(IFeatureRepository featureRepository, IMapper mapper)
        {
            _featureRepository = featureRepository;
            _mapper = mapper;
        }
        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var feature = await _featureRepository.GetAsync(x => x.Id == request.Id);
            if (feature == null)
                throw new NotFoundException("Özellik bulunamadı.");
            try
            {
                var mappingFeature = _mapper.Map<GetFeatureByIdQueryResult>(feature);
                return mappingFeature;
            }
            catch
            {
                throw new CustomInternalServerException("Özellik getirilirken bir hata oluştu.");
            }
        }
    }
}
