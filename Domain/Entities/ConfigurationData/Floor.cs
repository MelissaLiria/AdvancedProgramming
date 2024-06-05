using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ConfigurationData
{
    /// <summary>
    /// Piso de un edificio
    /// </summary>
    public class Floor
    {
        #region Properties

        /// <summary>
        /// Ubicacion del  piso.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Edificio donde se encuentra el piso
        /// </summary>
        public Building Building { get; set; }

        #endregion 

        /// <summary>
        /// Inicializa un objeto <see cref="Floor"/>
        /// </summary>
        /// <param name="location">Ubicacion del piso.</param>
        /// <param name="building">Edificio donde se encuentra el piso</param>
        public Floor(string location,Building building)
        {
            Location = location;
            Building = building;

        }


    }
}
