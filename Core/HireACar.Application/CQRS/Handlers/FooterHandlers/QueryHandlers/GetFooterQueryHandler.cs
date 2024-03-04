using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Queries.FooterQueries;
using HireACar.Application.CQRS.Results.FooterResults.QueryResults;
using HireACar.CrossCuttingConcerns.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HireACar.Application.CQRS.Handlers.FooterHandlers.QueryHandlers
{
    public class GetFooterQueryHandler : IRequestHandler<GetFooterQuery, GetFooterQueryResult>
    {
        private readonly IFooterRepository _footerRepository;
        private readonly IMapper _mapper;
        public GetFooterQueryHandler(IFooterRepository footerRepository, IMapper mapper)
        {
            _footerRepository = footerRepository;
            _mapper = mapper;
        }
        public async Task<GetFooterQueryResult> Handle(GetFooterQuery request, CancellationToken cancellationToken)
        {
            var footer = await _footerRepository.Query().FirstOrDefaultAsync();
            if (footer == null)
                throw new NotFoundException("Footer bilgisi bulunamadı.");
            try
            {
                var mappingFooter = _mapper.Map<GetFooterQueryResult>(footer);
                return mappingFooter;
            }
            catch
            {
                throw new CustomInternalServerException("Footer bilgisi iletilirken bir hata oluştu.");
            }
        }
    }
}
