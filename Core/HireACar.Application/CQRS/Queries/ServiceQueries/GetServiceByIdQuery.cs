﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.CQRS.Results.ServiceResults.QueryResults;
using MediatR;

namespace HireACar.Application.CQRS.Queries.ServiceQueries
{
    public class GetServiceByIdQuery:IRequest<GetServiceByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
