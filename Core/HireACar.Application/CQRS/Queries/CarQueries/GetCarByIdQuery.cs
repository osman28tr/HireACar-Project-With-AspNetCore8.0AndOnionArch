using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.CQRS.Results.CarResults.QueryResults;
using MediatR;

namespace HireACar.Application.CQRS.Queries.CarQueries
{
    public class GetCarByIdQuery:IRequest<GetCarByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
