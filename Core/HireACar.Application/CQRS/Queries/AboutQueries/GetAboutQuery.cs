using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.CQRS.Results.AboutResults.QueryResults;
using MediatR;

namespace HireACar.Application.CQRS.Queries.AboutQueries
{
    public class GetAboutQuery:IRequest<GetAboutQueryResult>
    {
    }
}
