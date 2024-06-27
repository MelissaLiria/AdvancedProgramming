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
        #region Properties
        /// <summary>
        /// Valor entero de la muestra
        /// </summary>
        public int Value { get; set; }
        #endregion

        /// <summary>
        /// Constructor por defecto de la clase SampleInt
        /// </summary>
        protected SampleInt(){ }

        /// <summary>
        /// Inicializa un objeto tipo SampleInt
        /// </summary>
        /// <param name="id"></param>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        public SampleInt(Guid id, Variable variable, int value) : base(id, variable)
        {
            Value = value;
        }
    }
}
