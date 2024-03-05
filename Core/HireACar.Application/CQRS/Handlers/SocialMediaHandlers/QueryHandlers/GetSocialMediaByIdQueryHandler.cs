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
    public class GetSocialMediaByIdQueryHandler:IRequestHandler<GetSocialMediaByIdQuery,GetSocialMediaByIdQueryResult>
    {
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly IMapper _mapper;
        public GetSocialMediaByIdQueryHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper)
        {
            _socialMediaRepository = socialMediaRepository;
            _mapper = mapper;
        }
        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var socialMedia = await _socialMediaRepository.GetAsync(x => x.Id == request.Id);
            if (socialMedia == null)
                throw new NotFoundException("Sosyal medya bilgisi bulunamadı.");
            return _mapper.Map<GetSocialMediaByIdQueryResult>(socialMedia);
        }
    }
}
