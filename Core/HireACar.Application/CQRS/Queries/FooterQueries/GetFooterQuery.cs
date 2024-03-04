using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.CQRS.Results.FooterResults.QueryResults;
using MediatR;

namespace HireACar.Application.CQRS.Queries.FooterQueries
{
    public class GetFooterQuery:IRequest<GetFooterQueryResult>
    {
    }
}
