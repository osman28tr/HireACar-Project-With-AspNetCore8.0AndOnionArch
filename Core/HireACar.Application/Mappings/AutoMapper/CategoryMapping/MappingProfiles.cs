using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.CQRS.Commands.CategoryCommands;
using HireACar.Application.CQRS.Results.CategoryResults.QueryResults;
using HireACar.Domain.Entities;

namespace HireACar.Application.Mappings.AutoMapper.CategoryMapping
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<GetListCategoryQueryResult, Category>().ReverseMap();
            CreateMap<GetCategoryByIdQueryResult, Category>().ReverseMap();

            CreateMap<CreatedCategoryCommand, Category>().ReverseMap();
            CreateMap<UpdatedCategoryCommand, Category>().ReverseMap();
        }
    }
}
