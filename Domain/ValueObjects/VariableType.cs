using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    /// <summary>
    /// Clase de tipos de variables
    /// </summary>
    public class VariableType : ValueObject
    {
        #region Properties
        /// <summary>
        /// Nombre de la variable
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Unidad de medida
        /// </summary>
        public string MeasurementUnit { get; set; }
        #endregion

        protected VariableType() { }

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

        /// <summary>
        /// Implementando método de la clase base ValueObject
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return MeasurementUnit;
        }
    }
}
