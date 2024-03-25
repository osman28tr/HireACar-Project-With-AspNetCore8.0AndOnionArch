using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.CQRS.Commands.TestimonialCommands;
using HireACar.Application.CQRS.Queries.TestimonialQueries;
using HireACar.Application.CQRS.Results.TestimonialResults.QueryResults;
using HireACar.Domain.Entities;

namespace HireACar.Application.Mappings.AutoMapper.TestimonialMapping
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<GetListTestimonialQueryResult, Testimonial>().ReverseMap();
            CreateMap<GetTestimonialByIdQueryResult, Testimonial>().ReverseMap();

            CreateMap<CreatedTestimonialCommand, Testimonial>().ReverseMap();
            CreateMap<UpdatedTestimonialCommand, Testimonial>().ReverseMap();
        }
    }
}
