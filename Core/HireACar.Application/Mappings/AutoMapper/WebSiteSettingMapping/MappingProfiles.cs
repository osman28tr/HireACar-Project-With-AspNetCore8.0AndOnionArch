using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.CQRS.Results.WebSiteSettingResults.QueryResults;
using HireACar.Domain.Entities;

namespace HireACar.Application.Mappings.AutoMapper.WebSiteSettingMapping
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<GetWebSiteSettingQueryResult, WebSiteSetting>().ReverseMap();
        }
    }
}
