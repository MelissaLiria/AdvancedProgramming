using Application.Abstract;
using Contracts;
using Contracts.Structures;
using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Structures.Commands.DeleteBuilding
{
    public class DeleteBuildingCommandHandler
        : ICommandHandler<DeleteBuildingCommand>
    {
        private readonly IStructureRepository _structureRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBuildingCommandHandler(
            IStructureRepository structureRepository,
            IUnitOfWork unitOfWork)
        {
            _structureRepository = structureRepository;
            _unitOfWork = unitOfWork;
        }
        public Task Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
        {
            var buildingToDelete = _structureRepository.GetStructureById<Building>(request.Id);
            if (buildingToDelete is null)
                return Task.CompletedTask;

            _structureRepository.DeleteStructure(buildingToDelete);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
