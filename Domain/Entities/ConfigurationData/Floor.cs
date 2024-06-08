using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;

namespace Domain.Entities.ConfigurationData
{
    /// <summary>
    /// Piso de un edificio
    /// </summary>
    public class Floor: Structure
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

        /// <summary>
        /// Habitaciones dentro del piso
        /// </summary>
        public List<Room> Rooms { get; set; }

        /// <summary>
        /// Variables dentro del piso
        /// </summary>
        public List<Variable> Variables { get; set; }

        #endregion 

        /// <summary>
        /// Inicializa un objeto <see cref="Floor"/>
        /// </summary>
        /// <param name="location">Ubicacion del piso.</param>
        /// <param name="building">Edificio donde se encuentra el piso</param>
        public Floor(string location, Building building)
        {
            Location = location;
            Building = building;
            Rooms = new List<Room>();
            Variables = new List<Variable>();
        }


    }
}
