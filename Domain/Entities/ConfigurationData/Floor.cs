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
        /// Id de Building
        /// </summary>
        public Guid BuildingId { get; set; }

        /// <summary>
        /// Habitaciones dentro del piso
        /// </summary>
        public List<Room> Rooms { get; set; }


        #endregion 

        /// <summary>
        /// Constructor por defecto de la clase FLoor
        /// </summary>
        protected Floor() 
        {
        }

        /// <summary>
        /// Inicializa un objeto <see cref="Floor"/>
        /// </summary>
        /// <param name="location">Ubicacion del piso.</param>
        /// <param name="building">Edificio donde se encuentra el piso</param>
        /// <param name="id"'>Identificador de Floor</param>
        public Floor(Guid id, string location, Building building):base(id)
        {
            Location = location;
            Building = building;
            BuildingId = building.Id;
            Rooms = new List<Room>();
        }


    }
}
