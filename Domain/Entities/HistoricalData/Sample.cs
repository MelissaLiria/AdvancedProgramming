using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities.ConfigurationData;

namespace Domain.Entities.HistoricalData
{
    /// <summary>
    /// Clase que modela las muestras de cada variable
    /// </summary>
    public abstract class Sample
    {
        #region Properties
        /// <summary>
        /// Identificador de la variable
        /// </summary>
        public Guid VariableId { get; set; }
        /// <summary>
        /// Registra la fecha y hora de la toma de la muestra
        /// </summary>
        public DateTime DateTime { get; set; }
        #endregion

        /// <summary>
        /// Constructor por defecto de la clase sample
        /// </summary>
        protected Sample() { }

        /// <summary>
        /// Constructor de la clase Sample
        /// </summary>
        /// <param name="variableId"></param>
        public Sample(Guid variableId)
        { 
            DateTime = DateTime.Now;
            VariableId = variableId;
        }
    }
}
