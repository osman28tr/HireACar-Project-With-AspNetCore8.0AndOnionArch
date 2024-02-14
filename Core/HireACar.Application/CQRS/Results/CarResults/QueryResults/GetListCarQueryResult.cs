using HireACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HireACar.Domain.Entities.Car;
using HireACar.Application.CQRS.ViewModels.Cars;

namespace HireACar.Application.CQRS.Results.CarResults.QueryResults
{
    public class GetListCarQueryResult
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string CoverImageUrl { get; set; }
        public string BodyImageUrl { get; set; }
        public string Km { get; set; }
        public string Desription { get; set; }
        public TransmissionType Transmission { get; set; }
        public char Seat { get; set; }
        public byte Luggage { get; set; }
        public FuelType Fuel { get; set; }
        public CarWithBrandViewModel CarWithBrandViewModel { get; set; }
        public List<CarWithFeatureViewModel> Features { get; set; }
        public List<CarWithPricingViewModel> Pricings { get; set; }
    }
}
