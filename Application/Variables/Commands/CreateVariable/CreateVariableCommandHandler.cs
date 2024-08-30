using Application.Abstract;
using Contracts;
using Contracts.Structures;
using Contracts.Variables;
using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Variables.Commands.CreateVariable
{
    public class CreateVariableCommandHandler
        : ICommandHandler<CreateVariableCommand, Variable>
    {
        private readonly IVariableRepository _variableRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStructureRepository _structureRepository;

        public CreateVariableCommandHandler(IVariableRepository variableRepository, IUnitOfWork unitOfWork, IStructureRepository structureRepository)
        {
            _variableRepository = variableRepository;
            _unitOfWork = unitOfWork;
            _structureRepository = structureRepository;
        }

        public Task<Variable> Handle(CreateVariableCommand request, CancellationToken cancellationToken)
        {
            Structure location;
            if (request.Location is Building)
                location = _structureRepository.GetStructureById<Building>(request.Location.Id);
            else if (request.Location is Floor)
                location = _structureRepository.GetStructureById<Floor>(request.Location.Id);
            else
                location = _structureRepository.GetStructureById<Room>(request.Location.Id);

            Variable result = new Variable(
                Guid.NewGuid(),
                location,
                request.Variabletype,
                request.Code);

            _variableRepository.AddVariable(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
