using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities.Types;

namespace Domain.Entities.ConfigurationData
{
    /// <summary>
    /// Clase dedicada a las variables medidas en cada habitación
    /// </summary>
    public class Variable
    {

        /// <summary>
        /// Localización en la que es medida la variable
        /// </summary>
        public Structure Location { get; set; }
        /// <summary>
        /// Tipo de Variable
        /// </summary>
        public VariableType VariableType { get; set; }
        /// <summary>
        /// Código de la variable en diagrama PI&D
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Inicializa un objeto tipo Variable
        /// </summary>
        /// <param name="location"></param>
        /// <param name="variableType"></param>
        /// <param name="code"></param>
        public Variable(Structure location, VariableType variableType, string code)
        {
            Location = location;
            VariableType = variableType;
            Code = code;
        }
    }
}
