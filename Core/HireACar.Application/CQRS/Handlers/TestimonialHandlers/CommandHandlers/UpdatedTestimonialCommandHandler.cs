using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.TestimonialCommands;
using HireACar.CrossCuttingConcerns.Exceptions;
using HireACar.Domain.Entities;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.TestimonialHandlers.CommandHandlers
{
    public class UpdatedTestimonialCommandHandler:IRequestHandler<UpdatedTestimonialCommand>
    {
        private readonly ITestimonialRepository _testimonialRepository;
        private readonly IMapper _mapper;
        public UpdatedTestimonialCommandHandler(ITestimonialRepository testimonialRepository, IMapper mapper)
        {
            _testimonialRepository = testimonialRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdatedTestimonialCommand request, CancellationToken cancellationToken)
        {
            var oldTestimonial = await _testimonialRepository.GetAsync(x => x.Id == request.Id);
            if (oldTestimonial == null)
                throw new NotFoundException("Herhangi bir referans bulunamadı.");
            try
            {
                _mapper.Map(request, oldTestimonial);
                await _testimonialRepository.UpdateAsync(oldTestimonial);
            }
            catch
            {
                throw new CustomInternalServerException("Referans güncelleme sırasında bir hata oluştu.");
            }
        }
    }
}
