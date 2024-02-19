using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.CQRS.Results.ContactResults.QueryResults;
using MediatR;

namespace HireACar.Application.CQRS.Queries.ContactQueries
{
    public class GetListContactQuery:IRequest<List<GetListContactQueryResult>>
    {
    }
}
