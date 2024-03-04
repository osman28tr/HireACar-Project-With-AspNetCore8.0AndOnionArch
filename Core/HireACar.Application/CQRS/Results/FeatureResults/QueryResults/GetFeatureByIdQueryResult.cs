using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireACar.Application.CQRS.Results.FeatureResults.QueryResults
{
    public class GetFeatureByIdQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
