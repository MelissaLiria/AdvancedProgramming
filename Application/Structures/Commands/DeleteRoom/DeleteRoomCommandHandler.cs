using Application.Abstract;
using Contracts;
using Contracts.Structures;
using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Structures.Commands.DeleteRoom
{
    public class DeleteRoomCommandHandler
       : ICommandHandler<DeleteRoomCommand>
    {
        private readonly IStructureRepository _structureRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRoomCommandHandler(
            IStructureRepository structureRepository,
            IUnitOfWork unitOfWork)
        {
            _structureRepository = structureRepository;
            _unitOfWork = unitOfWork;
        }
        public Task Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var roomToDelete = _structureRepository.GetStructureById<Room>(request.Id);
            if (roomToDelete is null)
                return Task.CompletedTask;

            _structureRepository.DeleteStructure(roomToDelete);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
