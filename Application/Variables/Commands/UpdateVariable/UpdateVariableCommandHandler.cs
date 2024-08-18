using Application.Abstract;
using Contracts;
using Contracts.Variables;
using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Variables.Commands.UpdateVariable
{
    public class UpdateVariableCommandHandler
        : ICommandHandler<UpdateVariableCommand>
    {
        private readonly IVariableRepository _variableRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateVariableCommandHandler(IVariableRepository variableRepository, IUnitOfWork unitOfWork)
        {
            _variableRepository = variableRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateVariableCommand request, CancellationToken cancellationToken)
        {
            _variableRepository.UpdateVariable(request.Variable);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
