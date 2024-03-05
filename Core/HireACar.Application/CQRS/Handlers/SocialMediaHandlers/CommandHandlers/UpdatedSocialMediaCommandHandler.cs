using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.SocialMediaCommands;
using HireACar.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.SocialMediaHandlers.CommandHandlers
{
    public class UpdatedSocialMediaCommandHandler:IRequestHandler<UpdatedSocialMediaCommand>
    {
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly IMapper _mapper;
        public UpdatedSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper)
        {
            _socialMediaRepository = socialMediaRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdatedSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var socialMedia = await _socialMediaRepository.GetAsync(x => x.Id == request.Id);
            if (socialMedia == null)
                throw new NotFoundException("Sosyal medya bilgisi bulunamadı.");
            try
            {
                var updatedSocialMedia = _mapper.Map(request, socialMedia);
                await _socialMediaRepository.UpdateAsync(updatedSocialMedia);
            }
            catch
            {
                throw new CustomInternalServerException("Sosyal medya güncelleme sırasında bir hata oluştu.");
            }
        }
    }
}
