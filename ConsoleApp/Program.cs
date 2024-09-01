
using Grpc.Net.Client;
using GrpcProtos;
using System.Globalization;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            Console.WriteLine("Press any key to start the connection\n");
            Console.ReadKey();

            Console.WriteLine("Connecting...\n");
            var httpHandler = new HttpClientHandler() { ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator };
            var channel = GrpcChannel.ForAddress("http://localhost:5094", new GrpcChannelOptions { HttpHandler = httpHandler });
            if (channel is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot connect\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                channel.Dispose();
                return;
            }

            object? allObjects = null;
            object? Object = null;
            while (loop is true)
            {
                Console.WriteLine("___________\n" +
                    "|MAIN MENU|\n" +
                    "¯¯¯¯¯¯¯¯¯¯¯\n" +
                    "Options: \n" +
                "1 - Create \n" +
                "2 - Get \n" +
                "3 - Finish conection \n");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("\nSelect the data type: \n" +
                            "1 - Building \n" +
                            "2 - Floor \n" +
                            "3 - Room \n" +
                            "4 - Variable \n" +
                            "5 - Sample \n");

                        switch (Console.ReadLine())
                        {
                            case "1":
                                CreateBuilding(channel);
                                break;

                            case "2":
                                CreateFloor(channel);
                                break;

                            case "3":
                                CreateRoom(channel);
                                break;

                            case "4":
                                CreateVariable(channel);
                                break;

                            case "5":
                                CreateSample(channel);
                                break;

                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nInvalid input");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                break;
                        } //Se crea el objeto 
                        break;

                    case "2":
                        bool cont = true;
                        Console.WriteLine("\nSelect the data type: \n" +
                           "1 - Building \n" +
                           "2 - Floor \n" +
                           "3 - Room \n" +
                           "4 - Variable \n" +
                           "5 - Sample \n");

                        string? DataTypeSelection = Console.ReadLine();
                        string? SampleTypeSelection = null;

                        switch (DataTypeSelection)
                        {
                            case "1":
                                allObjects = GetAllBuildings(channel);
                                var buildings = allObjects as Buildings;
                                if (buildings.Items.Count == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("\nEmpty List\n");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    cont = false;
                                }
                                break;

                            case "2":
                                allObjects = GetAllFloors(channel);
                                var floors = allObjects as Floors;
                                if (floors.Items.Count == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("\nEmpty List\n");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    cont = false;
                                }
                                break;

                            case "3":
                                allObjects = GetAllRooms(channel);
                                var rooms = allObjects as Rooms;
                                if (rooms.Items.Count == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("\nEmpty List\n");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    cont = false;
                                }
                                break;

                            case "4":
                                allObjects = GetAllVariables(channel);
                                var variables = allObjects as Variables;
                                if (variables.Items.Count == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("\nEmpty List\n");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    cont = false;
                                }
                                break;

                            case "5":
                                Console.WriteLine("\nWhat kind of sample do you want to get?: \n" +
                                            "1 - Int\n" +
                                            "2 - Double\n" +
                                            "3 - Bool\n");
                                SampleTypeSelection = Console.ReadLine();
                                if (SampleTypeSelection != "1" && SampleTypeSelection != "2" && SampleTypeSelection != "3")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nInvalid Input\n");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    cont = false;
                                    break;
                                }

                                Console.WriteLine("\nDo you want to search by: \n" +
                                    "1 - Variable \n" +
                                    "2 - Timespan \n" +
                                    "3 - Get all \n");

                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        switch (SampleTypeSelection)
                                        {
                                            case "1":
                                                allObjects = GetSampleIntByVariableId(channel);
                                                var sampleInts = allObjects as SampleInts;
                                                if (sampleInts.Items.Count == 0)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.WriteLine("\nEmpty List");
                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    cont = false;
                                                }
                                                break;

                                            case "2":
                                                allObjects = GetSampleDoubleByVariableId(channel);
                                                var sampleDoubles = allObjects as SampleDoubles;
                                                if (sampleDoubles.Items.Count == 0)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.WriteLine("\nEmpty List");
                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    cont = false;
                                                }
                                                break;

                                            case "3":
                                                allObjects = GetSampleBoolByVariableId(channel);
                                                var sampleBools = allObjects as SampleBools;
                                                if (sampleBools.Items.Count == 0)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.WriteLine("\nEmpty List");
                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    cont = false;
                                                }
                                                break;

                                            default:
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("\nInvalid input");
                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                cont = false;
                                                break;
                                        }//Muestra todos los samples int, double o bool de una variable
                                        break;

                                    case "2":
                                        switch (SampleTypeSelection)
                                        {
                                            case "1":
                                                allObjects = GetSampleIntByTimeSpan(channel);
                                                var sampleInts = allObjects as SampleInts;
                                                if (sampleInts.Items.Count == 0)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.WriteLine("\nEmpty List");
                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    cont = false;
                                                }
                                                break;

                                            case "2":
                                                allObjects = GetSampleDoubleByTimeSpan(channel);
                                                var sampleDoubles = allObjects as SampleDoubles;
                                                if (sampleDoubles.Items.Count == 0)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.WriteLine("\nEmpty List");
                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    cont = false;
                                                }
                                                break;

                                            case "3":
                                                allObjects = GetSampleBoolByTimeSpan(channel);
                                                var sampleBools = allObjects as SampleBools;
                                                if (sampleBools.Items.Count == 0)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.WriteLine("\nEmpty List");
                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    cont = false;
                                                }
                                                break;

                                            default:
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("\nInvalid input");
                                                Console.ForegroundColor = ConsoleColor.Gray;                                              
                                                cont = false;
                                                break;
                                        }//Muestra todos los samples int, double o bool en un intervalo de tiempo
                                        break;

                                    case "3":
                                        switch (SampleTypeSelection)
                                        {
                                            case "1":
                                                allObjects = GetAllSampleInts(channel);
                                                var sampleInts = allObjects as SampleInts;
                                                if (sampleInts.Items.Count == 0)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.WriteLine("\nEmpty List");
                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    cont = false;
                                                }
                                                break;

                                            case "2":
                                                allObjects = GetAllSampleDoubles(channel);
                                                var sampleDoubles = allObjects as SampleDoubles;
                                                if (sampleDoubles.Items.Count == 0)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.WriteLine("\nEmpty List");
                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    cont = false;
                                                }
                                                break;

                                            case "3":
                                                allObjects = GetAllSampleBools(channel);
                                                var sampleBools = allObjects as SampleBools;
                                                if (sampleBools.Items.Count == 0)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.WriteLine("\nEmpty List");
                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    cont = false;
                                                }
                                                break;

                                            default:
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("\nInvalid input");
                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                cont = false;
                                                break;
                                        }//Muestra todos los samples int, double o bool
                                        break;

                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\nInvalid input");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        cont = false;
                                        break;
                                }
                                break;

                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nInvalid input");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                cont = false;
                                break;
                        }// Muestra todos los objetos de un tipo

                        if (cont is true)
                        {
                            bool loop2 = true;
                            bool cont2 = true;

                            while (loop2)
                            {
                                Console.WriteLine("Options: \n" +
                                    "1 - Select \n" +
                                    "2 - Return to main menu \n");

                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        switch (DataTypeSelection)
                                        {
                                            case "1":
                                                Object = GetBuilding(channel, allObjects as Buildings).Building;
                                                break;

                                            case "2":
                                                Object = GetFloor(channel, allObjects as Floors).Floor;
                                                break;

                                            case "3":
                                                Object = GetRoom(channel, allObjects as Rooms).Room;
                                                break;

                                            case "4":
                                                Object = GetVariable(channel, allObjects as Variables).Variable;
                                                break;

                                            case "5":
                                                switch (SampleTypeSelection)
                                                {
                                                    case "1":
                                                        Object = GetSampleInt(channel, allObjects as SampleInts).SampleInt;
                                                        break;

                                                    case "2":
                                                        Object = GetSampleDouble(channel, allObjects as SampleDoubles).SampleDouble;
                                                        break;

                                                    case "3":
                                                        Object = GetSampleBool(channel, allObjects as SampleBools).SampleBool;
                                                        break;

                                                    default:
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("\nInvalid action\n");
                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        break;
                                                }
                                                break;

                                            default:
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("\nInvalid input\n");
                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                cont2 = false;
                                                break;
                                        }
                                        loop2 = false;
                                        break;

                                    case "2":
                                        cont2 = false;
                                        loop2 = false;
                                        break;

                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid input\n");
                                        Console.ForegroundColor = ConsoleColor.Gray;                                       
                                        break;
                                }//Muestra la informacion del objeto seleccionado
                            }

                            if (cont2 is true)
                            {
                                bool loop3 = true;
                                while (loop3)
                                {
                                    Console.WriteLine("Options: \n" +
                                        "1 - Update \n" +
                                        "2 - Delete \n" +
                                        "3 - Return to main menu\n");

                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            switch (DataTypeSelection)
                                            {
                                                case "1":
                                                    UpdateBuilding(channel, Object as BuildingDTO);
                                                    break;

                                                case "2":
                                                    UpdateFloor(channel, Object as FloorDTO);
                                                    break;

                                                case "3":
                                                    UpdateRoom(channel, Object as RoomDTO);
                                                    break;

                                                case "4":
                                                    UpdateVariable(channel, Object as VariableDTO);
                                                    break;

                                                case "5":
                                                    switch (SampleTypeSelection)
                                                    {
                                                        case "1":
                                                            UpdateSampleInt(channel, Object as SampleIntDTO);
                                                            break;

                                                        case "2":
                                                            UpdateSampleDouble(channel, Object as SampleDoubleDTO);
                                                            break;

                                                        case "3":
                                                            UpdateSampleBool(channel, Object as SampleBoolDTO);
                                                            break;

                                                        default:
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("\nInvalid input\n");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                            break;
                                                    }
                                                    break;

                                                default:
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\nInvalid input\n");
                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    break;
                                            }//Se actualizan los objetos
                                            loop3 = false;
                                            break;

                                        case "2":
                                            switch (DataTypeSelection)
                                            {
                                                case "1":
                                                    DeleteBuilding(channel, Object as BuildingDTO);
                                                    break;

                                                case "2":
                                                    DeleteFloor(channel, Object as FloorDTO);
                                                    break;

                                                case "3":
                                                    DeleteRoom(channel, Object as RoomDTO);
                                                    break;

                                                case "4":
                                                    DeleteVariable(channel, Object as VariableDTO);
                                                    break;

                                                case "5":
                                                    switch (SampleTypeSelection)
                                                    {
                                                        case "1":
                                                            DeleteSampleInt(channel, Object as SampleIntDTO);
                                                            break;

                                                        case "2":
                                                            DeleteSampleDouble(channel, Object as SampleDoubleDTO);
                                                            break;

                                                        case "3":
                                                            DeleteSampleBool(channel, Object as SampleBoolDTO);
                                                            break;

                                                        default:
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("\nInvalid input\n");
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                            break;
                                                    }
                                                    break;

                                                default:
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\nInvalid input\n");
                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    break;
                                            }//Se eliminan los objetos
                                            loop3 = false;
                                            break;

                                        case "3":
                                            break;

                                        default:
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("\nInvalid input\n");
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            break;
                                    }
                                }
                            }
                        }
                        break;

                    case "3":
                        channel.Dispose();
                        return;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid input");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            }
        }
        public static void CreateBuilding(GrpcChannel channel)
        {
            var buildingClient = new Building.BuildingClient(channel);
            Console.Write("\nInsert the following data: \n" +
                           "Address: ");
            var address = Console.ReadLine();
            Console.Write("\nNumber: ");
            var number = Convert.ToInt32(Console.ReadLine());
            var createResponse = buildingClient.CreateBuilding(new CreateBuildingRequest()
            {
                Address = address,
                Number = number,
            });

            if (createResponse is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCannot create object");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSuccesfully Created");
                Console.ForegroundColor = ConsoleColor.Gray;             
            }
        }

        public static void CreateFloor(GrpcChannel channel)
        {
            var floorClient = new Floor.FloorClient(channel);

            Console.Write("Insert the following data: \n" +
                "Location: ");
            var location = Console.ReadLine();

            var allBuildings = GetAllBuildings(channel);
            if (allBuildings.Items.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nNo building in the DataBase");
                Console.ForegroundColor = ConsoleColor.Red;              
                Console.WriteLine("\nCannot create floor");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }

            int position = 0;
            bool loop = true;
            while (loop)
            {
                Console.Write("Select the Building: ");
                try
                {
                    loop = false;
                    position = Convert.ToInt32(Console.ReadLine()) - 1;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid Input");
                    Console.ForegroundColor = ConsoleColor.Gray;                   
                    loop = true;
                }
                if (position < 0 || position >= allBuildings.Items.Count())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid Input");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    loop = true;
                }
            }

            var createResponse = floorClient.CreateFloor(new CreateFloorRequest()
            {
                Location = location,
                Building = allBuildings.Items[position]
            });


            if (createResponse is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCannot create floor");
                Console.ForegroundColor = ConsoleColor.Gray;              
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nSuccesfully Created");
                Console.ForegroundColor = ConsoleColor.Gray;                
            }
        }

        public static void CreateRoom(GrpcChannel channel)
        {
            var roomClient = new Room.RoomClient(channel);
            var buildingClient = new Building.BuildingClient(channel);

            Console.Write("Insert the following data: \n" +
                "Number: ");
            var roomNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nDescription: ");
            var description = Console.ReadLine();

            Console.Write("\nIs a production room or an office? \n" +
                "1 - Production \n" +
                "2 - Office\n");

            bool isProduction;

            if (Console.ReadLine() == "1")
            {
                isProduction = true;
            }
            else
            {
                isProduction = false;
            }

            var allFloors = GetAllFloors(channel);

            if (allFloors.Items.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nNo floor in the DataBase");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCannot create room");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }

            int position = 0;
            bool loop = true;
            while (loop)
            {
                Console.Write("Select the Floor: ");
                try
                {
                    loop = false;
                    position = Convert.ToInt32(Console.ReadLine()) - 1;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid Input");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    loop = true;
                }
                if (position < 0 || position >= allFloors.Items.Count())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid Input");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    loop = true;
                }
            }

            var floorOfRoom = allFloors.Items[position];
            floorOfRoom.Building = buildingClient.GetBuilding(new GetRequest() { Id = allFloors.Items[position].BuildingId }).Building;

            var createResponse = roomClient.CreateRoom(new CreateRoomRequest()
            {
                Number = roomNumber,
                Description = description,
                IsProduction = isProduction,
                Floor = floorOfRoom
            });

            if (createResponse is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCannot create room");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nSuccesfully Created");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void CreateVariable(GrpcChannel channel)
        {
            var variableClient = new Variable.VariableClient(channel);
            var floorClient = new Floor.FloorClient(channel);
            var buildingClient = new Building.BuildingClient(channel);

            Console.Write("Insert the following data: \n" +
                "Code: ");
            var code = Console.ReadLine();

            Console.Write("\nName: ");
            var name = Console.ReadLine();

            Console.Write("\nMeasurement unit: ");
            var measurementUnit = Console.ReadLine();

            Console.WriteLine("\nWhere is located? \n" +
                "1 - Building \n" +
                "2 - Floor \n" +
                "3 - Room \n");

            VariableDTO createResponse = null;

            //Lista de Edificios, pisos o habitaciones para escoger la ubicacion de la variable
            switch (Console.ReadLine())
            {
                case "1":
                    var allBuildings = GetAllBuildings(channel);

                    if (allBuildings.Items.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\nNo building in the DataBase");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nCannot create variable");
                        return;
                    }

                    int position = 0;
                    bool loop = true;
                    while (loop)
                    {
                        Console.Write("Select the Building: ");
                        try
                        {
                            loop = false;
                            position = Convert.ToInt32(Console.ReadLine()) - 1;
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInvalid Input");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            loop = true;
                        }
                        if (position < 0 || position >= allBuildings.Items.Count)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInvalid Input");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            loop = true;
                        }
                    }

                    var buildingOfVariable = allBuildings.Items[position];
                    createResponse = variableClient.CreateVariable(new CreateVariableRequest()
                    {
                        Code = code,
                        VariableType = new VariableType() { Name = name, MeasurementUnit = measurementUnit },
                        Building = buildingOfVariable
                    });
                    break;

                case "2":                   
                    var allFloors = GetAllFloors(channel);
                    if (allFloors.Items.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\nNo floor in the DataBase");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nCannot create variable");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return;
                    }

                    int position2 = 0;
                    bool loop2 = true;
                    while (loop2)
                    {
                        Console.Write("Select the Floor: ");
                        try
                        {
                            loop2 = false;
                            position2 = Convert.ToInt32(Console.ReadLine()) - 1;
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInvalid Input");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            loop2 = true;
                        }
                        if (position2 < 0 || position2 >= allFloors.Items.Count())
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInvalid Input");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            loop2 = true;
                        }
                    }


                    var floorOfVariable = allFloors.Items[position2];
                    var buildingOfFloor = buildingClient.GetBuilding(new GetRequest() { Id = floorOfVariable.BuildingId });
                    floorOfVariable.Building = buildingOfFloor.Building;
                    createResponse = variableClient.CreateVariable(new GrpcProtos.CreateVariableRequest()
                    {
                        Code = code,
                        VariableType = new VariableType() { Name = name, MeasurementUnit = measurementUnit },
                        Floor = floorOfVariable
                    });
                    break;

                case "3":
                   
                    var allRooms = GetAllRooms(channel);
                    if (allRooms.Items.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("No room in the DataBase");
                        Console.ForegroundColor = ConsoleColor.Red;                        
                        Console.WriteLine("Cannot create variable");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return;
                    }

                    int position3 = 0;
                    bool loop3 = true;
                    while (loop3)
                    {
                        Console.Write("Select the Room: ");
                        try
                        {
                            loop3 = false;
                            position3 = Convert.ToInt32(Console.ReadLine()) - 1;
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInvalid Input");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            loop3 = true;
                        }
                        if (position3 < 0 || position3 >= allRooms.Items.Count())
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInvalid Input");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            loop3 = true;
                        }
                    }


                    var roomOfVariable = allRooms.Items[position3];
                    var floorOfRoom = floorClient.GetFloor(new GetRequest() { Id = roomOfVariable.FloorId });
                    var buildingOfRoom = buildingClient.GetBuilding(new GetRequest() { Id = floorOfRoom.Floor.BuildingId });
                    roomOfVariable.Floor = floorOfRoom.Floor;
                    roomOfVariable.Floor.Building = buildingOfRoom.Building;

                    createResponse = variableClient.CreateVariable(new CreateVariableRequest()
                    {
                        Code = code,
                        VariableType = new VariableType() { Name = name, MeasurementUnit = measurementUnit },
                        Room = roomOfVariable
                    });
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid Input");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }

            if (createResponse is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCannot create variable");
                Console.ForegroundColor = ConsoleColor.Gray;             
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nSuccesfully Created");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void CreateSample(GrpcChannel channel)
        {

            var sampleIntClient = new SampleInt.SampleIntClient(channel);
            var sampleDoubleClient = new SampleDouble.SampleDoubleClient(channel);
            var sampleBoolClient = new SampleBool.SampleBoolClient(channel);


            var allVariables = GetAllVariables(channel);
            if (allVariables.Items.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nNo variable in the DataBase");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCannot create sample");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }

            int position = 0;
            bool loop = true;
            while (loop)
            {
                Console.Write("Select the Variable: ");
                try
                {
                    loop = false;
                    position = Convert.ToInt32(Console.ReadLine()) - 1;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid Input");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    loop = true;
                }
                if (position < 0 || position >= allVariables.Items.Count())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid Input");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    loop = true;
                }
            }

            string variableId = allVariables.Items[position].Id;

            Console.WriteLine("\nSelect the Sample DataType: \n" +
                "1 - Int\n" +
                "2 - Double\n" +
                "3 - Boolean\n");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("\nInsert Value: ");
                    var createResponseInt = sampleIntClient.CreateSampleInt(new CreateSampleIntRequest()
                    {
                        VariableId = variableId,
                        Value = Convert.ToInt32(Console.ReadLine())
                    });

                    if (createResponseInt is null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nCannot create variable");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nSuccesfully Created\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    break;

                case "2":
                    Console.Write("\nInsert Value: ");
                    var createResponseDouble = sampleDoubleClient.CreateSampleDouble(new CreateSampleDoubleRequest()
                    {
                        VariableId = variableId,
                        Value = Convert.ToDouble(Console.ReadLine())
                    });

                    if (createResponseDouble is null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nCannot create variable");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nSuccesfully Created");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    break;

                case "3":
                    Console.Write("\nInsert Value (true/false): ");
                    var createResponseBool = sampleBoolClient.CreateSampleBool(new CreateSampleBoolRequest()
                    {
                        VariableId = variableId,
                        Value = Convert.ToBoolean(Console.ReadLine())
                    });

                    if (createResponseBool is null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nCannot create variable");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nSuccesfully Created");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid Input");
                    Console.ForegroundColor = ConsoleColor.Gray;                   
                    break;
            }
        }

        public static void UpdateBuilding(GrpcChannel channel, BuildingDTO buildingToUpdate)
        {
            var buildingClient = new Building.BuildingClient(channel);
            bool loop = true;

            while (loop)
            {
                Console.WriteLine("\nWhat do you want to modify? \n" +
                    "Number: " + buildingToUpdate.Number + "\n" +
                    "Address: " + buildingToUpdate.Address + "\n" +
                    "\nWrite 1 for Number or 2 for Address\n" +
                    "Press 3 to save\n");

                // Se modifica el numero o la direccion.
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("\nWrite the new number");
                        buildingToUpdate.Number = Convert.ToInt32(Console.ReadLine());
                        break;

                    case "2":
                        Console.WriteLine("\nWrite the new Address");
                        buildingToUpdate.Address = Console.ReadLine();
                        break;

                    case "3":
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("Invalid action");
                        break;
                }
            }
            buildingClient.UpdateBuilding(buildingToUpdate);

            var updatedGetResponse = buildingClient.GetBuilding(new GetRequest() { Id = buildingToUpdate.Id });
            if (updatedGetResponse is not null &&
                updatedGetResponse.KindCase == NullableBuildingDTO.KindOneofCase.Building &&
                updatedGetResponse.Building.Number == buildingToUpdate.Number &&
                updatedGetResponse.Building.Address == buildingToUpdate.Address)
            {
                Console.WriteLine($"Succesfully Updated\n");
            }
        }

        public static void UpdateFloor(GrpcChannel channel, FloorDTO floorToUpdate)
        {
            var floorClient = new Floor.FloorClient(channel);
            var buildingClient = new Building.BuildingClient(channel);

            bool loop = true;

            while (loop)
            {
                var building = buildingClient.GetBuilding(new GetRequest() { Id = floorToUpdate.BuildingId });

                Console.WriteLine("\nWhat do you want to modify? \n" +
                    "Location: " + floorToUpdate.Location + "\n" +
                    "Building Number: " + building.Building.Number + "\n" +
                    "Building Address: " + building.Building.Address + "\n" +
                    "\nWrite 1 for Location, 2 for Building\n" +
                    "Press 3 to save");

                //Se modifica la locacion del piso o el edifico al que esta asosiado.
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("\nWrite the new Location");
                        floorToUpdate.Location = Console.ReadLine();
                        floorToUpdate.Building = building.Building;
                        break;

                    case "2":                     
                        var allBuildings = GetAllBuildings(channel);
                        Console.Write("\nSelect the  building: ");
                        floorToUpdate.Building = allBuildings.Items[Convert.ToInt32(Console.ReadLine()) - 1];
                        floorToUpdate.BuildingId = floorToUpdate.Building.Id;
                        break;

                    case "3":
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("Invalid action");
                        break;
                }
            }

            floorClient.UpdateFloor(floorToUpdate);

            var updatedGetResponse = floorClient.GetFloor(new GetRequest() { Id = floorToUpdate.Id });
            if (updatedGetResponse is not null &&
                updatedGetResponse.KindCase == NullableFloorDTO.KindOneofCase.Floor &&
                updatedGetResponse.Floor.Location == floorToUpdate.Location &&
                updatedGetResponse.Floor.BuildingId == floorToUpdate.BuildingId)
            {
                Console.WriteLine($"Succesfully Updated\n");
            }
        }

        public static void UpdateRoom(GrpcChannel channel, RoomDTO roomToUpdate)
        {
            var buildingClient = new Building.BuildingClient(channel);
            var floorClient = new Floor.FloorClient(channel);
            var roomClient = new Room.RoomClient(channel);

            bool loop = true;

            while (loop)
            {
                var floorOfRoom = floorClient.GetFloor(new GetRequest() { Id = roomToUpdate.FloorId });
                floorOfRoom.Floor.Building = buildingClient.GetBuilding(new GetRequest() { Id = floorOfRoom.Floor.BuildingId }).Building;

                Console.WriteLine("\nWhat do you want to modify? \n" +
                    "Number: " + roomToUpdate.Number + "\n" +
                    "Description: " + roomToUpdate.Description + "\n" +
                    "Floor Location: " + floorOfRoom.Floor.Location + "\n" +
                    "Building Number: " + floorOfRoom.Floor.Building.Number + "\n" +
                    "Building Address: " + floorOfRoom.Floor.Building.Address);

                if (roomToUpdate.IsProduction is true)
                {
                    Console.WriteLine("Type: Production");
                }
                else
                {
                    Console.WriteLine("Type: Office");
                }
                Console.WriteLine("\nWrite 1 for Number, 2 for Description or 3 for Floor\n" +
                    "Press 4 to save");

                //Se modifica la descripcion de la habitacion, 
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("\nWrite the new room number ");
                        roomToUpdate.Number = Convert.ToInt32(Console.ReadLine());
                        break;

                    case "2":
                        Console.WriteLine("\nWrite the new description ");
                        roomToUpdate.Description = Console.ReadLine();
                        break;

                    case "3":                       
                        var allFloors = GetAllFloors(channel);
                        Console.Write("\nSelect the floor: ");
                        roomToUpdate.Floor = allFloors.Items[Convert.ToInt32(Console.ReadLine()) - 1];
                        roomToUpdate.FloorId = roomToUpdate.Floor.Id;
                        break;

                    case "4":
                        roomToUpdate.Floor = floorOfRoom.Floor;
                        roomToUpdate.Floor.Building = floorOfRoom.Floor.Building;
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid action");
                        break;
                }
            }

            roomClient.UpdateRoom(roomToUpdate);

            var updatedGetResponse = roomClient.GetRoom(new GetRequest() { Id = roomToUpdate.Id });
            if (updatedGetResponse is not null &&
                updatedGetResponse.KindCase == NullableRoomDTO.KindOneofCase.Room &&
                updatedGetResponse.Room.Description == roomToUpdate.Description &&
                updatedGetResponse.Room.Floor == roomToUpdate.Floor &&
                updatedGetResponse.Room.Floor.Building == roomToUpdate.Floor.Building)
            {
                Console.WriteLine($"Succesfully Updated\n");
            }
        }

        public static void UpdateVariable(GrpcChannel channel, VariableDTO variableToUpdate)
        {
            var variableClient = new Variable.VariableClient(channel);
            var buildingClient = new Building.BuildingClient(channel);
            var floorClient = new Floor.FloorClient(channel);

            bool loop = true;

            while (loop)
            {
                Console.WriteLine("\nWhat do you want to modify? \n" +
                "Code: " + variableToUpdate.Code + "\n" +
                "Name: " + variableToUpdate.VariableType.Name + "\n" +
                "Measurement unit: " + variableToUpdate.VariableType.MeasurementUnit + "\n");
                if (variableToUpdate.LocationCase is VariableDTO.LocationOneofCase.Building)
                {
                    Console.WriteLine("Location: Building No." + variableToUpdate.Building.Number.ToString() + "\n");
                }
                else if (variableToUpdate.LocationCase is VariableDTO.LocationOneofCase.Floor)
                {
                    Console.WriteLine("Location: " + variableToUpdate.Floor.Location + " of Building No." + variableToUpdate.Floor.Building.Number.ToString() + "\n");
                }
                else if (variableToUpdate.LocationCase is VariableDTO.LocationOneofCase.Room)
                {
                    Console.WriteLine("Location: Room No." + variableToUpdate.Room.Number.ToString() + " of " + variableToUpdate.Room.Floor.Location + " of Building No." + variableToUpdate.Room.Floor.Building.Number.ToString() + "\n");
                }

                Console.WriteLine("\nWrite 1 for Code, 2 for Name, 3 for Measurement unit or 4 for Location\n" +
                    "Press 5 to save");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("\nWrite the new code:");
                        variableToUpdate.Code = Console.ReadLine();
                        break;

                    case "2":
                        Console.Write("\nWrite the new name:");
                        variableToUpdate.VariableType.Name = Console.ReadLine();
                        break;

                    case "3":
                        Console.Write("\nWrite the new measuremnt unit:");
                        variableToUpdate.VariableType.MeasurementUnit = Console.ReadLine();
                        break;

                    case "4":
                        Console.WriteLine("Select the new location type: \n" +
                            "1 - Building \n" +
                            "2 - Floor \n" +
                            "3 - Room \n");

                        switch (Console.ReadLine())
                        {
                            case "1":
                                var allBuildings = GetAllBuildings(channel);
                                Console.Write("\nSelect the corresponding building: ");
                             
                                var buildingLocation = buildingClient.GetBuilding(new GetRequest() { Id = allBuildings.Items[Convert.ToInt32(Console.ReadLine()) - 1].Id });

                                variableToUpdate.Building = buildingLocation.Building;
                                variableToUpdate.LocationId = buildingLocation.Building.Id;
                                variableToUpdate.StructureType = StructureType.Building;
                                break;

                            case "2":
                                var allFloors = GetAllFloors(channel);
                                Console.Write("\nSelect the corresponding floor: ");                               

                                var floorLocation = floorClient.GetFloor(new GetRequest() { Id = allFloors.Items[Convert.ToInt32(Console.ReadLine()) - 1].Id });
                                floorLocation.Floor.Building = buildingClient.GetBuilding(new GetRequest() { Id = floorLocation.Floor.BuildingId }).Building;

                                variableToUpdate.Floor = floorLocation.Floor;
                                variableToUpdate.LocationId = floorLocation.Floor.Id;
                                variableToUpdate.StructureType = StructureType.Floor;
                                variableToUpdate.Floor.Building = floorLocation.Floor.Building;
                                break;

                            case "3":                              
                                var roomClient = new Room.RoomClient(channel);
                                var allRooms = GetAllRooms(channel);
                                Console.Write("\nSelect the corresponding room: ");

                                var roomLocation = roomClient.GetRoom(new GetRequest() { Id = allRooms.Items[Convert.ToInt32(Console.ReadLine()) - 1].Id });
                                roomLocation.Room.Floor = floorClient.GetFloor(new GetRequest() { Id = roomLocation.Room.FloorId }).Floor;
                                roomLocation.Room.Floor.Building = buildingClient.GetBuilding(new GetRequest() { Id = roomLocation.Room.Floor.BuildingId }).Building;
                                variableToUpdate.Room = roomLocation.Room;
                                variableToUpdate.LocationId = roomLocation.Room.Id;
                                variableToUpdate.StructureType = StructureType.Room;
                                variableToUpdate.Floor = roomLocation.Room.Floor;
                                variableToUpdate.Floor.Building = roomLocation.Room.Floor.Building;
                                break;
                        }
                        break;

                    case "5":
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("Invalid action");
                        break;
                }
            }

            variableClient.UpdateVariable(variableToUpdate);

            var updatedGetResponse = variableClient.GetVariable(new GetRequest() { Id = variableToUpdate.Id });
            if (updatedGetResponse is not null &&
                updatedGetResponse.KindCase == NullableVariableDTO.KindOneofCase.Variable &&
                updatedGetResponse.Variable.Code == variableToUpdate.Code &&
                updatedGetResponse.Variable.VariableType == variableToUpdate.VariableType &&
                updatedGetResponse.Variable.LocationCase == variableToUpdate.LocationCase)
            {
                Console.WriteLine($"Succesfully Updated\n");
            }
        }

        public static void UpdateSampleInt(GrpcChannel channel, SampleIntDTO sampleToUpdate)
        {
            var sampleClient = new SampleInt.SampleIntClient(channel);
            var variableClient = new Variable.VariableClient(channel);

            bool loop = true;
            VariableDTO variable = variableClient.GetVariable(new GetRequest() { Id = sampleToUpdate.VariableId }).Variable;
            while (loop)
            {
                Console.WriteLine("\nSelected Sample \n" +
                "Variable: " + variable.Code + "\n" +
                "Date & Time: " + ParseDateTimeExactToSimple(sampleToUpdate.DateTime) + "\n" +
                "Value: " + sampleToUpdate.Value.ToString() + "\n");

                Console.Write("\nInsert the new value: ");
                sampleToUpdate.Value = Convert.ToInt32(Console.ReadLine());

                Console.Write("\nSave this value?(1 = yes / 0 = no): ");
                if (Console.ReadLine() == "1")
                    loop = false;

            }

            sampleClient.UpdateSampleInt(sampleToUpdate);

            var sampleGetResponse = sampleClient.GetSampleIntByTimeSpan(
                new GrpcProtos.TimeSpan() { StartTime = sampleToUpdate.DateTime, EndTime = sampleToUpdate.DateTime });
            foreach (SampleIntDTO item in sampleGetResponse.Items)
            {
                if (item.VariableId == sampleToUpdate.VariableId)
                    if (item.Value == sampleToUpdate.Value)
                        Console.WriteLine($"Succesfully Updated\n");
            }
        }

        public static void UpdateSampleDouble(GrpcChannel channel, SampleDoubleDTO sampleToUpdate)
        {
            var sampleClient = new SampleDouble.SampleDoubleClient(channel);
            var variableClient = new Variable.VariableClient(channel);

            bool loop = true;
            VariableDTO variable = variableClient.GetVariable(new GetRequest() { Id = sampleToUpdate.VariableId }).Variable;
            while (loop)
            {
                Console.WriteLine("\nSelected Sample \n" +
                "Variable: " + variable.Code + "\n" +
                "Date & Time: " + ParseDateTimeExactToSimple(sampleToUpdate.DateTime) + "\n" +
                "Value: " + sampleToUpdate.Value.ToString() + "\n");

                Console.Write("\nInsert the new value: ");
                sampleToUpdate.Value = Convert.ToDouble(Console.ReadLine());

                Console.Write("\nSave this value?(1 = yes / 0 = no) ");
                if (Console.ReadLine() == "1")
                    loop = false;
            }

            sampleClient.UpdateSampleDouble(sampleToUpdate);

            var sampleGetResponse = sampleClient.GetSampleDoubleByTimeSpan(
                new GrpcProtos.TimeSpan() { StartTime = sampleToUpdate.DateTime, EndTime = sampleToUpdate.DateTime });
            foreach (SampleDoubleDTO item in sampleGetResponse.Items)
            {
                if (item.VariableId == sampleToUpdate.VariableId)
                    if (item.Value == sampleToUpdate.Value)
                        Console.WriteLine($"Succesfully Updated\n");
            }
        }

        public static void UpdateSampleBool(GrpcChannel channel, SampleBoolDTO sampleToUpdate)
        {
            var sampleClient = new SampleBool.SampleBoolClient(channel);
            var variableClient = new Variable.VariableClient(channel);

            bool loop = true;
            VariableDTO variable = variableClient.GetVariable(new GetRequest() { Id = sampleToUpdate.VariableId }).Variable;
            while (loop)
            {
                Console.WriteLine("\nSelected Sample \n" +
                "Variable: " + variable.Code + "\n" +
                "Date & Time: " + ParseDateTimeExactToSimple(sampleToUpdate.DateTime) + "\n" +
                "Value: " + sampleToUpdate.Value.ToString() + "\n");

                Console.Write("\nInsert the new value: ");
                sampleToUpdate.Value = Convert.ToBoolean(Console.ReadLine());

                Console.Write("\nSave this value?(1 = yes / 0 = no): ");
                if (Console.ReadLine() == "1")
                    loop = false;
            }

            sampleClient.UpdateSampleBool(sampleToUpdate);

            var sampleGetResponse = sampleClient.GetSampleBoolByTimeSpan(
                new GrpcProtos.TimeSpan() { StartTime = sampleToUpdate.DateTime, EndTime = sampleToUpdate.DateTime });
            foreach (SampleBoolDTO item in sampleGetResponse.Items)
            {
                if (item.VariableId == sampleToUpdate.VariableId)
                    if (item.Value == sampleToUpdate.Value)
                        Console.WriteLine($"Succesfully Updated\n");
            }
        }

        public static void DeleteBuilding(GrpcChannel channel, BuildingDTO buildingToDelete)
        {
            var buildingClient = new Building.BuildingClient(channel);

            buildingClient.DeleteBuilding(new DeleteRequest() { Id = buildingToDelete.Id });
            var deletedGetResponse = buildingClient.GetBuilding(new GetRequest() { Id = buildingToDelete.Id });
            if (deletedGetResponse is null ||
                deletedGetResponse.KindCase != NullableBuildingDTO.KindOneofCase.Building)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nSuccesfully Deleted\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void DeleteFloor(GrpcChannel channel, FloorDTO floorToDelete)
        {
            var floorClient = new Floor.FloorClient(channel);

            floorClient.DeleteFloor(new DeleteRequest() { Id = floorToDelete.Id });
            var deletedGetResponse = floorClient.GetFloor(new GetRequest() { Id = floorToDelete.Id });
            if (deletedGetResponse is null ||
                deletedGetResponse.KindCase != NullableFloorDTO.KindOneofCase.Floor)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nSuccesfully Deleted\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void DeleteRoom(GrpcChannel channel, RoomDTO roomToDelete)
        {
            var roomClient = new Room.RoomClient(channel);

            roomClient.DeleteRoom(new DeleteRequest() { Id = roomToDelete.Id });
            var deletedGetResponse = roomClient.GetRoom(new GetRequest() { Id = roomToDelete.Id });
            if (deletedGetResponse is null ||
                deletedGetResponse.KindCase != NullableRoomDTO.KindOneofCase.Room)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nSuccesfully Deleted\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void DeleteVariable(GrpcChannel channel, VariableDTO variableToDelete)
        {
            var variableClient = new Variable.VariableClient(channel);

            variableClient.DeleteVariable(new DeleteRequest() { Id = variableToDelete.Id });
            var deletedGetResponse = variableClient.GetVariable(new GetRequest() { Id = variableToDelete.Id });
            if (deletedGetResponse is null ||
                deletedGetResponse.KindCase != NullableVariableDTO.KindOneofCase.Variable)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nSuccesfully Deleted\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void DeleteSampleInt(GrpcChannel channel, SampleIntDTO sampleToDelete)
        {
            var sampleClient = new SampleInt.SampleIntClient(channel);

            sampleClient.DeleteSampleInt(new DeleteSampleRequest() { VariableId = sampleToDelete.VariableId, DateTime = sampleToDelete.DateTime });

            var deletedGetResponse = sampleClient.GetSampleIntByTimeSpan(
               new GrpcProtos.TimeSpan() { StartTime = sampleToDelete.DateTime, EndTime = sampleToDelete.DateTime });

            int count = 0;
            foreach (SampleIntDTO item in deletedGetResponse.Items)
            {
                if (item.VariableId == sampleToDelete.VariableId)
                    count++;
            }
            if (count == 0)
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nSuccesfully Deleted\n");
                Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void DeleteSampleDouble(GrpcChannel channel, SampleDoubleDTO sampleToDelete)
        {
            var sampleClient = new SampleDouble.SampleDoubleClient(channel);

            sampleClient.DeleteSampleDouble(new DeleteSampleRequest() { VariableId = sampleToDelete.VariableId, DateTime = sampleToDelete.DateTime });

            var deletedGetResponse = sampleClient.GetSampleDoubleByTimeSpan(
               new GrpcProtos.TimeSpan() { StartTime = sampleToDelete.DateTime, EndTime = sampleToDelete.DateTime });

            int count = 0;
            foreach (SampleDoubleDTO item in deletedGetResponse.Items)
            {
                if (item.VariableId == sampleToDelete.VariableId)
                    count++;
            }
            if (count == 0)
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nSuccesfully Deleted\n");
                Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void DeleteSampleBool(GrpcChannel channel, SampleBoolDTO sampleToDelete)
        {
            var sampleClient = new SampleBool.SampleBoolClient(channel);

            sampleClient.DeleteSampleBool(new DeleteSampleRequest() { VariableId = sampleToDelete.VariableId, DateTime = sampleToDelete.DateTime });

            var deletedGetResponse = sampleClient.GetSampleBoolByTimeSpan(
               new GrpcProtos.TimeSpan() { StartTime = sampleToDelete.DateTime, EndTime = sampleToDelete.DateTime });

            int count = 0;
            foreach (SampleBoolDTO item in deletedGetResponse.Items)
            {
                if (item.VariableId == sampleToDelete.VariableId)
                    count++;
            }
            if (count == 0)
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nSuccesfully Deleted\n");
                Console.ForegroundColor = ConsoleColor.Gray; 
        }

        public static Buildings? GetAllBuildings(GrpcChannel channel)
        {
            var buildingClient = new Building.BuildingClient(channel);
            var getResponse = buildingClient.GetAllBuildings(new Google.Protobuf.WellKnownTypes.Empty());

            if (getResponse.Items is null)
            {
                Console.WriteLine("There is none");
                channel.Dispose();
            }
            else
            {
                for (int i = 1; i <= getResponse.Items.Count; i++)
                {
                    Console.WriteLine(i + " - Number: " + getResponse.Items[i - 1].Number + "\n\t" +
                        "Address: " + getResponse.Items[i - 1].Address + "\n");
                }
            }
            return getResponse;
        }

        public static Floors? GetAllFloors(GrpcChannel channel)
        {
            var floorClient = new Floor.FloorClient(channel);
            var buildingClient = new Building.BuildingClient(channel);
            var getResponse = floorClient.GetAllFloors(new Google.Protobuf.WellKnownTypes.Empty());

            if (getResponse.Items is null)
            {
                Console.WriteLine("There is none");
                channel.Dispose();
            }
            else
            {

                for (int i = 1; i <= getResponse.Items.Count; i++)
                {
                    var building = buildingClient.GetBuilding(new GetRequest() { Id = getResponse.Items[i - 1].BuildingId });
                    Console.WriteLine(i + " - Location: " + getResponse.Items[i - 1].Location + "\n\t" +
                        "Building Number: " + building.Building.Number + "\n\t" +
                        "Building Address: " + building.Building.Address + "\n");
                };
            }
            return getResponse;
        }

        public static Rooms? GetAllRooms(GrpcChannel channel)
        {
            var roomClient = new Room.RoomClient(channel);
            var getResponse = roomClient.GetAllRooms(new Google.Protobuf.WellKnownTypes.Empty());
            var floorClient = new Floor.FloorClient(channel);
            var buildingClient = new Building.BuildingClient(channel);

            if (getResponse.Items is null)
            {
                Console.WriteLine("There is none");
                channel.Dispose();
            }
            else
            {
                for (int i = 1; i <= getResponse.Items.Count; i++)
                {
                    var floorOfRoom = floorClient.GetFloor(new GetRequest() { Id = getResponse.Items[i - 1].FloorId });
                    var buildingOfFloor = buildingClient.GetBuilding(new GetRequest() { Id = floorOfRoom.Floor.BuildingId });


                    if (getResponse.Items[i - 1].IsProduction is true)
                    {
                        Console.WriteLine(i + " - Number: " + getResponse.Items[i - 1].Number + "\n\t" +
                        "Description: " + getResponse.Items[i - 1].Description + "\n\t" +
                        "Floor Location: " + floorOfRoom.Floor.Location + "\n\t" +
                        "Building Number: " + buildingOfFloor.Building.Number + "\n\t" +
                        "Building Address: " + buildingOfFloor.Building.Address + "\n\t" +
                        "Type: Production \n");
                    }
                    else
                    {
                        Console.WriteLine(i + " - Number: " + getResponse.Items[i - 1].Number + "\n\t" +
                        "Description: " + getResponse.Items[i - 1].Description + "\n\t" +
                        "Floor Location: " + floorOfRoom.Floor.Location + "\n\t" +
                        "Building Number: " + buildingOfFloor.Building.Number + "\n\t" +
                        "Building Address: " + buildingOfFloor.Building.Address + "\n\t" +
                        "Type: Office \n");
                    }
                }
            }
            return getResponse;
        }

        public static Variables? GetAllVariables(GrpcChannel channel)
        {
            var variableClient = new Variable.VariableClient(channel);
            var buildingClient = new Building.BuildingClient(channel);
            var floorClient = new Floor.FloorClient(channel);
            var roomClient = new Room.RoomClient(channel);

            var getResponse = variableClient.GetAllVariables(new Google.Protobuf.WellKnownTypes.Empty());

            if (getResponse.Items is null)
            {
                Console.WriteLine("There is none");
                channel.Dispose();
            }
            else
            {
                for (int i = 1; i <= getResponse.Items.Count; i++)
                {

                    if (getResponse.Items[i - 1].StructureType == StructureType.Building)
                    {
                        var buildingOfVariable = buildingClient.GetBuilding(new GetRequest() { Id = getResponse.Items[i - 1].LocationId });
                        Console.WriteLine(i + " - Code: " + getResponse.Items[i - 1].Code + "\n\t" +
                        "Name: " + getResponse.Items[i - 1].VariableType.Name + "\n\t" +
                        "Measurement unit: " + getResponse.Items[i - 1].VariableType.MeasurementUnit + "\n\t" +
                        "Location: Building No." + buildingOfVariable.Building.Number.ToString() + "\n");
                    }
                    else if (getResponse.Items[i - 1].StructureType == StructureType.Floor)
                    {
                        var floorOfVariable = floorClient.GetFloor(new GetRequest() { Id = getResponse.Items[i - 1].LocationId });
                        var buildingOfFloor = buildingClient.GetBuilding(new GetRequest() { Id = floorOfVariable.Floor.BuildingId });
                        Console.WriteLine(i + " - Code: " + getResponse.Items[i - 1].Code + "\n\t" +
                        "Name: " + getResponse.Items[i - 1].VariableType.Name + "\n\t" +
                        "Measurement unit: " + getResponse.Items[i - 1].VariableType.MeasurementUnit + "\n\t" +
                        "Location: " + floorOfVariable.Floor.Location + " of Building No." + buildingOfFloor.Building.Number.ToString() + "\n");
                    }
                    else
                    {
                        var roomOfVariable = roomClient.GetRoom(new GetRequest() { Id = getResponse.Items[i - 1].LocationId });
                        var floorOfRoom = floorClient.GetFloor(new GetRequest() { Id = roomOfVariable.Room.FloorId });
                        var buildingOfFloor = buildingClient.GetBuilding(new GetRequest() { Id = floorOfRoom.Floor.BuildingId });
                        Console.WriteLine(i + " - Code: " + getResponse.Items[i - 1].Code + "\n\t" +
                        "Name: " + getResponse.Items[i - 1].VariableType.Name + "\n\t" +
                        "Measurement unit: " + getResponse.Items[i - 1].VariableType.MeasurementUnit + "\n\t" +
                        "Location: Room No." + roomOfVariable.Room.Number.ToString() + " of " + floorOfRoom.Floor.Location +
                        " of Building No." + buildingOfFloor.Building.Number.ToString() + "\n");
                    }
                };
            }
            return getResponse;
        }

        public static SampleInts? GetAllSampleInts(GrpcChannel channel)
        {
            var variableClient = new Variable.VariableClient(channel);
            var sampleClient = new SampleInt.SampleIntClient(channel);
            var getResponse = sampleClient.GetAllSampleInts(new Google.Protobuf.WellKnownTypes.Empty());

            if (getResponse.Items is null)
            {
                Console.WriteLine("There is none");
                channel.Dispose();
            }
            else
            {
                for (int i = 1; i <= getResponse.Items.Count; i++)
                {
                    var variable = variableClient.GetVariable(new GetRequest() { Id = getResponse.Items[i - 1].VariableId });

                    if (variable.Variable != null)
                        Console.WriteLine(i + " - Variable Code: " + variable.Variable.Code + "\n\t" +
                            "Date&Time: " + ParseDateTimeExactToSimple(getResponse.Items[i - 1].DateTime) + "\n\t" +
                            "Value: " + getResponse.Items[i - 1].Value.ToString() + "\n");
                    else
                        Console.WriteLine(i + " - Variable Code: ERASED VARIABLE\n\t" +
                            "Date&Time: " + ParseDateTimeExactToSimple(getResponse.Items[i - 1].DateTime) + "\n\t" +
                            "Value: " + getResponse.Items[i - 1].Value.ToString() + "\n");
                };
            }
            return getResponse;
        }

        public static SampleDoubles? GetAllSampleDoubles(GrpcChannel channel)
        {
            var variableClient = new Variable.VariableClient(channel);
            var sampleClient = new SampleDouble.SampleDoubleClient(channel);
            var getResponse = sampleClient.GetAllSampleDoubles(new Google.Protobuf.WellKnownTypes.Empty());

            if (getResponse.Items is null)
            {
                Console.WriteLine("There is none");
                channel.Dispose();
            }
            else
            {
                for (int i = 1; i <= getResponse.Items.Count; i++)
                {
                    var variable = variableClient.GetVariable(new GetRequest() { Id = getResponse.Items[i - 1].VariableId });

                    Console.WriteLine(i + " - Variable Code: " + variable.Variable.Code + "\n\t" +
                        "Date&Time: " + ParseDateTimeExactToSimple(getResponse.Items[i - 1].DateTime) + "\n\t" +
                        "Value: " + getResponse.Items[i - 1].Value.ToString() + "\n");
                };
            }
            return getResponse;
        }

        public static SampleBools? GetAllSampleBools(GrpcChannel channel)
        {
            var variableClient = new Variable.VariableClient(channel);
            var sampleClient = new SampleBool.SampleBoolClient(channel);
            var getResponse = sampleClient.GetAllSampleBools(new Google.Protobuf.WellKnownTypes.Empty());

            if (getResponse.Items is null)
            {
                Console.WriteLine("There is none");
                channel.Dispose();
            }
            else
            {
                for (int i = 1; i <= getResponse.Items.Count; i++)
                {
                    var variable = variableClient.GetVariable(new GetRequest() { Id = getResponse.Items[i - 1].VariableId });

                    Console.WriteLine(i + " - Variable Code: " + variable.Variable.Code + "\n\t" +
                        "Date&Time: " + ParseDateTimeExactToSimple(getResponse.Items[i - 1].DateTime) + "\n\t" +
                        "Value: " + getResponse.Items[i - 1].Value.ToString() + "\n");
                };
            }
            return getResponse;
        }

        public static NullableBuildingDTO GetBuilding(GrpcChannel channel, Buildings allBuildings)
        {
            if (allBuildings.Items.Count == 0)
                return new NullableBuildingDTO() { Null = Google.Protobuf.WellKnownTypes.NullValue.NullValue };

            var buildingClient = new Building.BuildingClient(channel);
            var floorClient = new Floor.FloorClient(channel);
            var variableClient = new Variable.VariableClient(channel);

            int position = 0;
            bool loop = true;
            while (loop)
            {
                Console.Write("\nSelect the Building: ");
                try
                {
                    loop = false;
                    position = Convert.ToInt32(Console.ReadLine()) - 1;
                }
                catch
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
                if (position < 0 || position >= allBuildings.Items.Count)
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
            }


            var getResponse = buildingClient.GetBuilding(new GetRequest() { Id = allBuildings.Items[position].Id });
            Console.WriteLine("\nSELECTED Building No." + getResponse.Building.Number.ToString() + " Address: " + getResponse.Building.Address + "\n");

            var allFloors = floorClient.GetAllFloors(new Google.Protobuf.WellKnownTypes.Empty());
            Console.WriteLine("Floors List: ");
            int i = 1;
            foreach (FloorDTO floor in allFloors.Items)
            {
                if (floor.BuildingId == getResponse.Building.Id)
                {
                    Console.WriteLine(i + " - Location: " + floor.Location + "\n");
                    i++;
                }
            }
            var allVariables = variableClient.GetAllVariables(new Google.Protobuf.WellKnownTypes.Empty());
            i = 1;
            Console.WriteLine("Variables List: ");
            foreach (VariableDTO variable in allVariables.Items)
            {
                if (variable.LocationId == getResponse.Building.Id)
                {
                    Console.WriteLine(i + " - Code: " + variable.Code + "\n\t" +
                        "Name: " + variable.VariableType.Name + "\n\t" +
                        "Measurement unit: " + variable.VariableType.MeasurementUnit + "\n");
                    i++;
                }
            }
            return getResponse;
        }

        public static NullableFloorDTO GetFloor(GrpcChannel channel, Floors allFloors)
        {
            if (allFloors.Items.Count == 0)
                return new NullableFloorDTO() { Null = Google.Protobuf.WellKnownTypes.NullValue.NullValue };

            var roomClient = new Room.RoomClient(channel);
            var floorClient = new Floor.FloorClient(channel);
            var variableClient = new Variable.VariableClient(channel);

            int position = 0;
            bool loop = true;
            while (loop)
            {
                Console.Write("\nSelect the Floor: ");
                try
                {
                    loop = false;
                    position = Convert.ToInt32(Console.ReadLine()) - 1;
                }
                catch
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
                if (position < 0 || position >= allFloors.Items.Count)
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
            }


            var getResponse = floorClient.GetFloor(new GetRequest() { Id = allFloors.Items[position].Id });
            Console.WriteLine("\nSELECTED Floor " + getResponse.Floor.Location + "\n");

            var allRooms = roomClient.GetAllRooms(new Google.Protobuf.WellKnownTypes.Empty());
            Console.WriteLine("Rooms List: ");
            int i = 1;
            foreach (RoomDTO room in allRooms.Items)
            {
                if (room.FloorId == getResponse.Floor.Id)
                {
                    Console.WriteLine(i + " - Number: " + room.Number.ToString() + "\n\t" +
                        "Description: " + room.Description + "\n");
                    i++;
                }
            }
            var allVariables = variableClient.GetAllVariables(new Google.Protobuf.WellKnownTypes.Empty());
            i = 1;
            Console.WriteLine("Variables List: ");
            foreach (VariableDTO variable in allVariables.Items)
            {
                if (variable.LocationId == getResponse.Floor.Id)
                {
                    Console.WriteLine(i + " - Code: " + variable.Code + "\n\t" +
                        "Name: " + variable.VariableType.Name + "\n\t" +
                        "Measurement unit: " + variable.VariableType.MeasurementUnit + "\n");
                    i++;
                }
            }
            return getResponse;
        }

        public static NullableRoomDTO GetRoom(GrpcChannel channel, Rooms allRooms)
        {
            if (allRooms.Items.Count == 0)
                return new NullableRoomDTO() { Null = Google.Protobuf.WellKnownTypes.NullValue.NullValue };

            var roomClient = new Room.RoomClient(channel);
            var variableClient = new Variable.VariableClient(channel);

            int position = 0;
            bool loop = true;
            while (loop)
            {
                Console.Write("\nSelect the Room: ");
                try
                {
                    loop = false;
                    position = Convert.ToInt32(Console.ReadLine()) - 1;
                }
                catch
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
                if (position < 0 || position >= allRooms.Items.Count)
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
            }

            var getResponse = roomClient.GetRoom(new GetRequest() { Id = allRooms.Items[position].Id });
            Console.WriteLine("\nSELECTED Room No." + getResponse.Room.Number.ToString() + " Description: " + getResponse.Room.Description + "\n");


            var allVariables = variableClient.GetAllVariables(new Google.Protobuf.WellKnownTypes.Empty());
            int i = 1;
            Console.WriteLine("Variables List: ");
            foreach (VariableDTO variable in allVariables.Items)
            {
                if (variable.LocationId == getResponse.Room.Id)
                {
                    Console.WriteLine(i + " - Code: " + variable.Code + "\n\t" +
                        "Name: " + variable.VariableType.Name + "\n\t" +
                        "Measurement unit: " + variable.VariableType.MeasurementUnit + "\n");
                    i++;
                }
            }
            return getResponse;
        }

        public static NullableVariableDTO GetVariable(GrpcChannel channel, Variables allVariables)
        {
            if (allVariables.Items.Count == 0)
                return new NullableVariableDTO() { Null = Google.Protobuf.WellKnownTypes.NullValue.NullValue };

            var variableClient = new Variable.VariableClient(channel);
            var sampleIntClient = new SampleInt.SampleIntClient(channel);
            var sampleDoubleClient = new SampleDouble.SampleDoubleClient(channel);
            var sampleBoolClient = new SampleBool.SampleBoolClient(channel);

            int position = 0;
            bool loop = true;
            while (loop)
            {
                Console.Write("\nSelect the Variable: ");
                try
                {
                    loop = false;
                    position = Convert.ToInt32(Console.ReadLine()) - 1;
                }
                catch
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
                if (position < 0 || position >= allVariables.Items.Count)
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
            }

            var getResponse = variableClient.GetVariable(new GetRequest() { Id = allVariables.Items[position].Id });
            Console.WriteLine("\nSELECTED Variable Code: " + getResponse.Variable.Code + " Name: " + getResponse.Variable.VariableType.Name + " MeasurementUnit: " + getResponse.Variable.VariableType.MeasurementUnit + "\n");

            int i = 1;
            Console.WriteLine("Samples List: ");
            var allSampleInts = sampleIntClient.GetAllSampleInts(new Google.Protobuf.WellKnownTypes.Empty());
            foreach (SampleIntDTO sample in allSampleInts.Items)
            {
                if (sample.VariableId == getResponse.Variable.Id)
                {
                    Console.WriteLine(i + " - Date&Time: " + ParseDateTimeExactToSimple(sample.DateTime) + "\t" +
                        "Value: " + sample.Value.ToString() + "\n");
                    i++;
                }
            }
            var allSampleDoubles = sampleDoubleClient.GetAllSampleDoubles(new Google.Protobuf.WellKnownTypes.Empty());
            foreach (SampleDoubleDTO sample in allSampleDoubles.Items)
            {
                if (sample.VariableId == getResponse.Variable.Id)
                {
                    Console.WriteLine(i + " - Date&Time: " + ParseDateTimeExactToSimple(sample.DateTime) + "\t" +
                        "Value: " + sample.Value.ToString() + "\n");
                    i++;
                }
            }
            var allSampleBools = sampleBoolClient.GetAllSampleBools(new Google.Protobuf.WellKnownTypes.Empty());
            foreach (SampleBoolDTO sample in allSampleBools.Items)
            {
                if (sample.VariableId == getResponse.Variable.Id)
                {
                    Console.WriteLine(i + " - Date&Time: " + ParseDateTimeExactToSimple(sample.DateTime) + "\t" +
                        "Value: " + sample.Value.ToString() + "\n");
                    i++;
                }
            }
            return getResponse;
        }

        public static NullableSampleIntDTO GetSampleInt(GrpcChannel channel, SampleInts allSamples)
        {
            if (allSamples.Items.Count == 0)
                return new NullableSampleIntDTO() { Null = Google.Protobuf.WellKnownTypes.NullValue.NullValue };

            var variableClient = new Variable.VariableClient(channel);

            int position = 0;
            bool loop = true;
            while (loop)
            {
                Console.Write("\nSelect the Sample: ");
                try
                {
                    loop = false;
                    position = Convert.ToInt32(Console.ReadLine()) - 1;
                }
                catch
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
                if (position < 0 || position >= allSamples.Items.Count)
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
            }

            var getResponse = allSamples.Items[position];

            VariableDTO variable = variableClient.GetVariable(new GetRequest() { Id = getResponse.VariableId }).Variable;

            Console.WriteLine("\nSELECTED SAMPLE \n" +
            "Variable: " + variable.Code + "\n" +
            "Date & Time: " + getResponse.DateTime + "\n" +
            "Value: " + getResponse.Value.ToString() + "\n");

            return new NullableSampleIntDTO() { SampleInt = getResponse };
        }

        public static NullableSampleDoubleDTO GetSampleDouble(GrpcChannel channel, SampleDoubles allSamples)
        {
            if (allSamples.Items.Count == 0)
                return new NullableSampleDoubleDTO() { Null = Google.Protobuf.WellKnownTypes.NullValue.NullValue };

            var variableClient = new Variable.VariableClient(channel);

            int position = 0;
            bool loop = true;
            while (loop)
            {
                Console.Write("\nSelect the Sample: ");
                try
                {
                    loop = false;
                    position = Convert.ToInt32(Console.ReadLine()) - 1;
                }
                catch
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
                if (position < 0 || position >= allSamples.Items.Count)
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
            }

            var getResponse = allSamples.Items[position];

            VariableDTO variable = variableClient.GetVariable(new GetRequest() { Id = getResponse.VariableId }).Variable;

            Console.WriteLine("\nSELECTED SAMPLE \n" +
            "Variable: " + variable.Code + "\n" +
            "Date & Time: " + getResponse.DateTime + "\n" +
            "Value: " + getResponse.Value.ToString() + "\n");

            return new NullableSampleDoubleDTO() { SampleDouble = getResponse };
        }

        public static NullableSampleBoolDTO GetSampleBool(GrpcChannel channel, SampleBools allSamples)
        {
            if (allSamples.Items.Count == 0)
                return new NullableSampleBoolDTO() { Null = Google.Protobuf.WellKnownTypes.NullValue.NullValue };

            var variableClient = new Variable.VariableClient(channel);

            int position = 0;
            bool loop = true;
            while (loop)
            {
                Console.Write("\nSelect the Sample: ");
                try
                {
                    loop = false;
                    position = Convert.ToInt32(Console.ReadLine()) - 1;
                }
                catch
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
                if (position < 0 || position >= allSamples.Items.Count)
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
            }

            var getResponse = allSamples.Items[position];

            VariableDTO variable = variableClient.GetVariable(new GetRequest() { Id = getResponse.VariableId }).Variable;

            Console.WriteLine("\nSELECTED SAMPLE \n" +
            "Variable: " + variable.Code + "\n" +
            "Date & Time: " + getResponse.DateTime + "\n" +
            "Value: " + getResponse.Value.ToString() + "\n");

            return new NullableSampleBoolDTO() { SampleBool = getResponse };
        }

        public static SampleInts? GetSampleIntByVariableId(GrpcChannel channel)
        {
            var variableClient = new Variable.VariableClient(channel);
            var sampleClient = new SampleInt.SampleIntClient(channel);
            Console.WriteLine("\nSelect the Variable you want to get its samples: ");
            var allVariables = GetAllVariables(channel);

            var getResponse = sampleClient.GetSampleIntByVariableId(new GetRequest() { Id = allVariables.Items[Convert.ToInt32(Console.ReadLine()) - 1].Id });

            if (getResponse.Items is null)
            {
                Console.WriteLine("There is none");
                channel.Dispose();
            }
            else
            {
                for (int i = 1; i <= getResponse.Items.Count; i++)
                {
                    var variable = variableClient.GetVariable(new GetRequest() { Id = getResponse.Items[i - 1].VariableId });

                    Console.WriteLine(i + " - Variable Code: " + variable.Variable.Code + "\n\t" +
                        "Date&Time: " + ParseDateTimeExactToSimple(getResponse.Items[i - 1].DateTime) + "\n\t" +
                        "Value: " + getResponse.Items[i - 1].Value.ToString() + "\n");
                };
            }
            return getResponse;
        }

        public static SampleDoubles? GetSampleDoubleByVariableId(GrpcChannel channel)
        {
            var variableClient = new Variable.VariableClient(channel);
            var sampleClient = new SampleDouble.SampleDoubleClient(channel);
            Console.WriteLine("\nSelect the Variable you want to get its samples: ");
            var allVariables = GetAllVariables(channel);

            var getResponse = sampleClient.GetSampleDoubleByVariableId(new GetRequest() { Id = allVariables.Items[Convert.ToInt32(Console.ReadLine()) - 1].Id });

            if (getResponse.Items is null)
            {
                Console.WriteLine("There is none");
                channel.Dispose();
            }
            else
            {
                for (int i = 1; i <= getResponse.Items.Count; i++)
                {
                    var variable = variableClient.GetVariable(new GetRequest() { Id = getResponse.Items[i - 1].VariableId });

                    Console.WriteLine(i + " - Variable Code: " + variable.Variable.Code + "\n\t" +
                        "Date&Time: " + ParseDateTimeExactToSimple(getResponse.Items[i - 1].DateTime) + "\n\t" +
                        "Value: " + getResponse.Items[i - 1].Value.ToString() + "\n");
                };
            }
            return getResponse;
        }

        public static SampleBools? GetSampleBoolByVariableId(GrpcChannel channel)
        {
            var variableClient = new Variable.VariableClient(channel);
            var sampleClient = new SampleBool.SampleBoolClient(channel);
            Console.WriteLine("\nSelect the Variable you want to get its samples: ");
            var allVariables = GetAllVariables(channel);

            var getResponse = sampleClient.GetSampleBoolByVariableId(new GetRequest() { Id = allVariables.Items[Convert.ToInt32(Console.ReadLine()) - 1].Id });

            if (getResponse.Items is null)
            {
                Console.WriteLine("There is none");
                channel.Dispose();
            }
            else
            {
                for (int i = 1; i <= getResponse.Items.Count; i++)
                {
                    var variable = variableClient.GetVariable(new GetRequest() { Id = getResponse.Items[i - 1].VariableId });

                    Console.WriteLine(i + " - Variable Code: " + variable.Variable.Code + "\n\t" +
                        "Date&Time: " + ParseDateTimeExactToSimple(getResponse.Items[i - 1].DateTime) + "\n\t" +
                        "Value: " + getResponse.Items[i - 1].Value.ToString() + "\n");
                };
            }
            return getResponse;
        }

        public static SampleInts? GetSampleIntByTimeSpan(GrpcChannel channel)
        {
            var variableClient = new Variable.VariableClient(channel);
            var sampleClient = new SampleInt.SampleIntClient(channel);

            Console.Write("INITIAL DATE&TIME\nInsert the day (dd): ");
            string start = Console.ReadLine();
            Console.Write("Insert the month (mm): ");
            start = start + "/" + Console.ReadLine();
            Console.Write("Insert the year (yyyy): ");
            start = start + "/" + Console.ReadLine();
            Console.Write("Insert the hour (hh): ");
            start = start + " " + Console.ReadLine();
            Console.Write("Insert the minutes (mm): ");
            start = start + ":" + Console.ReadLine();
            Console.Write("Insert the seconds (ss): ");
            start = start + ":" + Console.ReadLine();

            try
            {
                DateTime format = System.DateTime.Parse(start);
            }
            catch
            {
                Console.WriteLine("Invalid format");
                return null;
            }

            Console.Write("\nFINAL DATE&TIME\nInsert the day (dd): ");
            string end = Console.ReadLine();
            Console.Write("Insert the month (mm): ");
            end = end + "/" + Console.ReadLine();
            Console.Write("Insert the year (yyyy): ");
            end = end + "/" + Console.ReadLine();
            Console.Write("Insert the hour (hh): ");
            end = end + " " + Console.ReadLine();
            Console.Write("Insert the minutes (mm): ");
            end = end + ":" + Console.ReadLine();
            Console.Write("Insert the seconds (ss): ");
            end = end + ":" + Console.ReadLine();

            try
            {
                DateTime format = System.DateTime.Parse(end);
            }
            catch
            {
                Console.WriteLine("Invalid format");
                return null;
            }

            var getResponse = sampleClient.GetSampleIntByTimeSpan(new GrpcProtos.TimeSpan() { StartTime = ParseDateTimeSimpleToExact(start), EndTime = ParseDateTimeSimpleToExact(end) });

            if (getResponse.Items is null)
            {
                Console.WriteLine("There is none");
                channel.Dispose();
            }
            else
            {
                for (int i = 1; i <= getResponse.Items.Count; i++)
                {
                    var variable = variableClient.GetVariable(new GetRequest() { Id = getResponse.Items[i - 1].VariableId });

                    Console.WriteLine(i + " - Variable Code: " + variable.Variable.Code + "\n\t" +
                        "Date&Time: " + ParseDateTimeExactToSimple(getResponse.Items[i - 1].DateTime) + "\n\t" +
                        "Value: " + getResponse.Items[i - 1].Value.ToString() + "\n");
                };
            }
            return getResponse;
        }

        public static SampleDoubles? GetSampleDoubleByTimeSpan(GrpcChannel channel)
        {
            var variableClient = new Variable.VariableClient(channel);
            var sampleClient = new SampleDouble.SampleDoubleClient(channel);
            Console.Write("INITIAL DATE&TIME\nInsert the day (dd): ");
            string start = Console.ReadLine();
            Console.Write("Insert the month (mm): ");
            start = start + "/" + Console.ReadLine();
            Console.Write("Insert the year (yyyy): ");
            start = start + "/" + Console.ReadLine();
            Console.Write("Insert the hour (hh): ");
            start = start + " " + Console.ReadLine();
            Console.Write("Insert the minutes (mm): ");
            start = start + ":" + Console.ReadLine();
            Console.Write("Insert the seconds (ss): ");
            start = start + ":" + Console.ReadLine();

            try
            {
                DateTime format = System.DateTime.Parse(start);
            }
            catch
            {
                Console.WriteLine("Invalid format");
                return null;
            }

            Console.Write("\nFINAL DATE&TIME\nInsert the day (dd): ");
            string end = Console.ReadLine();
            Console.Write("Insert the month (mm): ");
            end = end + "/" + Console.ReadLine();
            Console.Write("Insert the year (yyyy): ");
            end = end + "/" + Console.ReadLine();
            Console.Write("Insert the hour (hh): ");
            end = end + " " + Console.ReadLine();
            Console.Write("Insert the minutes (mm): ");
            end = end + ":" + Console.ReadLine();
            Console.Write("Insert the seconds (ss): ");
            end = end + ":" + Console.ReadLine();

            try
            {
                DateTime format = System.DateTime.Parse(end);
            }
            catch
            {
                Console.WriteLine("Invalid format");
                return null;
            }

            var getResponse = sampleClient.GetSampleDoubleByTimeSpan(new GrpcProtos.TimeSpan() { StartTime = ParseDateTimeSimpleToExact(start), EndTime = ParseDateTimeSimpleToExact(end) });

            if (getResponse.Items is null)
            {
                Console.WriteLine("There is none");
                channel.Dispose();
            }
            else
            {
                for (int i = 1; i <= getResponse.Items.Count; i++)
                {
                    var variable = variableClient.GetVariable(new GetRequest() { Id = getResponse.Items[i - 1].VariableId });

                    Console.WriteLine(i + " - Variable Code: " + variable.Variable.Code + "\n\t" +
                        "Date&Time: " + ParseDateTimeExactToSimple(getResponse.Items[i - 1].DateTime) + "\n\t" +
                        "Value: " + getResponse.Items[i - 1].Value.ToString() + "\n");
                };
            }
            return getResponse;
        }

        public static SampleBools? GetSampleBoolByTimeSpan(GrpcChannel channel)
        {
            var variableClient = new Variable.VariableClient(channel);
            var sampleClient = new SampleBool.SampleBoolClient(channel);
            Console.Write("INITIAL DATE&TIME\nInsert the day (dd): ");
            string start = Console.ReadLine();
            Console.Write("Insert the month (mm): ");
            start = start + "/" + Console.ReadLine();
            Console.Write("Insert the year (yyyy): ");
            start = start + "/" + Console.ReadLine();
            Console.Write("Insert the hour (hh): ");
            start = start + " " + Console.ReadLine();
            Console.Write("Insert the minutes (mm): ");
            start = start + ":" + Console.ReadLine();
            Console.Write("Insert the seconds (ss): ");
            start = start + ":" + Console.ReadLine();

            try
            {
                DateTime format = System.DateTime.Parse(start);
            }
            catch
            {
                Console.WriteLine("Invalid format");
                return null;
            }

            Console.Write("\nFINAL DATE&TIME\nInsert the day (dd): ");
            string end = Console.ReadLine();
            Console.Write("Insert the month (mm): ");
            end = end + "/" + Console.ReadLine();
            Console.Write("Insert the year (yyyy): ");
            end = end + "/" + Console.ReadLine();
            Console.Write("Insert the hour (hh): ");
            end = end + " " + Console.ReadLine();
            Console.Write("Insert the minutes (mm): ");
            end = end + ":" + Console.ReadLine();
            Console.Write("Insert the seconds (ss): ");
            end = end + ":" + Console.ReadLine();

            try
            {
                DateTime format = System.DateTime.Parse(end);
            }
            catch
            {
                Console.WriteLine("Invalid format");
                return null;
            }

            var getResponse = sampleClient.GetSampleBoolByTimeSpan(new GrpcProtos.TimeSpan() { StartTime = ParseDateTimeSimpleToExact(start), EndTime = ParseDateTimeSimpleToExact(end) });

            if (getResponse.Items is null)
            {
                Console.WriteLine("There is none");
                channel.Dispose();
            }
            else
            {
                for (int i = 1; i <= getResponse.Items.Count; i++)
                {
                    var variable = variableClient.GetVariable(new GetRequest() { Id = getResponse.Items[i - 1].VariableId });

                    Console.WriteLine(i + " - Variable Code: " + variable.Variable.Code + "\n\t" +
                        "Date&Time: " + ParseDateTimeExactToSimple(getResponse.Items[i - 1].DateTime) + "\n\t" +
                        "Value: " + getResponse.Items[i - 1].Value.ToString() + "\n");
                };
            }
            return getResponse;
        }

        public static string ParseDateTimeSimpleToExact(string DateTimeSimple)
        {
            return DateTime.Parse(DateTimeSimple).ToString("yyyy-MM-ddTHH:mm:ss.fffffffK");
        }

        public static string ParseDateTimeExactToSimple(string DateTimeExact)
        {
            return DateTime.ParseExact(DateTimeExact, "yyyy-MM-ddTHH:mm:ss.fffffffK", System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind).ToString();
        }
    }
}











