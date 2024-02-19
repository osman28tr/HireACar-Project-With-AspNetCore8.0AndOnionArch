using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.CategoryCommands;
using HireACar.CrossCuttingConcerns.Exceptions;
using HireACar.Domain.Entities;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.CategoryHandlers.CommandHandlers
{
    public class UpdatedCategoryCommandHandler:IRequestHandler<UpdatedCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdatedCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdatedCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var category = _mapper.Map<Category>(request);
                await _categoryRepository.UpdateAsync(category);
            }
            catch (Exception exception)
            {
                throw new BusinessException(
                    $"Blog kategori güncelleme işlemi sırasında bir hata oluştu. {exception.Message}");
            }
        }
    }
}
