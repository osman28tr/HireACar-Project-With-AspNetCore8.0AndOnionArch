using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Queries.ContactQueries;
using HireACar.Application.CQRS.Results.ContactResults.QueryResults;
using HireACar.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.ContactHandlers.QueryHandlers
{
    public class GetListContactQueryHandler:IRequestHandler<GetListContactQuery,List<GetListContactQueryResult>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public GetListContactQueryHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListContactQueryResult>?> Handle(GetListContactQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _contactRepository.GetAllAsync(null);
            return contacts.Count > 0
                ? _mapper.Map<List<GetListContactQueryResult>>(contacts)
                : throw new NotFoundException("Mesajlar bulunamadı.");
        }
    }
}
