using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.TestimonialCommands;
using HireACar.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.TestimonialHandlers.CommandHandlers
{
    public class DeletedTestimonialCommandHandler : IRequestHandler<DeletedTestimonialCommand>
    {
        private readonly ITestimonialRepository _repository;
        private readonly IMapper _mapper;
        public DeletedTestimonialCommandHandler(ITestimonialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(DeletedTestimonialCommand request, CancellationToken cancellationToken)
        {
            var deletedTestimonial = await _repository.GetAsync(x => x.Id == request.Id);
            if (deletedTestimonial == null)
                throw new NotFoundException("Herhangi bir referans bulunamadı.");
            try
            {
                await _repository.DeleteAsync(deletedTestimonial);
            }
            catch
            {
                throw new CustomInternalServerException("Referans silme sırasında bir hata oluştu.");
            }
        }
    }
}
