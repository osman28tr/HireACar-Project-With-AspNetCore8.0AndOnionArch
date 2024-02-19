﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.Abstract;
using HireACar.Persistance.Concrete.Repositories;

namespace HireACar.Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistanceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<IWebSiteSettingRepository, WebSiteSettingRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<IPricingRepository, PricingRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            return services;
        }
    }
}
