using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireACar.Application.CQRS.Results.ContactResults.QueryResults
{
    public class GetListContactQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }
    }
}
