using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.ContactCommands;
using HireACar.CrossCuttingConcerns.Exceptions;
using HireACar.Domain.Entities;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.ContactHandlers.CommandHandlers
{
    public class DeletedContactCommandHandler : IRequestHandler<DeletedContactCommand>
    {
        private readonly IContactRepository _contactRepository;
        public DeletedContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task Handle(DeletedContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetAsync(x => x.Id == request.Id);
            if (contact == null)
                throw new NotFoundException("Silmek istediğiniz mesaj bilgisi bulunamadı.");
            
            try { await _contactRepository.DeleteAsync(contact); }
            catch { throw new CustomInternalServerException("Silme işlemi sırasında bir hata oluştu."); }
        }
    }
}
