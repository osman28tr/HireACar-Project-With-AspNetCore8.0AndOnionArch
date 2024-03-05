using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.CQRS.Commands.PricingCommands;
using HireACar.Application.CQRS.Results.PricingResults.QueryResults;
using HireACar.Domain.Entities;

namespace HireACar.Application.Mappings.AutoMapper.PricingMapping
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<GetListPricingQueryResult,Pricing>().ReverseMap();
            CreateMap<GetPricingByIdQueryResult,Pricing>().ReverseMap();

            CreateMap<CreatedPricingCommand,Pricing>().ReverseMap();
            CreateMap<UpdatedPricingCommand,Pricing>().ReverseMap();
        }
    }
}
