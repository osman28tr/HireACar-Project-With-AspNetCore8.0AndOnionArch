using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.CQRS.Results.WebSiteSettingResults.QueryResults;
using MediatR;

namespace HireACar.Application.CQRS.Queries.WebSiteSettingQueries
{
    public class GetWebSiteSettingQuery:IRequest<GetWebSiteSettingQueryResult>
    {
    }
}
