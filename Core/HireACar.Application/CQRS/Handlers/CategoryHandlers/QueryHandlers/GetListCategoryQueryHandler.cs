using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Queries.CategoryQueries;
using HireACar.Application.CQRS.Results.CategoryResults.QueryResults;
using HireACar.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.CategoryHandlers.QueryHandlers
{
    public class GetListCategoryQueryHandler:IRequestHandler<GetListCategoryQuery,List<GetListCategoryQueryResult>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListCategoryQueryResult>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync(null);
            return _mapper.Map<List<GetListCategoryQueryResult>>(categories);
        }
    }
}
