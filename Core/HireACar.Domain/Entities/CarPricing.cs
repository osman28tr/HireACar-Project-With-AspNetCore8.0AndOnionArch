using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireACar.Domain.Entities
{
    public class CarPricing
    {
        public int CarId { get; set; }
        public int PricingId { get; set; }
        public decimal Price { get; set; }
        public Car Car { get; set; }
        public Pricing Pricing { get; set; }
    }
}
