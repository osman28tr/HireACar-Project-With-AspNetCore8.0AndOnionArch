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
    public class GetListTestimonialQueryHandler : IRequestHandler<GetListTestimonialQuery, List<GetListTestimonialQueryResult>>
    {
        private readonly ITestimonialRepository _testimonialRepository;
        private readonly IMapper _mapper;
        public GetListTestimonialQueryHandler(ITestimonialRepository testimonialRepository, IMapper mapper)
        {
            _testimonialRepository = testimonialRepository;
            _mapper = mapper;
        }
        public async Task<List<GetListTestimonialQueryResult>> Handle(GetListTestimonialQuery request, CancellationToken cancellationToken)
        {
            var testimonial = await _testimonialRepository.GetAllAsync(null);
            if (testimonial.Count == 0 || testimonial == null)
                throw new NotFoundException("Herhangi bir referans bulunamadı.");
            var mappingTestimonial = _mapper.Map<List<GetListTestimonialQueryResult>>(testimonial);
            return mappingTestimonial;
        }
    }
}
