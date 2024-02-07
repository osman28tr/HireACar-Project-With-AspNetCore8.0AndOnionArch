using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Insfrastructure.Caching.Abstract;
using HireACar.Insfrastructure.Caching.Redis.About;
using HireACar.Insfrastructure.Caching.Redis.About.Abstract;

namespace HireACar.Insfrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services)
        {
            services.AddScoped<IRsAboutCacheService, RsAboutCacheService>();
            return services;
        }
    }
}
