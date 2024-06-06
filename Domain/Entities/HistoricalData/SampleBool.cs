using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.HistoricalData
{
    public class SampleBool : Sample
    {


        /// <summary>
        /// Valor booleano de la muestra
        /// </summary>
        public bool Value { get; set; }

        /// <summary>
        /// Inicializa un objeto tipo SampleBool
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        public SampleBool(Variable variable, bool value) : base(variable)
        {
            Value = value;
        }

    }
}
