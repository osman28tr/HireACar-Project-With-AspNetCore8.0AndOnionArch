using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HireACar.CrossCuttingConcerns.Exceptions
{
    public class BusinessProblemDetails: ProblemDetails
    {
        public string Message { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
