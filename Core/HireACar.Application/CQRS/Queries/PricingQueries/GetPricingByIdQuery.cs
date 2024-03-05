using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.CQRS.Results.PricingResults.QueryResults;
using MediatR;

namespace HireACar.Application.CQRS.Queries.PricingQueries
{
    public class GetPricingByIdQuery: IRequest<GetPricingByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
