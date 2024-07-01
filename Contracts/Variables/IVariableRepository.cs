using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Variables
{
    public interface IVariableRepository
    {
        /// <summary>
        /// Añade una variable al soporte de datos.
        /// </summary>
        /// <param name="variable"></param>
        void AddVariable(Variable variable);

        /// <summary>
        /// Obtiene una varible del soporte de datos a partir de 
        /// su identificador.
        /// </summary>
        /// <param name="id">Identificador de la variable</param>
        /// <returns>Variable obtenida del soporte de datos; de no
        /// existir, <see langword="null"/>.</returns>
        Variable? GetVariableById(Guid id);

        /// <summary>
        /// Obtiene todas las variables del soporte de datos.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Variable> GetAllVariables();

        /// <summary>
        /// Actualiza las propiedades de una variable en el 
        /// soporte de datos.
        /// </summary>
        /// <param name="variable">Instancia con la información
        /// a actualizar de la variable</param>
        void UpdateVariable(Variable variable);

        /// <summary>
        /// Elimina una variable del soporte de datos.
        /// </summary>
        /// <param name="variable">Variable a eliminar</param>
        void DeleteVariable(Variable variable);
    }
}
