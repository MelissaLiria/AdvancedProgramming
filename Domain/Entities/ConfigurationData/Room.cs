using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace  Domain.Entities.ConfigurationData

{
    /// <summary>
    /// Clase habitación 2.0
    /// </summary>
    public class Room : Structure
    {
    /// <summary>
    /// Numero de habitacion
    /// </summary>

    public int Number { get; set; }
    /// <summary>
    /// Si es de produccion o no
    /// </summary>
    public bool IsProduction { get; set; }
    /// <summary>
    /// Breve descripcion sobre la habitacion
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Piso al que pertenece la habitacion
    /// </summary>
    public Floor Floor { get; set; }


     /// <summary>
     /// Constructor
     /// </summary>

        public Room(int number, bool isProduction, string description, Floor floor)
    {
        Number = number;
        IsProduction = isProduction;
        Description = description;
        Floor = floor;
     }

    }
}