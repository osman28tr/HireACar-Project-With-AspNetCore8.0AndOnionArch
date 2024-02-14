using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.CQRS.Results.CarResults.QueryResults;
using HireACar.Application.CQRS.ViewModels.Cars;
using HireACar.Domain.Entities;

namespace HireACar.Application.Mappings.AutoMapper.CarMapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<GetListCarQueryResult, Car>()
            //    .ForMember(x => x.Features, opt => opt.MapFrom(src => src.Features))
            //    .ForMember(x => x.Pricings, opt => opt.MapFrom(src => src.Pricings))
                .ForMember(x => x.Brand, opt => opt.MapFrom(src => src.CarWithBrandViewModel))
                .ReverseMap();
            //CreateMap<CarWithFeatureViewModel, Feature>().ReverseMap();
            //CreateMap<CarWithPricingViewModel, Pricing>().ReverseMap();
            CreateMap<CarWithBrandViewModel, Brand>().ReverseMap();
        }
    }
}
