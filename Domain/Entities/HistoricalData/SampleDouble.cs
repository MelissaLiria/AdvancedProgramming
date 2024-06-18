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
        #region Properties
        /// <summary>
        /// Valor double de la muestra
        /// </summary>
        public double Value { get; set; }
        #endregion

        /// <summary>
        /// Constructor por defecto de la clase SampleDouble
        /// </summary>
        protected SampleDouble() { }


        /// <summary>
        /// Inicializa un objeto tipo SampleDouble
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        public SampleDouble(Guid id, Variable variable, Guid variableId, double value) : base(id, variable, variableId)
        {
            Value = value;
        }
    }
}
