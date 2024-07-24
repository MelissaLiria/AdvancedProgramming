using Application.Abstract;
using Contracts;
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

        public CreateVariableCommandHandler(IVariableRepository variableRepository, IUnitOfWork unitOfWork)
        {
            _variableRepository = variableRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Variable> Handle(CreateVariableCommand request, CancellationToken cancellationToken)
        {
            Variable result = new Variable(
                Guid.NewGuid(),
                request.Location,
                request.Variabletype,
                request.Code);

            _variableRepository.AddVariable(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
