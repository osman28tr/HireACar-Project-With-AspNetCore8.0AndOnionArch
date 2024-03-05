using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.CQRS.Commands.LocationCommands;
using HireACar.Application.CQRS.Results.LocationResults.QueryResults;
using HireACar.Domain.Entities;

namespace HireACar.Application.Mappings.AutoMapper.LocationMapping
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<GetListLocationQueryResult,Location>().ReverseMap();
            CreateMap<GetLocationByIdQueryResult,Location>().ReverseMap();

            CreateMap<CreatedLocationCommand,Location>().ReverseMap();
            CreateMap<UpdatedLocationCommand,Location>().ReverseMap();
        }
    }
}
