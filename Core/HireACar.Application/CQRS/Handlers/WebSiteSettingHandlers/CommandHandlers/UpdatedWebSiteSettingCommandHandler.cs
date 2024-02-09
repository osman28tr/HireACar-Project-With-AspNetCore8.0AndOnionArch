using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.WebSiteSettingCommands;
using HireACar.Domain.Entities;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.WebSiteSettingHandlers.CommandHandlers
{
    public class UpdatedWebSiteSettingCommandHandler:IRequestHandler<UpdatedWebSiteSettingCommand>
    {
        private readonly IWebSiteSettingRepository _webSiteSettingRepository;
        private readonly IMapper _mapper;

        public UpdatedWebSiteSettingCommandHandler(IMapper mapper, IWebSiteSettingRepository webSiteSettingRepository)
        {
            _mapper = mapper;
            _webSiteSettingRepository = webSiteSettingRepository;
        }
        public async Task Handle(UpdatedWebSiteSettingCommand request, CancellationToken cancellationToken)
        {
            var webSiteSetting = _mapper.Map<WebSiteSetting>(request);
            await _webSiteSettingRepository.UpdateAsync(webSiteSetting);
        }
    }
}
