using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.CQRS.Results.AboutResults.QueryResults;
using HireACar.Domain.Entities;

namespace HireACar.Application.Mappings.AboutMapping
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<About, GetAboutQueryResult>().ReverseMap();
        }
    }
}
