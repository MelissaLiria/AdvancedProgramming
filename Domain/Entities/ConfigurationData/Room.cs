using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Room
{
    // Properties for Room
    public int Number { get; set; }
    public bool IsProduction { get; set; }
    public string Description { get; set; }


    // Constructor
    public Room(int number, bool isProduction, string description)
    {
        Number = number;
        IsProduction = isProduction;
        Description = description;

    }

}