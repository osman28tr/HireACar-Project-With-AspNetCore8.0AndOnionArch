﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireACar.Domain.Entities
{
    public class Pricing:BaseEntity
    {
        public string Name { get; set; }
        public List<CarPricing> CarPricings { get; set; }
    }
}
