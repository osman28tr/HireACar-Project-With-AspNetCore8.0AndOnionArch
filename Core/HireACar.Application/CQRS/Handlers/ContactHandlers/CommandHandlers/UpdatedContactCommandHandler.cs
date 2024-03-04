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
    public class UpdatedContactCommandHandler:IRequestHandler<UpdatedContactCommand>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        public UpdatedContactCommandHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdatedContactCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var contact = _mapper.Map<Contact>(request);
                await _contactRepository.UpdateAsync(contact);
            }
            catch (Exception exception)
            {
                throw new BusinessException("Güncelleme işlemi sırasında bir hata oluştu.");
            }
        }
    }
}
