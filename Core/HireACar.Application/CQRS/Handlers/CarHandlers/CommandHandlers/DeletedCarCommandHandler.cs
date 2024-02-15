using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.Abstract;
using HireACar.Application.CQRS.Commands.CarCommands;
using MediatR;

namespace HireACar.Application.CQRS.Handlers.CarHandlers.CommandHandlers
{
    public class DeletedCarCommandHandler:IRequestHandler<DeletedCarCommand>
    {
        private readonly ICarRepository _carRepository;

        public DeletedCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task Handle(DeletedCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetAsync(x => x.Id == request.Id);
            if (car == null)
                throw new Exception("Araç bulunamadı.");
            car.IsDeleted = true;
            await _carRepository.UpdateAsync(car);
        }
    }
}
