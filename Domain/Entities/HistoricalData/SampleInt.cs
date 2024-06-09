using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.HistoricalData
{
    public class SampleInt : Sample
    {
        /// <summary>
        /// Valor entero de la muestra
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Inicializa un objeto tipo SampleInt
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        public SampleInt(Variable variable, int value) : base(variable)
        {
            Value = value;
        }
    }
}
