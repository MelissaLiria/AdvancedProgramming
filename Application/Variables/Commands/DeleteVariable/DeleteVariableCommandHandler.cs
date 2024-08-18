using Application.Abstract;
using Contracts;
using Contracts.Variables;
using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Variables.Commands.DeleteVariable
{
    public class DeleteVariableCommandHandler
        : ICommandHandler<DeleteVariableCommand>
    {
        private readonly IVariableRepository _variableRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteVariableCommandHandler(IVariableRepository variableRepository, IUnitOfWork unitOfWork)
        {
            _variableRepository = variableRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteVariableCommand request, CancellationToken cancellationToken)
        {
            var variableToDelete = _variableRepository.GetVariableById(request.Id);
            if (variableToDelete == null) 
                return Task.CompletedTask;

            _variableRepository.DeleteVariable(variableToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
