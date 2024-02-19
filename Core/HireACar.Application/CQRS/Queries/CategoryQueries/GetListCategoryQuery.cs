using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.CQRS.Results.CategoryResults.QueryResults;
using MediatR;

namespace HireACar.Application.CQRS.Queries.CategoryQueries
{
    public class GetListCategoryQuery:IRequest<List<GetListCategoryQueryResult>>
    {
    }
}
