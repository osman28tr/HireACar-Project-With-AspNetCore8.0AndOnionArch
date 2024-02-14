using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HireACar.Persistance.Concrete.EntityConfigurations
{
    public class CarPricingConfiguration:IEntityTypeConfiguration<CarPricing>
    {
        public void Configure(EntityTypeBuilder<CarPricing> builder)
        {
            builder.HasKey(cp => new { cp.CarId, cp.PricingId });

            builder.HasOne(cp => cp.Car).WithMany(c => c.CarPricings).HasForeignKey(cp => cp.CarId);

            builder.HasOne(cp => cp.Pricing)
                .WithMany(p => p.CarPricings)
                .HasForeignKey(cp => cp.PricingId);
        }
    }
}
