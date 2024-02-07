using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireACar.Insfrastructure.Caching.Abstract
{
    public interface IRsCacheService
    {
        void Set(string key, string value);
        string Get(string key);
    }
}
