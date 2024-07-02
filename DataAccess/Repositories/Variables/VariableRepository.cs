using Contracts.Variables;
using DataAccess.Contexts;
using DataAccess.Repositories.Common;
using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Variables
{
    /// <summary>
    /// Implementación del repositorio IVariableRepository
    /// </summary>
    public class VariableRepository
        : RepositoryBase, IVariableRepository
    {
        public void AddVariable(Variable variable)
        {
            _context.Variables.Add(variable);
        }

        public void DeleteVariable(Variable variable)
        {
            _context.Variables.Remove(variable);
        }

        public IEnumerable<Variable> GetAllVariables()
        {
            return _context.Variables.ToList();
        }

        public Variable? GetVariableById(Guid id)
        {
            return _context.Variables.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateVariable(Variable variable)
        {
            _context.Variables.Update(variable);
        }

        public VariableRepository(ApplicationContext context) : base(context)
        {
        }

    }
}
