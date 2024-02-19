using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.CQRS.Results.CategoryResults.QueryResults;

namespace HireACar.Application.CQRS.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery:IRequest<GetCategoryByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
