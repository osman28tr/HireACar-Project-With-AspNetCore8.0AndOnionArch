using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.CQRS.Commands.SocialMediaCommands;
using HireACar.Application.CQRS.Results.SocialMediaResults.QueryResults;
using HireACar.Domain.Entities;

namespace HireACar.Application.Mappings.AutoMapper.SocialMediaMapping
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<GetListSocialMediaQueryResult, SocialMedia>().ReverseMap();
            CreateMap<GetSocialMediaByIdQueryResult, SocialMedia>().ReverseMap();

            CreateMap<CreatedSocialMediaCommand, SocialMedia>().ReverseMap();
            CreateMap<UpdatedSocialMediaCommand, SocialMedia>().ReverseMap();
        }
    }
}
