using HireACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.CQRS.Dtos.CarDtos;
using MediatR;
using static HireACar.Domain.Entities.Car;

namespace HireACar.Application.CQRS.Commands.CarCommands
{
    public class CreatedCarCommand:IRequest
    {
        public CreatedCarCommand()
        {
            Features = new List<CreatedCarWithFeatureDto>();
            Pricings = new List<CreatedCarWithPricingDto>();
        }
        public int BrandId { get; set; }
        public string CoverImageUrl { get; set; }
        public string BodyImageUrl { get; set; }
        public string Km { get; set; }
        public string Desription { get; set; }
        public TransmissionType Transmission { get; set; }
        public char Seat { get; set; }
        public byte Luggage { get; set; }
        public FuelType Fuel { get; set; }
        public List<CreatedCarWithFeatureDto> Features { get; set; }
        public List<CreatedCarWithPricingDto> Pricings { get; set; }
    }
}
