using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireACar.Domain.Entities
{
    public class Car: BaseEntity
    {
        public int BrandId { get; set; }
        public string CoverImageUrl { get; set; }
        public string BodyImageUrl { get; set; }
        public string Km { get; set; }
        public string Desription { get; set; }
        public TransmissionType Transmission { get; set; }
        public char Seat { get; set; }
        public byte Luggage { get; set; }
        public FuelType Fuel { get; set; }
        public Brand Brand { get; set; }
        public List<Feature> Features { get; set; }
        public List<Pricing> Pricings { get; set; }
        public enum TransmissionType
        {
            Automatic,
            HalfAutomatic,
            Manual
        }

        public enum FuelType
        {
            Gasoline,
            Diesel,
            Electric,
            Hybrid
        }
    }

}
