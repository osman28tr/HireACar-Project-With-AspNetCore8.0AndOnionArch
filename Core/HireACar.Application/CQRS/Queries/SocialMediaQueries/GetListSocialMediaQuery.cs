using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.CQRS.Results.SocialMediaResults.QueryResults;
using MediatR;

namespace HireACar.Application.CQRS.Queries.SocialMediaQueries
{
    public class GetListSocialMediaQuery:IRequest<List<GetListSocialMediaQueryResult>>
    {
    }
}
