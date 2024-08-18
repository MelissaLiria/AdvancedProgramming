using Application.Abstract;
using Contracts.Variables;
using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Variables.Queries.GetVariableById
{
    public class GetVariableByIdQueryHandler
        : IQueryHandler<GetVariableByIdQuery, Variable?>
    {
        private readonly IVariableRepository _variableRepository;

        public GetVariableByIdQueryHandler(IVariableRepository variableRepository)
        {
            _variableRepository = variableRepository;
        }

        public Task<Variable?> Handle(GetVariableByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_variableRepository.GetVariableById(request.Id));
        }
    }
}
