using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.BrandCommands;
using HireACar.Application.CQRS.Results.BrandResults.CommandResults;
using HireACar.Domain.Entities;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.BrandHandlers.CommandHandlers
{
    public class CreatedBrandCommandHandler:IRequestHandler<CreatedBrandCommand,CreatedBrandCommandResult>
    {
        private readonly IBrandRepository _brandRepository;

        public CreatedBrandCommandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<CreatedBrandCommandResult> Handle(CreatedBrandCommand request, CancellationToken cancellationToken)
        {
            Brand brand = new Brand() { Name = request.Name };
            brand.Models.AddRange(request.CreatedModelDtos.Select(x => new Model() { Name = x.Name }));
            var result = await _brandRepository.AddAsync(brand);
            return new CreatedBrandCommandResult() { Name = result.Name };
        }
    }
}
