using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.CQRS.Commands.ContactCommands;
using HireACar.Application.CQRS.Results.ContactResults.QueryResults;
using HireACar.Domain.Entities;

namespace HireACar.Application.Mappings.AutoMapper.ContactMapping
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<GetListContactQueryResult, Contact>().ReverseMap();
            CreateMap<GetContactByIdQueryResult, Contact>().ReverseMap();

            CreateMap<CreatedContactCommand, Contact>().ReverseMap();
        }
    }
}
