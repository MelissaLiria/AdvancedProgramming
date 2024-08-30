using Application.Abstract;
using Contracts;
using Contracts.Structures;
using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Structures.Commands.CreateRoom
{
    public class CreateRoomCommandHandler
     : ICommandHandler<CreateRoomCommand, Room>
    {
        private readonly IStructureRepository _structureRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoomCommandHandler(
            IStructureRepository structureRepository,
            IUnitOfWork unitOfWork)
        {
            _structureRepository = structureRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Room> Handle(CreateRoomCommand request, 
            CancellationToken cancellationToken)
        {
            var floor = _structureRepository.GetStructureById<Floor>(request.Floor.Id);
            Room result = new Room(
                Guid.NewGuid(),
                request.Number,
                request.IsProduction,
                request.Description,
                floor);

            _structureRepository.AddStructure(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
