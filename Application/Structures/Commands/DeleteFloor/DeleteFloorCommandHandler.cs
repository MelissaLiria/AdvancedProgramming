using Application.Abstract;
using Contracts;
using Contracts.Structures;
using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Structures.Commands.DeleteFloor
{
    public class DeleteFloorCommandHandler
      : ICommandHandler<DeleteFloorCommand>
    {
        private readonly IStructureRepository _structureRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFloorCommandHandler(
            IStructureRepository structureRepository,
            IUnitOfWork unitOfWork)
        {
            _structureRepository = structureRepository;
            _unitOfWork = unitOfWork;
        }
        public Task Handle(DeleteFloorCommand request, CancellationToken cancellationToken)
        {
            var floorToDelete = _structureRepository.GetStructureById<Floor>(request.Id);
            if (floorToDelete is null)
                return Task.CompletedTask;

            _structureRepository.DeleteStructure(floorToDelete);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
