using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.Abstract;
using HireACar.Domain.Entities;
using HireACar.Persistance.Contexts;

namespace HireACar.Persistance.Concrete.Repositories
{
    public class ServiceRepository:GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(HireACarContext context) : base(context)
        {
        }
    }
}
