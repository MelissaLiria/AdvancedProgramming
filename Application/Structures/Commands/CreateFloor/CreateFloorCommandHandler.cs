using Application.Abstract;
using Contracts;
using Contracts.Structures;
using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Structures.Commands.CreateFloor
{
    public class CreateFloorCommandHandler
      : ICommandHandler<CreateFloorCommand, Floor>
    {
        private readonly IStructureRepository _structureRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateFloorCommandHandler(
            IStructureRepository structureRepository,
            IUnitOfWork unitOfWork)
        {
            _structureRepository = structureRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Floor> Handle(CreateFloorCommand request, 
            CancellationToken cancellationToken)
        {
            Floor result = new Floor(
                Guid.NewGuid(),
                request.Location,
                request.Building);

            _structureRepository.AddStructure(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
