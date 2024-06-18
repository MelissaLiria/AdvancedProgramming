using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities.ConfigurationData
{
    /// <summary>
    /// Clase dedicada a las variables medidas en cada habitación
    /// </summary>
    public class Variable : Entity 
    {
        #region Properties
        /// <summary>
        /// Localización en la que es medida la variable
        /// </summary>
        public Structure Location { get; set; }
        /// <summary>
        /// Identificador de la localización
        /// </summary>
        public Guid LocationId { get; set; }
        /// <summary>
        /// Tipo de Variable
        /// </summary>
        public VariableType VariableType { get; set; }
        /// <summary>
        /// Código de la variable en diagrama PI&D
        /// </summary>
        public string Code { get; set; }
        #endregion

        protected Variable(): base()
        {
            LocationId = null;
            Location = null;
            VariableType = null;
            Code = null;
        }

        /// <summary>
        /// Inicializa un objeto tipo Variable
        /// </summary>
        /// <param name="id"></param>
        /// <param name="location"></param>
        /// <param name="variableType"></param>
        /// <param name="code"></param>
        public Variable(Guid id, Structure location, Guid locationId VariableType variableType, string code): base(id)
        {
            Location = location;
            LocationId = locationId;
            VariableType = variableType;
            Code = code;
        }
    }
}
