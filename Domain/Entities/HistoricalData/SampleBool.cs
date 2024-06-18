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

        #region Properties
        /// <summary>
        /// Valor booleano de la muestra
        /// </summary>
        public bool Value { get; set; }
        #endregion
        
        /// <summary>
        /// Constructor por defecto de la clase SampleBool
        /// </summary>
        protected SampleBool() { }

        /// <summary>
        /// Inicializa un objeto tipo SampleBool
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        public SampleBool(Guid id, Variable variable, bool value) : base(id, variable)
        {
            Value = value;
        }

    }
}
