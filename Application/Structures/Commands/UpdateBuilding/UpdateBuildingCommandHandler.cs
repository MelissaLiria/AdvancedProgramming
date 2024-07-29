using Application.Abstract;
using Contracts;
using Contracts.Structures;
using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Structures.Commands.UpdateBuilding
{
    public class UpdateBuildingCommandHandler
        : ICommandHandler<UpdateBuildingCommand>
    {
        private readonly IStructureRepository _structureRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBuildingCommandHandler(
            IStructureRepository structureRepository,
            IUnitOfWork unitOfWork)
        {
            _structureRepository = structureRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateBuildingCommand request, CancellationToken cancellationToken)
        {
            _structureRepository.UpdateStructure(request.Building);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}