using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.CategoryCommands;
using HireACar.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.CategoryHandlers.CommandHandlers
{
    public class DeletedCategoryCommandHandler : IRequestHandler<DeletedCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeletedCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Handle(DeletedCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAsync(x => x.Id == request.Id);
            if (category == null)
            {
                throw new NotFoundException("Kategori bulunamadı.");
            }
            try
            {
                await _categoryRepository.DeleteAsync(category);
            }
            catch (Exception exception)
            {
                throw new Exception(
                    $"Blog kategori silme işlemi sırasında bir hata oluştu.{exception.Message}");
            }
        }
    }
}
