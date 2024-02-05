using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HireACar.Persistance.Contexts
{
    public class HireACarContext:DbContext
    {
        public HireACarContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<WebSiteSetting> WebSiteSettings { get; set; }
    }
}
