using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireACar.Domain.Entities
{
    public class Feature:BaseEntity
    {
        public string Name { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
    }
}
