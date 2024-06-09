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
    public abstract class Sample
    {
        /// <summary>
        /// Variable asociada a la medición
        /// </summary>
        public Variable Variable { get; set; }
        /// <summary>
        /// Registra la fecha y hora de la toma de la muestra
        /// </summary>
        public DateTime DateTime { get; set; }


        /// <summary>
        /// Constructor de la clase Variable
        /// </summary>
        /// <param name="variable"></param>
        /// <exception cref="ArgumentException"></exception>
        public Sample(Variable variable)
        { 
            DateTime = DateTime.Now;
            Variable = variable;
        }
        
    }
}
