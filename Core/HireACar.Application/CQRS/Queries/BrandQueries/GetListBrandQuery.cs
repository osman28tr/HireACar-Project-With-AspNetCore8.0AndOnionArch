using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.CQRS.Results.BrandResults.QueryResults;
using MediatR;

namespace HireACar.Application.CQRS.Queries.BrandQueries
{
    public class GetListBrandQuery:IRequest<List<GetListBrandQueryResult>>
    {
    }
}
