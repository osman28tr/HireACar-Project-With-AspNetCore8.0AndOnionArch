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
    public class CarFeatureConfiguration:IEntityTypeConfiguration<CarFeature>
    {
        public void Configure(EntityTypeBuilder<CarFeature> builder)
        {
            builder.HasKey(cf => new { cf.CarId, cf.FeatureId });

            builder.HasOne(cf => cf.Car)
                .WithMany(c => c.CarFeatures)
                .HasForeignKey(cf => cf.CarId);

            builder.HasOne(cf => cf.Feature).WithMany(f => f.CarFeatures).HasForeignKey(cf => cf.FeatureId);
        }
    }
}
