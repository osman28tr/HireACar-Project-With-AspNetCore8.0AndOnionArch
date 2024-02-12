using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.CQRS.Commands.BrandCommands;
using HireACar.Application.CQRS.Queries.BrandQueries;
using HireACar.Application.CQRS.Results.BrandResults.QueryResults;
using HireACar.Domain.Entities;

namespace HireACar.Application.Mappings.AutoMapper.BrandMapping
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<GetListBrandQueryResult, Brand>().ReverseMap();
            CreateMap<GetBrandByIdQueryResult, Brand>().ReverseMap();
            CreateMap<UpdatedBrandCommand, Brand>().ReverseMap();
        }
    }
}
