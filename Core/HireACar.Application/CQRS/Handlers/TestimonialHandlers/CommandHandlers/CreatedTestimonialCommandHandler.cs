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
    public class CreatedTestimonialCommandHandler:IRequestHandler<CreatedTestimonialCommand>
    {
        private readonly ITestimonialRepository _testimonialRepository;
        private readonly IMapper _mapper;
        public CreatedTestimonialCommandHandler(ITestimonialRepository testimonialRepository, IMapper mapper)
        {
            _testimonialRepository = testimonialRepository;
            _mapper = mapper;
        }
        public async Task Handle(CreatedTestimonialCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var testimonial = _mapper.Map<Testimonial>(request);
                await _testimonialRepository.AddAsync(testimonial);
            }
            catch
            {
                throw new CustomInternalServerException("Referans ekleme sırasında bir hata oluştu.");
            }
        }
    }
}
