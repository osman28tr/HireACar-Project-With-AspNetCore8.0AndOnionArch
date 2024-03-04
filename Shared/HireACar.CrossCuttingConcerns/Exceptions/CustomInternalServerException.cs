using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireACar.CrossCuttingConcerns.Exceptions
{
    public class CustomInternalServerException : Exception
    {
        public CustomInternalServerException(string message):base(message)
        {
        }
    }
}
