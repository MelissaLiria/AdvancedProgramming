using Application.Abstract;
using Contracts;
using Contracts.Structures;
using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Structures.Commands.CreateBuilding
{
    public class CreateBuildingCommandHandler
        : ICommandHandler<CreateBuildingCommand, Building>
    {
        private readonly IStructureRepository _structureRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public  CreateBuildingCommandHandler(
            IStructureRepository structureRepository,
            IUnitOfWork unitOfWork)
        {
            _structureRepository = structureRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Building> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
        {
            Building result = new Building(
                Guid.NewGuid(),
                request.Address,
                request.Number);

            _structureRepository.AddStructure(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result); 
        }
    }
}
