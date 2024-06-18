using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    /// <summary>
    /// Clase base de las entidades
    /// </summary>
    public abstract class Entity
    {
        #region
        /// <summary>
        /// Identificador del objeto
        /// </summary>
        public Guid Id { get; set; }
        #endregion

        /// <summary>
        /// Constructor por defecto de objeto tipo Entity
        /// </summary>
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Modela un objeto tipo Entity
        /// </summary>
        /// <param name="id"></param>
        protected Entity(Guid id)
        {
            Id = id;
        }
    }
}
