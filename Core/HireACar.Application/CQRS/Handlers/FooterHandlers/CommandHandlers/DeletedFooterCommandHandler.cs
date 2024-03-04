using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.FooterCommands;
using HireACar.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.FooterHandlers.CommandHandlers
{
    public class DeletedFooterCommandHandler:IRequestHandler<DeletedFooterCommand>
    {
        private readonly IFooterRepository _footerRepository;
        public DeletedFooterCommandHandler(IFooterRepository footerRepository)
        {
            _footerRepository = footerRepository;
        }
        public async Task Handle(DeletedFooterCommand request, CancellationToken cancellationToken)
        {
            var footer = await _footerRepository.GetAsync(x => x.Id == request.Id);
            if (footer == null)
                throw new NotFoundException("Silmek istediğiniz footer bulunamadı.");
            try
            {
                await _footerRepository.DeleteAsync(footer);
            }
            catch
            {
                throw new CustomInternalServerException("Footer silme sırasında bir hata oluştu.");
            }
        }
    }
}
