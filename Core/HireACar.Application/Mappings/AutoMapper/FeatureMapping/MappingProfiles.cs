using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.CQRS.Commands.FeatureCommands;
using HireACar.Application.CQRS.Results.FeatureResults.QueryResults;
using HireACar.Domain.Entities;

namespace HireACar.Application.Mappings.AutoMapper.FeatureMapping
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<GetListFeatureQueryResult, Feature>().ReverseMap();
            CreateMap<GetFeatureByIdQueryResult, Feature>().ReverseMap();

            CreateMap<CreatedFeatureCommand,Feature>().ReverseMap();
            CreateMap<UpdatedFeatureCommand, Feature>().ReverseMap();
        }
    }
}
