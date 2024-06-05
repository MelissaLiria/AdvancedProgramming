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
    public class Variable<T>
    {
        /// <summary>
        /// Localización en la que es medida la variable
        /// </summary>
        public T Location { get; set; }
        /// <summary>
        /// Nombre de la variable
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Unidad de medida de la variable
        /// </summary>
        public string MeasurementUnit { get; set; }
        /// <summary>
        /// Código de la variable en diagrama PI&D
        /// </summary>
        public string Code { get; set; }

        public Variable(T location, string name, string measurementUnit, string code)
        {
            Location = location;
            Name = name;
            MeasurementUnit = measurementUnit;
            Code = code;
        }
    }
}
