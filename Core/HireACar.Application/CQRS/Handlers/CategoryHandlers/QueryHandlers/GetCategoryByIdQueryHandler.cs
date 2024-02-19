using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Queries.CategoryQueries;
using HireACar.Application.CQRS.Results.CategoryResults.QueryResults;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.CategoryHandlers.QueryHandlers
{
    public class GetCategoryByIdQueryHandler:IRequestHandler<GetCategoryByIdQuery,GetCategoryByIdQueryResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAsync(x => x.Id == request.Id);
            return _mapper.Map<GetCategoryByIdQueryResult>(category);
        }
    }
}
