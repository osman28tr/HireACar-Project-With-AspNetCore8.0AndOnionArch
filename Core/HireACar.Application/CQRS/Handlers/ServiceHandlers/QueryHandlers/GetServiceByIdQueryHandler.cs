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
    public class GetServiceByIdQueryHandler:IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;
        public GetServiceByIdQueryHandler(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }
        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var services = await _serviceRepository.GetAsync(x => x.Id == request.Id);
            if (services == null)
                throw new NotFoundException("Sistemde kayıtlı hizmet bulunamadı.");
            return _mapper.Map<GetServiceByIdQueryResult>(services);
        }
    }
}
