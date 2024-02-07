using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HireACar.API.Helpers
{
    public class MediatrBaseController:ControllerBase
    {
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;
    }
}
