using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.FooterCommands;
using HireACar.CrossCuttingConcerns.Exceptions;
using HireACar.Domain.Entities;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.FooterHandlers.CommandHandlers
{
    public class CreatedFooterCommandHandler:IRequestHandler<CreatedFooterCommand>
    {
        private readonly IFooterRepository _footerRepository;
        private readonly IMapper _mapper;
        public CreatedFooterCommandHandler(IFooterRepository footerRepository, IMapper mapper)
        {
            _footerRepository = footerRepository;
            _mapper = mapper;
        }
        public async Task Handle(CreatedFooterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var footer = _mapper.Map<Footer>(request);
                await _footerRepository.AddAsync(footer);
            }
            catch
            {
                throw new CustomInternalServerException("Footer ekleme işlemi sırasında bir hata oluştu.");
            }
        }
    }
}
