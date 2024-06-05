using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ConfigurationData
{
    /// <summary>
    /// Edificio
    /// </summary>
    public class Building
    {
        #region Properties

        /// <summary>
        /// Direccion fisica del edificio
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Numero del edificio
        /// </summary>
        public int Number { get; set; }

        #endregion

        /// <summary>
        /// Inicializa un objeto <see cref="Building">.
        /// </summary>
        /// <param name="address">Direccion fisica del edificio.</param>
        /// <param name="number">Numero del edificio.</param>
        public Building(string address, int number)
        {
            Address = address;
            Number = number;
        }

    }
}
