using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Queries.ServiceQueries;
using HireACar.Application.CQRS.Results.ServiceResults.QueryResults;
using HireACar.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.ServiceHandlers.QueryHandlers
{
    public class GetListServiceQueryHandler : IRequestHandler<GetListServiceQuery, List<GetListServiceQueryResult>>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;
        public GetListServiceQueryHandler(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }
        public async Task<List<GetListServiceQueryResult>> Handle(GetListServiceQuery request, CancellationToken cancellationToken)
        {
            var services = await _serviceRepository.GetAllAsync(null);
            if (services == null || services.Count == 0)
                throw new NotFoundException("Sistemde kayıtlı hizmet bulunamadı.");
            return _mapper.Map<List<GetListServiceQueryResult>>(services);
        }
    }
}
