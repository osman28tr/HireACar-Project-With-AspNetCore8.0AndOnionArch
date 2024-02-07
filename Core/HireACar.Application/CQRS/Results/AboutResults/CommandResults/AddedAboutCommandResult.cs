using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireACar.Application.CQRS.Results.AboutResults.CommandResults
{
    public class AddedAboutCommandResult
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
