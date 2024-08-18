using Application.Abstract;
using Contracts.Variables;
using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Variables.Queries.GetAllVariables
{
    public class GetAllVariablesQueryHandler
        : IQueryHandler<GetAllVariablesQuery, IEnumerable<Variable>>
    {
        private readonly IVariableRepository _variableRepository;

        public GetAllVariablesQueryHandler(IVariableRepository variableRepository)
        {
            _variableRepository = variableRepository;
        }

        public Task<IEnumerable<Variable>> Handle(GetAllVariablesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_variableRepository.GetAllVariables());
        }
    }
}
