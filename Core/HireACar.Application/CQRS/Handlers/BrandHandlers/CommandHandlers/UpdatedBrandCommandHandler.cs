using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.BrandCommands;
using HireACar.Application.CQRS.Results.BrandResults.CommandResults;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.BrandHandlers.CommandHandlers
{
    public class UpdatedBrandCommandHandler : IRequestHandler<UpdatedBrandCommand, UpdatedBrandCommandResult>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        public UpdatedBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<UpdatedBrandCommandResult> Handle(UpdatedBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = _brandRepository.Query().FirstOrDefault(x => x.Id == request.BrandId);
            string oldBrandName = brand.Name;
            if (brand == null)
                throw new Exception("Brand bulunamadı.");
            _mapper.Map(request, brand);
            await _brandRepository.UpdateAsync(brand);
            return new UpdatedBrandCommandResult() { Name = oldBrandName };
        }
    }
}
