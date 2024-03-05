using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Queries.SocialMediaQueries;
using HireACar.Application.CQRS.Results.SocialMediaResults.QueryResults;
using HireACar.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.SocialMediaHandlers.QueryHandlers
{
    public class GetListSocialMediaQueryHandler:IRequestHandler<GetListSocialMediaQuery,List<GetListSocialMediaQueryResult>>
    {
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly IMapper _mapper;
        public GetListSocialMediaQueryHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper)
        {
            _socialMediaRepository = socialMediaRepository;
            _mapper = mapper;
        }
        public async Task<List<GetListSocialMediaQueryResult>> Handle(GetListSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var socialMedias = await _socialMediaRepository.GetAllAsync(null);
            if (socialMedias == null || socialMedias.Count == 0)
                throw new NotFoundException("Sosyal medya bilgileri bulunamadı.");
            return _mapper.Map<List<GetListSocialMediaQueryResult>>(socialMedias);
        }
    }
}
