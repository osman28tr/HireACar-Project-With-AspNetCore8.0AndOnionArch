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
    public class GetListFeatureQueryHandler : IRequestHandler<GetListFeatureQuery, List<GetListFeatureQueryResult>>
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IMapper _mapper;
        public GetListFeatureQueryHandler(IFeatureRepository featureRepository, IMapper mapper)
        {
            _featureRepository = featureRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListFeatureQueryResult>> Handle(GetListFeatureQuery request,
            CancellationToken cancellationToken)
        {
            var features = await _featureRepository.GetAllAsync(null);
            if (features == null)
                throw new NotFoundException("Özellikler bulunamadı.");
            try
            {
                var mappingFeatures = _mapper.Map<List<GetListFeatureQueryResult>>(features);
                return mappingFeatures;
            }
            catch
            {
                throw new CustomInternalServerException("Özellikler listelenirken bir hata oluştu.");
            }
        }
    }
}
