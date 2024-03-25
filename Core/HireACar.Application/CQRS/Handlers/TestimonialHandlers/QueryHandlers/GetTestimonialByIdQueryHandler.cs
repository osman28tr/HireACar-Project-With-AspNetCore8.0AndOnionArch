using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Queries.TestimonialQueries;
using HireACar.Application.CQRS.Results.TestimonialResults.QueryResults;
using HireACar.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.TestimonialHandlers.QueryHandlers
{
    public class GetTestimonialByIdQueryHandler:IRequestHandler<GetTestimonialByIdQuery,GetTestimonialByIdQueryResult>
    {
        private readonly ITestimonialRepository _testimonialRepository;
        private readonly IMapper _mapper;
        public GetTestimonialByIdQueryHandler(ITestimonialRepository testimonialRepository, IMapper mapper)
        {
            _testimonialRepository = testimonialRepository;
            _mapper = mapper;
        }
        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var testimonial = await _testimonialRepository.GetAsync(x => x.Id == request.Id);
            if(testimonial == null)
                throw new NotFoundException("Herhangi bir referans bulunamadı.");
            var mappingTestimonial = _mapper.Map<GetTestimonialByIdQueryResult>(testimonial);
            return mappingTestimonial;
        }
    }
}
