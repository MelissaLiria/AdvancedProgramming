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
    public class Building: Structure

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

        /// <summary>
        /// Pisos dentro del edificio
        /// </summary>
        public List<Floor> Floors { get; set; }

        /// <summary>
        /// Variables medidas dentro del edificio
        /// </summary>
        public List<Variable> Variables { get; set; }

        #endregion

        
        /// <summary>
        /// Inicializa un objeto <see cref="Building">.
        /// </summary>
        /// <param name="address">Direccion fisica del edificio.</param>
        /// <param name="number">Numero del edificio.</param>
        public Building(Guid id,string address, int number):base(id)
        {
            Address = address;
            Number = number;
            Floors = new List<Floor>();
            Variables = new List<Variable>();
        }

        protected Building()
        {
        }
    }
}
