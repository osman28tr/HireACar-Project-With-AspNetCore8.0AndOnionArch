using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.CQRS.Commands.AboutCommands;
using HireACar.Application.CQRS.Results.AboutResults.CommandResults;
using HireACar.Application.CQRS.Results.AboutResults.QueryResults;
using HireACar.Domain.Entities;

namespace HireACar.Application.Mappings.AutoMapper.AboutMapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<About, GetAboutQueryResult>().ReverseMap();

            CreateMap<CreatedAboutCommand, About>().ReverseMap();
            CreateMap<AddedAboutCommandResult, About>().ReverseMap();
            CreateMap<UpdatedAboutCommand, About>().ReverseMap();
            CreateMap<UpdatedAboutCommandResult, About>().ReverseMap();
            CreateMap<DeletedAboutCommand, About>().ReverseMap();
            CreateMap<DeletedAboutCommandResult, About>().ReverseMap();
        }
    }
}
