using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireACar.Application.CQRS.Results.CategoryResults.QueryResults
{
    public class GetCategoryByIdQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
