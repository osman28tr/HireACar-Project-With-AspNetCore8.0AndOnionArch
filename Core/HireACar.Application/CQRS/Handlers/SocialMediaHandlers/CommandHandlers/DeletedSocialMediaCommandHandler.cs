using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.SocialMediaCommands;
using HireACar.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.SocialMediaHandlers.CommandHandlers
{
    public class DeletedSocialMediaCommandHandler:IRequestHandler<DeletedSocialMediaCommand>
    {
        private readonly ISocialMediaRepository _socialMediaRepository;
        public DeletedSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }
        public async Task Handle(DeletedSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var socialMedia = await _socialMediaRepository.GetAsync(x => x.Id == request.Id);
            if (socialMedia == null)
                throw new NotFoundException("Sosyal medya bilgisi bulunamadı.");
            try
            {
                await _socialMediaRepository.DeleteAsync(socialMedia);
            }
            catch
            {
                throw new CustomInternalServerException("Sosyal medya silme işlemi sırasında bir hata oluştu.");
            }
        }
    }
}
