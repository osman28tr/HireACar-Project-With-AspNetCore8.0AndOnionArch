using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Queries.WebSiteSettingQueries;
using HireACar.Application.CQRS.Results.WebSiteSettingResults.QueryResults;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.WebSiteSettingHandlers.QueryHandlers
{
    public class GetWebSiteSettingQueryHandler:IRequestHandler<GetWebSiteSettingQuery,GetWebSiteSettingQueryResult>
    {
        private readonly IWebSiteSettingRepository _webSiteSettingRepository;
        private readonly IMapper _mapper;

        public GetWebSiteSettingQueryHandler(IWebSiteSettingRepository webSiteSettingRepository,IMapper mapper)
        {
            _webSiteSettingRepository = webSiteSettingRepository;
            _mapper = mapper;
        }
        public async Task<GetWebSiteSettingQueryResult> Handle(GetWebSiteSettingQuery request, CancellationToken cancellationToken)
        {
            var webSiteSetting = _webSiteSettingRepository.GetAllAsync(null).Result.FirstOrDefault();
            var webSiteSettingMapping = _mapper.Map<GetWebSiteSettingQueryResult>(webSiteSetting);
            return webSiteSettingMapping;
        }
    }
}
