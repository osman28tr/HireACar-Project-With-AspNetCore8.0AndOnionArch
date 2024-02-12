using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.BrandCommands;
using HireACar.Application.CQRS.Results.BrandResults.CommandResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HireACar.Application.CQRS.Handlers.BrandHandlers.CommandHandlers
{
    public class DeletedBrandCommandHandler : IRequestHandler<DeletedBrandCommand, DeletedBrandCommandResult>
    {
        private readonly IBrandRepository _brandRepository;
        public DeletedBrandCommandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<DeletedBrandCommandResult> Handle(DeletedBrandCommand request, CancellationToken cancellationToken)
        {
            var deleteBrand = _brandRepository.Query().Include(x => x.Models).FirstOrDefault(x => x.Id == request.BrandId);
            if (deleteBrand == null)
                throw new Exception("Brand bulunamadı.");
            await _brandRepository.DeleteAsync(deleteBrand);
            return new DeletedBrandCommandResult() { Name = deleteBrand.Name };
        }
    }
}
