using Application.Abstract;
using Contracts;
using Contracts.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Structures.Commands.UpdateFloor
{
    public class UpdateFloorCommandHandler
         : ICommandHandler<UpdateFloorCommand>
    {
        private readonly IStructureRepository _structureRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFloorCommandHandler(
            IStructureRepository structureRepository,
            IUnitOfWork unitOfWork)
        {
            _structureRepository = structureRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateFloorCommand request, CancellationToken cancellationToken)
        {
            _structureRepository.UpdateStructure(request.Floor);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
