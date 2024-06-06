using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.ConfigurationData;

namespace Domain.Entities.HistoricalData
{
    /// <summary>
    /// Clase que modela las muestras de cada variable
    /// </summary>
    public class Sample
    {
        /// <summary>
        /// Variable asociada a la medición
        /// </summary>
        public Variable Variable { get; set; }
        /// <summary>
        /// Valor de la variable medida
        /// </summary>
        public object Value { get; }
        /// <summary>
        /// Registra la fecha y hora de la toma de la muestra
        /// </summary>
        public DateTime DateTime { get; set; }


        /// <summary>
        /// Constructor de la clase Variable
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        /// <param name="dateTime"></param>
        /// <exception cref="ArgumentException"></exception>
        public Sample(Variable variable, object value, DateTime dateTime)
        {
            if(value is int||value is bool||value is double||value is float)
            {
                Value = value;
            }
            else
            {
                throw new ArgumentException("Data type not allowed");
            }
            DateTime = dateTime;
            Variable = variable;
        }
        
    }
}
