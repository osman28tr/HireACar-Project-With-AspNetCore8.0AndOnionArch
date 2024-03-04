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
    public class CreatedContactCommandHandler:IRequestHandler<CreatedContactCommand>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        public CreatedContactCommandHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreatedContactCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var contact = _mapper.Map<Contact>(request);
                contact.SendDate = DateTime.Now;
                await _contactRepository.AddAsync(contact);
            }
            catch
            {
                throw new BusinessException("Mesajınız iletilirken bir hata oluştu.");
            }
        }
    }
}
