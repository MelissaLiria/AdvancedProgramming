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
    public class Sample <T>
    {
        /// <summary>
        /// Variable asociada a la medición
        /// </summary>
        public Variable Variable { get; set; }
        /// <summary>
        /// Valor de la variable medida
        /// </summary>
        public T Value { get; set; }
        /// <summary>
        /// Registra la fecha y hora de la toma de la muestra
        /// </summary>
        public DateTime DateTime { get; set; }

        public Sample(Variable variable, T value, DateTime dateTime)
        {
            Variable = variable;
            Value = value;
            DateTime = dateTime;
        }
        
    }
}
