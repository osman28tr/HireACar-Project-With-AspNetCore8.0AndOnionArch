using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.CQRS.Results.LocationResults.QueryResults;
using MediatR;

namespace HireACar.Application.CQRS.Queries.LocationQueries
{
    public class GetListLocationQuery:IRequest<List<GetListLocationQueryResult>>
    {
    }
}
