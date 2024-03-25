using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.CQRS.Results.TestimonialResults.QueryResults;
using MediatR;

namespace HireACar.Application.CQRS.Queries.TestimonialQueries
{
    public class GetTestimonialByIdQuery:IRequest<GetTestimonialByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
