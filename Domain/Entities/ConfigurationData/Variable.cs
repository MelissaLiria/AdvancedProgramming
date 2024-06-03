using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ConfigurationData
{
    /// <summary>
    /// Clase dedicada a las variables medidas en cada habitación
    /// </summary>
    public class Variable
    {
        
        /// <summary>
        /// Nombre de la variable
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Unidad de medida de la variable
        /// </summary>
        string MeasurementUnit { get; set; }
        /// <summary>
        /// Código de la variable en diagrama PI&D
        /// </summary>
        string Code { get; set; }

        public Variable(string name, string measurementUnit, string code)
        {
            Name = name;
            MeasurementUnit = measurementUnit;
            Code = code;
        }
    }
}
