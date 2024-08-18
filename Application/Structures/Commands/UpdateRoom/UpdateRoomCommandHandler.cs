using Application.Abstract;
using Contracts;
using Contracts.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Structures.Commands.UpdateRoom
{
    public class UpdateRoomCommandHandler
         : ICommandHandler<UpdateRoomCommand>
    {
        private readonly IStructureRepository _structureRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRoomCommandHandler(
            IStructureRepository structureRepository,
            IUnitOfWork unitOfWork)
        {
            _structureRepository = structureRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            _structureRepository.UpdateStructure(request.Room);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
