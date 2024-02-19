using HireACar.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Persistance.Concrete.Repositories;
using HireACar.Persistance.Contexts;

namespace HireACar.Persistance.Concrete
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly HireACarContext _context;
        private AboutRepository _aboutRepository;
        private BrandRepository _brandRepository;
        public UnitOfWork(HireACarContext context)
        {
            _context = context;
        }
        public IAboutRepository Abouts => _aboutRepository ?? new AboutRepository(_context);

        public IBrandRepository Brands => _brandRepository ?? new BrandRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
