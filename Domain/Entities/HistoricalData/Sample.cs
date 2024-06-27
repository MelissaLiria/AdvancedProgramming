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
    public abstract class Sample : Entity
    {
        #region Properties
        /// <summary>
        /// Variable asociada a la medición
        /// </summary>
        public Variable Variable { get; set; }
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
        /// <param name="id"></param>
        /// <param name="variable"></param>
        public Sample(Guid id, Variable variable) : base(id)
        { 
            DateTime = DateTime.Now;
            VariableId = variable.Id;
            Variable = variable;
        }
        
    }
}
