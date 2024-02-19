using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireACar.Application.Abstract
{
    public interface IUnitOfWork
    {
        IAboutRepository Abouts { get; }
        IBrandRepository Brands { get; }
        Task<int> SaveAsync();
    }
}
