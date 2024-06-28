using DataAccess.Contexts;
using Domain.Entities.ConfigurationData;
using Domain.Entities.HistoricalData;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;


//Creando un contexto para interactuar con la Base de Datos
ApplicationContext appContext = new ApplicationContext("Data Source=EnvironmentalVariablesDB.sqlite");

//Verificando si la BD no existe
if (!appContext.Database.CanConnect())
{
    //Migrando BD
    appContext.Database.Migrate();
}

Building Edificio1 = new Building(Guid.NewGuid(), "Ave. 114 y 51", 11401);

Building Edificio2 = new Building(Guid.NewGuid(), "Ave. 5ta y 84", 8402);

Floor Lobby1 = new Floor(Guid.NewGuid(), "Planta Baja", Edificio1);
Edificio1.Floors.Add(Lobby1);

Floor Lobby2 = new Floor(Guid.NewGuid(), "Planta Baja", Edificio2);
Edificio2.Floors.Add(Lobby2);

Floor Investigacion1 = new Floor(Guid.NewGuid(), "Segunda Planta", Edificio1);
Edificio1.Floors.Add(Investigacion1);

Floor Técnico1 = new Floor(Guid.NewGuid(), "Sótano", Edificio2);
Edificio2.Floors.Add(Técnico1);

Room Laboratorio1 = new Room(Guid.NewGuid(), 01, false, "Laboratorio de muestras", Investigacion1);
Investigacion1.Rooms.Add(Laboratorio1);

Room Laboratorio2 = new Room(Guid.NewGuid(), 03, true, "Laboratorio de productos", Investigacion1);
Investigacion1.Rooms.Add(Laboratorio2);

Room Taller1 = new Room(Guid.NewGuid(), 02, false, "Taller de piezas", Técnico1);
Técnico1.Rooms.Add(Taller1);

Room Taller2 = new Room(Guid.NewGuid(), 05, true, "Taller de productos", Técnico1);
Técnico1.Rooms.Add(Taller2);


Variable Var1 = new Variable(Guid.NewGuid(), Lobby1, new VariableType("Humedad", "g/m^3"), "H-01");
Lobby1.Variables.Add(Var1);
Variable Var2 = new Variable(Guid.NewGuid(), Lobby1, new VariableType("Temperatura", "ºC"), "T-01");
Lobby2.Variables.Add(Var2);
Variable Var3 = new Variable(Guid.NewGuid(), Investigacion1, new VariableType("Temperatura", "ºC"), "T-02");
Investigacion1.Variables.Add(Var3);
Variable Var4 = new Variable(Guid.NewGuid(), Laboratorio1, new VariableType("Humedad", "g/m^3"), "H-02");
Laboratorio1.Variables.Add(Var4);
Variable Var5 = new Variable(Guid.NewGuid(), Taller1, new VariableType("Presión", "PSI"), "P-01");
Taller1.Variables.Add(Var5);
Variable Var6 = new Variable(Guid.NewGuid(), Taller2, new VariableType("Presión", "PSI"), "P-02");
Taller2.Variables.Add(Var6);
Variable Var7 = new Variable(Guid.NewGuid(), Laboratorio2, new VariableType("Nivel Máximo", ""), "LM-01");
Laboratorio2.Variables.Add(Var7);

SampleDouble sample1 = new SampleDouble(Guid.NewGuid(), Var1, 2.56);
SampleInt sample2 = new SampleInt(Guid.NewGuid(), Var2, 22);
SampleDouble sample3 = new SampleDouble(Guid.NewGuid(), Var4, 1.21);
SampleInt sample4 = new SampleInt(Guid.NewGuid(), Var3, 25);
SampleInt sample5 = new SampleInt(Guid.NewGuid(), Var5, 11);
SampleInt sample6 = new SampleInt(Guid.NewGuid(), Var6, 42);
SampleBool sample7 = new SampleBool(Guid.NewGuid(), Var7, true);


//Almacenando entidades en BD
appContext.Structures.Add(Edificio1);
appContext.Structures.Add(Edificio2);

appContext.Structures.Add(Lobby1);
appContext.Structures.Add(Lobby2);
appContext.Structures.Add(Investigacion1);
appContext.Structures.Add(Técnico1);
appContext.Structures.Add(Laboratorio1);
appContext.Structures.Add(Laboratorio2);
appContext.Structures.Add(Taller1);
appContext.Structures.Add(Taller2);


appContext.Variables.Add(Var1);
appContext.Variables.Add(Var2);
appContext.Variables.Add(Var3);
appContext.Variables.Add(Var4);
appContext.Variables.Add(Var5);
appContext.Variables.Add(Var6);
appContext.Variables.Add(Var7);

appContext.Samples.Add(sample1);
appContext.Samples.Add(sample2);
appContext.Samples.Add(sample3);
appContext.Samples.Add(sample4);
appContext.Samples.Add(sample5);
appContext.Samples.Add(sample6);
appContext.Samples.Add(sample7);

appContext.SaveChanges();

Variable? Readvariable = appContext.Variables.FirstOrDefault(v => v.LocationId == Taller1.Id);

if (Readvariable != null){
    Console.WriteLine(Readvariable.ToString());
    Readvariable.Code = "X-00";
    appContext.Variables.Update(Readvariable);
    appContext.SaveChanges();

}



Variable? ModifiedVariable = appContext.Variables.FirstOrDefault(x => x.Id == Readvariable.Id);
if (ModifiedVariable != null)
{
    Console.WriteLine("Codigo modificado de la variable "+ModifiedVariable.Code);
    appContext.Variables.Remove(ModifiedVariable);
    

}

Variable? DeletedVariable = appContext.Variables.FirstOrDefault(x => x.Id == ModifiedVariable.Id);
if (ModifiedVariable == null)
{
    Console.WriteLine("Variable eliminada con éxito");
}

IEnumerable<Room> rooms = appContext.Set<Room>().TakeWhile(x => x.Floor.BuildingId == Edificio1.Id);
foreach (Room room in rooms)
{
    Console.WriteLine(room.ToString());
}





