using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Room
{
    /// <summary>
    /// Clase habitación
    /// </summary>

    public int Number { get; set; }
    /// <summary>
    /// Numero de habitacion
    /// </summary>
    public bool IsProduction { get; set; }
    /// <summary>
    /// Si es de produccion o no
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Breve descripcion sobre la habitacion
    /// </summary>
    public Floor Floor { get; set; }
    /// <summary>
    /// Piso al que pertenece la habitacion
    /// </summary>


    // Constructor
    public Room(int number, bool isProduction, string description, Floor floor)
    {
        Number = number;
        IsProduction = isProduction;
        Description = description;
        Floor = floor;
     }

}