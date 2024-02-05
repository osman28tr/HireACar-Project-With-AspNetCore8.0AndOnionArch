using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireACar.Domain.Entities
{
    public class CarFeature
    {
        public int CarId { get; set; }
        public int FeatureId { get; set; }
        public Car Car { get; set; }
        public Feature Feature { get; set; }
        public bool IsAvailable { get; set; }
    }
}
