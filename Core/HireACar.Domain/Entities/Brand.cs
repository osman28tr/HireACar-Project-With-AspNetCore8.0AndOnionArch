﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireACar.Domain.Entities
{
    public class Brand:BaseEntity
    {
        public Brand()
        {
            Cars = new List<Car>();
            Models = new List<Model>();
        }
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
        public List<Model> Models { get; set; }
    }
}
