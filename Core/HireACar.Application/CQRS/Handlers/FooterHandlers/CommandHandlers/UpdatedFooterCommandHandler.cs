using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.FooterCommands;
using HireACar.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.FooterHandlers.CommandHandlers
{
    public class UpdatedFooterCommandHandler:IRequestHandler<UpdatedFooterCommand>
    {
        private readonly IFooterRepository _footerRepository;
        private readonly IMapper _mapper;
        public UpdatedFooterCommandHandler(IFooterRepository footerRepository, IMapper mapper)
        {
            _footerRepository = footerRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdatedFooterCommand request, CancellationToken cancellationToken)
        {
            var footer = await _footerRepository.GetAsync(x => x.Id == request.Id);
            if (footer == null)
                throw new NotFoundException("Güncellemek istediğiniz footer bulunamadı.");
            try
            {
                _mapper.Map(request, footer);
                await _footerRepository.UpdateAsync(footer);
            }
            catch
            {
                throw new CustomInternalServerException("Footer güncelleme sırasında bir hata oluştu.");
            }
        }
    }
}
