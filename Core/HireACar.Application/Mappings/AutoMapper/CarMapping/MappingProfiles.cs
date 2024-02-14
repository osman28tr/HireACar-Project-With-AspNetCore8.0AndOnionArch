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
            CreateMap<Car, GetListCarQueryResult>()
                .ForMember(
                    x => x.Features, c => c.MapFrom(x => x.CarFeatures.Select(x => x.Feature).ToList()))
                .ForMember(
                    x => x.Pricings, c => c.MapFrom(x => x.CarPricings.Select(x => x.Pricing).ToList()))
                .ForMember(x => x.CarWithBrandViewModel, opt => opt.MapFrom(src => src.Brand))
                .ReverseMap();
            CreateMap<CarWithFeatureViewModel, Feature>().ReverseMap();
            CreateMap<CarWithPricingViewModel, Pricing>().ReverseMap();
            CreateMap<CarWithBrandViewModel, Brand>().ReverseMap();
        }
    }
}
