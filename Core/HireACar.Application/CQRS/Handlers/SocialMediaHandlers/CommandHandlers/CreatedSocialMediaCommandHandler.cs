using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.SocialMediaCommands;
using HireACar.CrossCuttingConcerns.Exceptions;
using HireACar.Domain.Entities;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.SocialMediaHandlers.CommandHandlers
{
    public class CreatedSocialMediaCommandHandler:IRequestHandler<CreatedSocialMediaCommand>
    {
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly IMapper _mapper;
        public CreatedSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper)
        {
            _socialMediaRepository = socialMediaRepository;
            _mapper = mapper;
        }
        public async Task Handle(CreatedSocialMediaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var socialMedia = _mapper.Map<SocialMedia>(request);
                await _socialMediaRepository.AddAsync(socialMedia);
            }
            catch
            {
                throw new CustomInternalServerException("Sosyal medya ekleme sırasında bir hata oluştu.");
            }
        }
    }
}
