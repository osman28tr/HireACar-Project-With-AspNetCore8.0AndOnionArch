﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireACar.Application.CQRS.Results.BrandResults.QueryResults
{
    public class GetBrandByIdQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
