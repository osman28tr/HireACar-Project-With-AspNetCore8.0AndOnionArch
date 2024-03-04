using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.CQRS.Results.FooterResults.QueryResults;
using HireACar.Domain.Entities;

namespace HireACar.Application.Mappings.AutoMapper.FooterMapping
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<GetFooterQueryResult, Footer>().ReverseMap();
        }
    }
}
