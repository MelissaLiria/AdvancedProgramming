using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Types
{
    /// <summary>
    /// Clase de tipos de variables
    /// </summary>
    public class VariableType
    {
        
        /// <summary>
        /// Nombre de la variable
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Unidad de medida
        /// </summary>
        public string MeasurementUnit { get; set; }

        /// <summary>
        /// Inicializa un objeto tipo VariableType
        /// </summary>
        /// <param name="name"></param>
        /// <param name="measurementUnit"></param>
        public VariableType(string name, string measurementUnit)
        {
            Name = name;
            MeasurementUnit = measurementUnit;
        }

    }
}
