using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.HistoricalData
{
    public class SampleDouble : Sample
    {
        /// <summary>
        /// Valor double de la muestra
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Inicializa un objeto tipo SampleDouble
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        public SampleDouble(Variable variable, double value) : base(variable)
        {
            Value = value;
        }
    }
}
