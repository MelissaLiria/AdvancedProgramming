
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
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress("http://localhost:5094", new GrpcChannelOptions { HttpHandler = httpHandler });
            if (channel is null)
            {
                Console.WriteLine("Cannot connect\n");
                channel.Dispose();
                return;
            }

            object? allObjects = null;
            object? Object = null;
            while (loop is true)
            {
                Console.WriteLine("\n" +
                    "___________\n" +
                    "|MAIN MENU|\n" +
                    "¯¯¯¯¯¯¯¯¯¯¯\n" +
                    "Options: \n" +
                "1 - Create \n" +
                "2 - Get \n" +
                "3 - Finish conection \n");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Select the data type: \n" +
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
                                Console.WriteLine("Invalid input\n");
                                break;
                        } //Se crea el objeto 
                        break;

                    case "2":
                        bool cont = true;
                        Console.WriteLine("Select the data type: \n" +
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
                                    Console.WriteLine("Empty List\n");
                                    cont = false;
                                }
                                break;

                            case "2":
                                allObjects = GetAllFloors(channel);
                                var floors = allObjects as Floors;
                                if (floors.Items.Count == 0)
                                {
                                    Console.WriteLine("Empty List\n");
                                    cont = false;
                                }
                                break;

                            case "3":
                                allObjects = GetAllRooms(channel);
                                var rooms = allObjects as Rooms;
                                if (rooms.Items.Count == 0)
                                {
                                    Console.WriteLine("Empty List\n");
                                    cont = false;
                                }
                                break;

                            case "4":
                                allObjects = GetAllVariables(channel);
                                var variables = allObjects as Variables;
                                if (variables.Items.Count == 0)
                                {
                                    Console.WriteLine("Empty List\n");
                                    cont = false;
                                }
                                break;

                            case "5":
                                Console.WriteLine("What kind of sample do you want to get?: \n" +
                                            "1 - Int\n" +
                                            "2 - Double\n" +
                                            "3 - Bool\n");
                                SampleTypeSelection = Console.ReadLine();
                                if (SampleTypeSelection != "1" && SampleTypeSelection != "2" && SampleTypeSelection != "3")
                                {
                                    Console.WriteLine("Invalid Input\n");
                                    cont = false;
                                    break;
                                }


                                Console.WriteLine("Do you want to search by: \n" +
                                    "1 - Variable \n" +
                                    "2 - Timespan \n" +
                                    "3 - Get all \n");

                                switch(Console.ReadLine())
                                {
                                    case "1":
                                         switch(SampleTypeSelection)
                                        {
                                            case "1":
                                                allObjects = GetSampleIntByVariableId(channel);
                                                var sampleInts = allObjects as SampleInts;
                                                if (sampleInts.Items.Count == 0)
                                                {
                                                    Console.WriteLine("Empty List\n");
                                                    cont = false;
                                                }
                                                break;

                                            case "2":
                                                allObjects = GetSampleDoubleByVariableId(channel);
                                                var sampleDoubles = allObjects as SampleDoubles;
                                                if (sampleDoubles.Items.Count == 0)
                                                {
                                                    Console.WriteLine("Empty List\n");
                                                    cont = false;
                                                }
                                                break;

                                            case "3":
                                                allObjects = GetSampleBoolByVariableId(channel);
                                                var sampleBools = allObjects as SampleBools;
                                                if (sampleBools.Items.Count == 0)
                                                {
                                                    Console.WriteLine("Empty List\n");
                                                    cont = false;
                                                }
                                                break;

                                            default:
                                                Console.WriteLine("Invalid input\n");
                                                cont = false;
                                                break;
                                        }//Muestra todos los samples int, double o bool de una variable
                                        break;

                                    case "2":
                                        switch(SampleTypeSelection)
                                        {
                                            case "1":
                                                allObjects = GetSampleIntByTimeSpan(channel);
                                                var sampleInts = allObjects as SampleInts;
                                                if (sampleInts.Items.Count == 0)
                                                {
                                                    Console.WriteLine("Empty List\n");
                                                    cont = false;
                                                }
                                                break;

                                            case "2":
                                                allObjects = GetSampleDoubleByTimeSpan(channel);
                                                var sampleDoubles = allObjects as SampleDoubles;
                                                if (sampleDoubles.Items.Count == 0)
                                                {
                                                    Console.WriteLine("Empty List\n");
                                                    cont = false;
                                                }
                                                break;

                                            case "3":
                                                allObjects = GetSampleBoolByTimeSpan(channel);
                                                var sampleBools = allObjects as SampleBools;
                                                if (sampleBools.Items.Count == 0)
                                                {
                                                    Console.WriteLine("Empty List\n");
                                                    cont = false;
                                                }
                                                break;

                                            default:
                                                Console.WriteLine("Invalid input\n");
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
                                                    Console.WriteLine("Empty List\n");
                                                    cont = false;
                                                }                                                
                                                break;

                                            case "2":
                                                allObjects = GetAllSampleDoubles(channel);
                                                var sampleDoubles = allObjects as SampleDoubles;
                                                if (sampleDoubles.Items.Count == 0)
                                                {
                                                    Console.WriteLine("Empty List\n");
                                                    cont = false;
                                                }
                                                break;                                                

                                            case "3":
                                                allObjects = GetAllSampleBools(channel);
                                                var sampleBools = allObjects as SampleBools;
                                                if (sampleBools.Items.Count == 0)
                                                {
                                                    Console.WriteLine("Empty List\n");
                                                    cont = false;
                                                }
                                                break;

                                            default:
                                                Console.WriteLine("Invalid input\n");
                                                cont = false;
                                                break;
                                        }//Muestra todos los samples int, double o bool
                                        break;

                                    default:
                                        Console.WriteLine("Invalid input\n");
                                        cont = false;
                                        break;
                                }
                                break;

                            default:
                                Console.WriteLine("Invalid input\n");
                                cont = false;
                                break;
                        }// Muestra todos los objetos de un tipo

                        if (cont is true)
                        {
                            bool cont2 = true;
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
                                            }
                                            break;

                                        default:
                                            Console.WriteLine("Invalid input\n");
                                            cont2 = false;
                                            break;
                                    }
                                    break;

                                case "2":
                                    cont2 = false;
                                    break;

                                default:
                                    Console.WriteLine("Invalid input\n");
                                    cont2 = false;
                                    break;
                            }//Muestra la informacion del objeto seleccionado

                            if (cont2 is true)
                            { 
                                Console.WriteLine("Options: \n" +
                                    "1 - Update \n" +
                                    "2 - Delete \n" +
                                    "3 - Return to main menu");

                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        /*switch (DataTypeSelection)
                                        {
                                            case "1":
                                                UpdateBuilding(channel , Object);
                                                break;

                                            case "2":
                                                UpdateFloor(channel, Object);
                                                break;

                                            case "3":
                                                UpdateRoom(channel, Object);
                                                break;

                                            case "4":
                                                UpdateVariable(channel, Object);
                                                break;

                                            case "5":
                                                switch(SampleTypeSelection)
                                                {
                                                    case "1":
                                                        UpdateSampleInt(channel, Object);
                                                        break;

                                                    case "2":
                                                        UpdateSampleDouble(channel, Object);
                                                        break;

                                                    case "3":
                                                        UpdateSampleBool(channel, Object);
                                                        break;

                                                    default:
                                                        Console.WriteLine("Invalid input");
                                                        break;
                                                }
                                                break;

                                            default:
                                                Console.WriteLine("Invalid input\n");
                                                break;
                                        }//Se actualizan los objetos*/
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
                                                    Console.WriteLine("Invalid input\n");
                                                    break;
                                            }
                                            break;

                                        default:
                                            Console.WriteLine("Invalid input\n");
                                            break;
                                    }//Se eliminan los objetos
                                    break;
                                    
                                    case "3":
                                        break;

                                    default:
                                        Console.WriteLine("Invalid input\n");
                                        break;
                                }
                            }
                        }                        
                        break;

                    case "3":
                        channel.Dispose();
                        return;

                    case "4":
                        Console.WriteLine("Invalid action\n");
                        break;
                }
            }
        }
        public static void CreateBuilding(GrpcChannel channel)
        {
            var buildingClient = new Building.BuildingClient(channel);
            Console.Write("Insert the following data: \n" +
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
                Console.WriteLine("Cannot create object");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Succesfully Created\n");
            }
        }

        public static void CreateFloor(GrpcChannel channel)
        {
            var floorClient = new Floor.FloorClient(channel);

            Console.Write("Insert the following data: \n" +
                "Location: ");
            var location = Console.ReadLine();

            Console.WriteLine("\nSelect the corresponding building: \n");

            var allBuildings = GetAllBuildings(channel);
            if (allBuildings.Items.Count == 0)
            {
                Console.WriteLine("No building in the DataBase");
                Console.WriteLine("Cannot create floor");
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
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
                if (position < 0 || position >= allBuildings.Items.Count())
                {
                    Console.WriteLine("Invalid Input\n");
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
                Console.WriteLine("Cannot create floor");
                return;
            }
            else
            {
                Console.WriteLine($"Succesfully Created\n");
            }
        }

        public static void CreateRoom(GrpcChannel channel)
        {
            var roomClient = new Room.RoomClient(channel);
            var buildingClient = new Building.BuildingClient(channel);

            Console.Write("Insert the following data: \n" +
                "Number: ");
            var roomNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("\n Description: ");
            var description = Console.ReadLine();

            Console.Write("\n Is a production room or an office ? \n" +
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
                Console.WriteLine("No floor in the DataBase");
                Console.WriteLine("Cannot create room");
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
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
                if (position < 0 || position >= allFloors.Items.Count())
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
            }

            var buildingOfFloor = buildingClient.GetBuilding(new GetRequest() { Id = allFloors.Items[position].BuildingId });
            var floorOfRoom = allFloors.Items[position];
            floorOfRoom.Building = buildingOfFloor.Building;
            var createResponse = roomClient.CreateRoom(new CreateRoomRequest()
            {
                Number = roomNumber,
                Description = description,
                IsProduction = isProduction,
                Floor = floorOfRoom

            });

            if (createResponse is null)
            {
                Console.WriteLine("Cannot create room");
                return;
            }
            else
            {
                Console.WriteLine($"Succesfully Created\n");
            }
        }

        public static void CreateVariable(GrpcChannel channel)
        {
            var variableClient = new Variable.VariableClient(channel);
            var floorClient = new Floor.FloorClient(channel);
            var buildingClient = new Building.BuildingClient(channel);

            Console.WriteLine("Insert the following data: \n" +
                "Code: ");
            var code = Console.ReadLine();

            Console.WriteLine("\n Name: ");
            var name = Console.ReadLine();

            Console.WriteLine("\n Measurement unit: ");
            var measurementUnit = Console.ReadLine();

            Console.WriteLine("\n Where is located? \n" +
                "1 - Building \n" +
                "2 - Floor \n" +
                "3 - Room \n");

            VariableDTO createResponse = null;

            //Lista de Edificios, pisos o habitaciones para escoger la ubicacion de la variable
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Select the corresponding building: \n");
                    var allBuildings = GetAllBuildings(channel);

                    if (allBuildings.Items.Count == 0)
                    {
                        Console.WriteLine("No building in the DataBase");
                        Console.WriteLine("Cannot create variable");
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
                            Console.WriteLine("Invalid Input\n");
                            loop = true;
                        }
                        if (position < 0 || position >= allBuildings.Items.Count())
                        {
                            Console.WriteLine("Invalid Input\n");
                            loop = true;
                        }
                    }

                    var buildingOfVariable = allBuildings.Items[position];
                    createResponse = variableClient.CreateVariable(new GrpcProtos.CreateVariableRequest()
                    {
                        Code = code,
                        VariableType = new VariableType() { Name = name, MeasurementUnit = measurementUnit },
                        Building = buildingOfVariable
                    });
                    break;

                case "2":

                    Console.WriteLine("Select the corresponding floor: \n");
                    var allFloors = GetAllFloors(channel);
                    if (allFloors.Items.Count == 0)
                    {
                        Console.WriteLine("No floor in the DataBase");
                        Console.WriteLine("Cannot create variable");
                        return;
                    }

                    int position2 = 0;
                    bool loop2 = true;
                    while (loop2)
                    {
                        Console.Write("Select the Floor: ");
                        try
                        {
                            loop = false;
                            position2 = Convert.ToInt32(Console.ReadLine()) - 1;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid Input\n");
                            loop = true;
                        }
                        if (position2 < 0 || position2 >= allFloors.Items.Count())
                        {
                            Console.WriteLine("Invalid Input\n");
                            loop = true;
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

                    Console.WriteLine("Select the corresponding room: \n");
                    var allRooms = GetAllRooms(channel);
                    if (allRooms.Items.Count == 0)
                    {
                        Console.WriteLine("No room in the DataBase");
                        Console.WriteLine("Cannot create variable");
                        return;
                    }

                    int position3 = 0;
                    bool loop3 = true;
                    while (loop3)
                    {
                        Console.Write("Select the Room: ");
                        try
                        {
                            loop = false;
                            position3 = Convert.ToInt32(Console.ReadLine()) - 1;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid Input\n");
                            loop = true;
                        }
                        if (position3 < 0 || position3 >= allRooms.Items.Count())
                        {
                            Console.WriteLine("Invalid Input\n");
                            loop = true;
                        }
                    }


                    var roomOfVariable = allRooms.Items[position3];
                    var floorOfRoom = floorClient.GetFloor(new GetRequest() { Id = roomOfVariable.FloorId });
                    var buildingOfRoom = buildingClient.GetBuilding(new GetRequest() { Id = floorOfRoom.Floor.BuildingId });
                    roomOfVariable.Floor = floorOfRoom.Floor;
                    roomOfVariable.Floor.Building = buildingOfRoom.Building;

                    createResponse = variableClient.CreateVariable(new GrpcProtos.CreateVariableRequest()
                    {
                        Code = code,
                        VariableType = new VariableType() { Name = name, MeasurementUnit = measurementUnit },
                        Room = roomOfVariable
                    });
                    break;

                default:
                    Console.WriteLine("Invalid action");
                    break;
            }

            if (createResponse is null)
            {
                Console.WriteLine("Cannot create variable");
                return;
            }
            else
            {
                Console.WriteLine($"Succesfully Created\n");
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
                Console.WriteLine("No variable in the DataBase");
                Console.WriteLine("Cannot create sample");
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
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
                if (position < 0 || position >= allVariables.Items.Count())
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
            }


            string variableId = allVariables.Items[position].Id;

            Console.WriteLine("Select the Sample DataType: \n" +
                "1 - Int\n" +
                "2 - Double\n" +
                "3 - Boolean\n");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Insert Value: ");
                    var createResponseInt = sampleIntClient.CreateSampleInt(new CreateSampleIntRequest()
                    {
                        VariableId = variableId,
                        Value = Convert.ToInt32(Console.ReadLine())
                    });

                    if (createResponseInt is null)
                    {
                        Console.WriteLine("Cannot create variable");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Succesfully Created\n");
                    }
                    break;

                case "2":
                    Console.WriteLine("Insert Value: ");
                    var createResponseDouble = sampleDoubleClient.CreateSampleDouble(new CreateSampleDoubleRequest()
                    {
                        VariableId = variableId,
                        Value = Convert.ToDouble(Console.ReadLine())
                    });

                    if (createResponseDouble is null)
                    {
                        Console.WriteLine("Cannot create variable");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Succesfully Created\n");
                    }
                    break;

                case "3":
                    Console.WriteLine("Insert Value (true/false): ");
                    var createResponseBool = sampleBoolClient.CreateSampleBool(new CreateSampleBoolRequest()
                    {
                        VariableId = variableId,
                        Value = Convert.ToBoolean(Console.ReadLine())
                    });

                    if (createResponseBool is null)
                    {
                        Console.WriteLine("Cannot create variable");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Succesfully Created\n");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid Input\n");
                    break;
            }
        }

        public static void UpdateBuilding(GrpcChannel channel)
        {
            var buildingClient = new Building.BuildingClient(channel);
            Console.WriteLine("Select the corresponding building \n");
            var allBuildings = GetAllBuildings(channel);
            int position = Convert.ToInt32(Console.ReadLine()) - 1;
            if (position > allBuildings.Items.Count || position < 0)
            {
                Console.WriteLine("Input Out of Range");
                return;
            }
            var buildingToUpdate = buildingClient.GetBuilding(new GetRequest() { Id = allBuildings.Items[position].Id });
            bool loop = true;

            while (loop)
            {
                Console.WriteLine("What do you want to modify? \n" +
                    "Number: " + buildingToUpdate.Building.Number + "\n" +
                    "Address: " + buildingToUpdate.Building.Address + "\n" +
                    "Write 1 for Number or 2 for Address\n" +
                    "Press 3 to save");

                // Se modifica el numero o la direccion.
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Write the new number \n");
                        buildingToUpdate.Building.Number = Convert.ToInt32(Console.ReadLine());
                        break;

                    case "2":
                        Console.WriteLine("Write the new Address \n");
                        buildingToUpdate.Building.Address = Console.ReadLine();
                        break;

                    case "3":
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("Invalid action");
                        break;
                }
            }
            buildingClient.UpdateBuilding(buildingToUpdate.Building);

            var updatedGetResponse = buildingClient.GetBuilding(new GetRequest() { Id = buildingToUpdate.Building.Id });
            if (updatedGetResponse is not null &&
                updatedGetResponse.KindCase == NullableBuildingDTO.KindOneofCase.Building &&
                updatedGetResponse.Building.Number == buildingToUpdate.Building.Number &&
                updatedGetResponse.Building.Address == buildingToUpdate.Building.Address)
            {
                Console.WriteLine($"Succesfully Updated\n");
            }
        }

        public static void UpdateFloor(GrpcChannel channel)
        {
            var floorClient = new Floor.FloorClient(channel);
            var buildingClient = new Building.BuildingClient(channel);

            Console.WriteLine("Select the corresponding floor \n");
            var allFloors = GetAllFloors(channel);
            int position = Convert.ToInt32(Console.ReadLine()) - 1;
            if (position > allFloors.Items.Count - 1 || position < 0)
            {
                Console.WriteLine("Input Out of Range");
                return;
            }
            var floorToUpdate = floorClient.GetFloor(new GetRequest() { Id = allFloors.Items[position].Id });

            bool loop = true;

            while (loop)
            {

                var building = buildingClient.GetBuilding(new GetRequest() { Id = floorToUpdate.Floor.BuildingId });

                Console.WriteLine("What do you want to modify? \n" +
                    "Location: " + floorToUpdate.Floor.Location + "\n" +
                    "Building Number: " + building.Building.Number + "\n" +
                    "Building Address: " + building.Building.Address + "\n" +
                    "Write 1 for Location, 2 for Building\n" +
                    "Press 3 to save");

                //Se modifica la locacion del piso o el edifico al que esta asosiado.
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Write the new Location \n");
                        floorToUpdate.Floor.Location = Console.ReadLine();
                        floorToUpdate.Floor.Building = building.Building;
                        break;

                    case "2":
                        Console.WriteLine("Select the corresponding building \n");
                        var allBuildings = GetAllBuildings(channel);
                        floorToUpdate.Floor.Building = allBuildings.Items[Convert.ToInt32(Console.ReadLine()) - 1];
                        floorToUpdate.Floor.BuildingId = floorToUpdate.Floor.Building.Id;
                        break;

                    case "3":
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("Invalid action");
                        break;
                }
            }

            floorClient.UpdateFloor(floorToUpdate.Floor);

            var updatedGetResponse = floorClient.GetFloor(new GetRequest() { Id = floorToUpdate.Floor.Id });
            if (updatedGetResponse is not null &&
                updatedGetResponse.KindCase == NullableFloorDTO.KindOneofCase.Floor &&
                updatedGetResponse.Floor.Location == floorToUpdate.Floor.Location &&
                updatedGetResponse.Floor.BuildingId == floorToUpdate.Floor.BuildingId)
            {
                Console.WriteLine($"Succesfully Updated\n");
            }
        }

        public static void UpdateRoom(GrpcChannel channel)
        {
            var buildingClient = new Building.BuildingClient(channel);
            var floorClient = new Floor.FloorClient(channel);
            var roomClient = new Room.RoomClient(channel);
            Console.WriteLine("Select the corresponding room: \n");
            var allRooms = GetAllRooms(channel);

            var roomToUpdate = roomClient.GetRoom(new GetRequest() { Id = allRooms.Items[Convert.ToInt32(Console.ReadLine()) - 1].Id });


            bool loop = true;

            while (loop)
            {
                var floorOfRoom = floorClient.GetFloor(new GetRequest() { Id = roomToUpdate.Room.FloorId });
                var buildingOfFloor = buildingClient.GetBuilding(new GetRequest() { Id = floorOfRoom.Floor.BuildingId });

                if (roomToUpdate.Room.IsProduction is true)
                {
                    Console.WriteLine("What do you want to modify? \n" +
                    "Number: " + roomToUpdate.Room.Number + "\n" +
                    "Description: " + roomToUpdate.Room.Description + "\n" +
                    "Floor Location: " + floorOfRoom.Floor.Location + "\n" +
                    "Building Number: " + buildingOfFloor.Building.Number + "\n" +
                    "Building Address: " + buildingOfFloor.Building.Address + "\n" +
                    "Type: Production \n");
                }
                else
                {
                    Console.WriteLine("What do you want to modify? \n" +
                    "Number: " + roomToUpdate.Room.Number + "\n" +
                    "Description: " + roomToUpdate.Room.Description + "\n" +
                    "Floor Location: " + floorOfRoom.Floor.Location + "\n" +
                    "Building Number: " + buildingOfFloor.Building.Number + "\n" +
                    "Building Address: " + buildingOfFloor.Building.Address + "\n" +
                    "Type: Office \n");
                }
                Console.WriteLine("Write 1 for Number, 2 for Description or 3 for Floor\n" +
                    "Press 4 to save");

                //Se modifica la descripcion de la habitacion, 
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Write the new room number \n");
                        roomToUpdate.Room.Number = Convert.ToInt32(Console.ReadLine());
                        break;


                    case "2":
                        Console.WriteLine("Write the new description \n");
                        roomToUpdate.Room.Description = Console.ReadLine();
                        break;

                    case "3":
                        Console.WriteLine("Select the corresponding floor \n");
                        var allFloors = GetAllFloors(channel);
                        roomToUpdate.Room.Floor = allFloors.Items[Convert.ToInt32(Console.ReadLine()) - 1];
                        roomToUpdate.Room.FloorId = roomToUpdate.Room.Floor.Id;
                        break;

                    case "4":
                        roomToUpdate.Room.Floor = floorOfRoom.Floor;
                        roomToUpdate.Room.Floor.Building = buildingOfFloor.Building;
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid action");
                        break;
                }
            }


            roomClient.UpdateRoom(roomToUpdate.Room);

            var updatedGetResponse = roomClient.GetRoom(new GetRequest() { Id = roomToUpdate.Room.Id });
            if (updatedGetResponse is not null &&
                updatedGetResponse.KindCase == NullableRoomDTO.KindOneofCase.Room &&
                updatedGetResponse.Room.Description == roomToUpdate.Room.Description &&
                updatedGetResponse.Room.Floor == roomToUpdate.Room.Floor &&
                updatedGetResponse.Room.Floor.Building == roomToUpdate.Room.Floor.Building)
            {
                Console.WriteLine($"Succesfully Updated\n");
            }

        }

        public static void UpdateVariable(GrpcChannel channel)
        {
            var variableClient = new Variable.VariableClient(channel);
            var buildingClient = new Building.BuildingClient(channel);
            var floorClient = new Floor.FloorClient(channel);
            Console.WriteLine("Select the corresponding variable: \n");
            var allVariables = GetAllVariables(channel);

            var variableToUpdate = variableClient.GetVariable(new GetRequest() { Id = allVariables.Items[Convert.ToInt32(Console.ReadLine()) - 1].Id });

            bool loop = true;

            while (loop)
            {
                Console.WriteLine("What do you want to modify? \n" +
                "Code: " + variableToUpdate.Variable.Code + "\n" +
                "Name: " + variableToUpdate.Variable.VariableType.Name + "\n" +
                "Measurement unit: " + variableToUpdate.Variable.VariableType.MeasurementUnit + "\n");
                if (variableToUpdate.Variable.LocationCase is VariableDTO.LocationOneofCase.Building)
                {
                    Console.WriteLine("Location: Building No." + variableToUpdate.Variable.Building.Number.ToString() + "\n");
                }
                else if (variableToUpdate.Variable.LocationCase is VariableDTO.LocationOneofCase.Floor)
                {
                    Console.WriteLine("Location: " + variableToUpdate.Variable.Floor.Location + " of Building No." + variableToUpdate.Variable.Floor.Building.Number.ToString() + "\n");
                }
                else if (variableToUpdate.Variable.LocationCase is VariableDTO.LocationOneofCase.Room)
                {
                    Console.WriteLine("Location: Room No." + variableToUpdate.Variable.Room.Number.ToString() + " of " + variableToUpdate.Variable.Room.Floor.Location + " of Building No." + variableToUpdate.Variable.Room.Floor.Building.Number.ToString() + "\n");
                }


                Console.WriteLine("Write 1 for Code, 2 for Name, 3 for Measurement unit or 4 for Location\n" +
                    "Press 5 to save\n");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Write the new code \n");
                        variableToUpdate.Variable.Code = Console.ReadLine();
                        break;

                    case "2":
                        Console.WriteLine("Write the new name \n");
                        variableToUpdate.Variable.VariableType.Name = Console.ReadLine();
                        break;

                    case "3":
                        Console.WriteLine("Write the new measuremnt unit \n");
                        variableToUpdate.Variable.VariableType.MeasurementUnit = Console.ReadLine();
                        break;

                    case "4":
                        Console.WriteLine("Select the new location type: \n" +
                            "1 - Building \n" +
                            "2 - Floor \n" +
                            "3 - Room \n");

                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.WriteLine("Select the corresponding building \n");

                                var allBuildings = GetAllBuildings(channel);

                                var buildingLocation = buildingClient.GetBuilding(new GetRequest() { Id = allBuildings.Items[Convert.ToInt32(Console.ReadLine()) - 1].Id });

                                variableToUpdate.Variable.Building = buildingLocation.Building;
                                variableToUpdate.Variable.LocationId = buildingLocation.Building.Id;
                                variableToUpdate.Variable.StructureType = StructureType.Building;
                                break;

                            case "2":
                                Console.WriteLine("Select the corresponding floor \n");
                                var allFloors = GetAllFloors(channel);

                                var floorLocation = floorClient.GetFloor(new GetRequest() { Id = allFloors.Items[Convert.ToInt32(Console.ReadLine()) - 1].Id });
                                var buildingOfFloor = buildingClient.GetBuilding(new GetRequest() { Id = floorLocation.Floor.BuildingId });

                                variableToUpdate.Variable.Floor = floorLocation.Floor;
                                variableToUpdate.Variable.LocationId = floorLocation.Floor.Id;
                                variableToUpdate.Variable.StructureType = StructureType.Floor;
                                variableToUpdate.Variable.Floor.Building = buildingOfFloor.Building;
                                break;

                            case "3":
                                Console.WriteLine("Select the corresponding room: \n");
                                var roomClient = new Room.RoomClient(channel);
                                var allRooms = GetAllRooms(channel);

                                var roomLocation = roomClient.GetRoom(new GetRequest() { Id = allRooms.Items[Convert.ToInt32(Console.ReadLine()) - 1].Id });
                                var floorOfRoom = floorClient.GetFloor(new GetRequest() { Id = roomLocation.Room.FloorId });
                                var buildingOfFloor2 = buildingClient.GetBuilding(new GetRequest() { Id = floorOfRoom.Floor.BuildingId });
                                variableToUpdate.Variable.Room = roomLocation.Room;
                                variableToUpdate.Variable.LocationId = roomLocation.Room.Id;
                                variableToUpdate.Variable.StructureType = StructureType.Room;
                                variableToUpdate.Variable.Floor = floorOfRoom.Floor;
                                variableToUpdate.Variable.Floor.Building = buildingOfFloor2.Building;
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


            variableClient.UpdateVariable(variableToUpdate.Variable);

            var updatedGetResponse = variableClient.GetVariable(new GetRequest() { Id = variableToUpdate.Variable.Id });
            if (updatedGetResponse is not null &&
                updatedGetResponse.KindCase == NullableVariableDTO.KindOneofCase.Variable &&
                updatedGetResponse.Variable.Code == variableToUpdate.Variable.Code &&
                updatedGetResponse.Variable.VariableType == variableToUpdate.Variable.VariableType &&
                updatedGetResponse.Variable.LocationCase == variableToUpdate.Variable.LocationCase)
            {
                Console.WriteLine($"Succesfully Updated\n");
            }
        }

        public static void UpdateSampleInt(GrpcChannel channel)
        {
            var sampleClient = new SampleInt.SampleIntClient(channel);
            var variableClient = new Variable.VariableClient(channel);

            Console.WriteLine("Select the sample you want to modify?: \n");
            var allSamples = GetAllSampleInts(channel);
            SampleIntDTO? sampleToUpdate = allSamples.Items[Convert.ToInt32(Console.ReadLine()) - 1];
            if (sampleToUpdate is null)
            {
                Console.WriteLine("Invalid input");
                return;
            }

            bool loop = true;
            VariableDTO variable = variableClient.GetVariable(new GetRequest() { Id = sampleToUpdate.VariableId }).Variable;
            while (loop)
            {
                Console.WriteLine("Selected Sample \n" +
                "Variable: " + variable.Code + "\n" +
                "Date & Time: " + ParseDateTimeExactToSimple(sampleToUpdate.DateTime) + "\n" +
                "Value: " + sampleToUpdate.Value.ToString() + "\n");

                Console.Write("Insert the new value: ");
                sampleToUpdate.Value = Convert.ToInt32(Console.ReadLine());

                Console.Write("Save this value?(1 = yes / 0 = no): ");
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

        public static void UpdateSampleDouble(GrpcChannel channel)
        {
            var sampleClient = new SampleDouble.SampleDoubleClient(channel);
            var variableClient = new Variable.VariableClient(channel);

            Console.WriteLine("Select the sample you want to modify?: \n");
            var allSamples = GetAllSampleDoubles(channel);
            SampleDoubleDTO? sampleToUpdate = allSamples.Items[Convert.ToInt32(Console.ReadLine()) - 1];
            if (sampleToUpdate is null)
            {
                Console.WriteLine("Invalid input");
                return;
            }

            bool loop = true;
            VariableDTO variable = variableClient.GetVariable(new GetRequest() { Id = sampleToUpdate.VariableId }).Variable;
            while (loop)
            {
                Console.WriteLine("Selected Sample \n" +
                "Variable: " + variable.Code + "\n" +
                "Date & Time: " + ParseDateTimeExactToSimple(sampleToUpdate.DateTime) + "\n" +
                "Value: " + sampleToUpdate.Value.ToString() + "\n");

                Console.Write("Insert the new value: ");
                sampleToUpdate.Value = Convert.ToDouble(Console.ReadLine());

                Console.Write("Save this value?(1 = yes / 0 = no): ");
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

        public static void UpdateSampleBool(GrpcChannel channel)
        {
            var sampleClient = new SampleBool.SampleBoolClient(channel);
            var variableClient = new Variable.VariableClient(channel);

            Console.WriteLine("Select the sample you want to modify?: \n");
            var allSamples = GetAllSampleBools(channel);
            SampleBoolDTO? sampleToUpdate = allSamples.Items[Convert.ToInt32(Console.ReadLine()) - 1];
            if (sampleToUpdate is null)
            {
                Console.WriteLine("Invalid input");
                return;
            }

            bool loop = true;
            VariableDTO variable = variableClient.GetVariable(new GetRequest() { Id = sampleToUpdate.VariableId }).Variable;
            while (loop)
            {
                Console.WriteLine("Selected Sample \n" +
                "Variable: " + variable.Code + "\n" +
                "Date & Time: " + ParseDateTimeExactToSimple(sampleToUpdate.DateTime) + "\n" +
                "Value: " + sampleToUpdate.Value.ToString() + "\n");

                Console.Write("Insert the new value: ");
                sampleToUpdate.Value = Convert.ToBoolean(Console.ReadLine());

                Console.Write("Save this value?(1 = yes / 0 = no): ");
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
                Console.WriteLine($"Succesfully Deleted\n");
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
                Console.WriteLine($"Succesfully Deleted\n");
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
                Console.WriteLine($"Succesfully Deleted\n");
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
                Console.WriteLine($"Succesfully Deleted\n");
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
                Console.WriteLine($"Succesfully Deleted\n");
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
                Console.WriteLine($"Succesfully Deleted\n");
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
                Console.WriteLine($"Succesfully Deleted\n");
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
                        var buildingOfVariable = buildingClient.GetBuilding(new GetRequest() { Id = getResponse.Items[i - 1].LocationId });
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

                    if(variable.Variable != null) 
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
                return new NullableBuildingDTO() { Null = Google.Protobuf.WellKnownTypes.NullValue.NullValue};

            var buildingClient = new Building.BuildingClient(channel);
            var floorClient = new Floor.FloorClient(channel);
            var variableClient = new Variable.VariableClient(channel);

            int position = 0;
            bool loop = true;
            while (loop)
            {
                Console.Write("Select the Building: ");
                try
                {
                    loop = false;
                    position = Convert.ToInt32(Console.ReadLine())-1;
                }
                catch
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
                if(position < 0 || position >= allBuildings.Items.Count())
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
            }
            
            
            var getResponse = buildingClient.GetBuilding(new GetRequest() { Id = allBuildings.Items[position].Id });
            Console.WriteLine("SELECTED Building No." + getResponse.Building.Number.ToString() + " Address: " + getResponse.Building.Address + "\n");

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
                Console.Write("Select the Floor: ");
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
                if (position < 0 || position >= allFloors.Items.Count())
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
            }
            

            var getResponse = floorClient.GetFloor(new GetRequest() { Id = allFloors.Items[position].Id });
            Console.WriteLine("SELECTED Floor " + getResponse.Floor.Location + "\n");

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
                Console.Write("Select the Room: ");
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
                if (position < 0 || position >= allRooms.Items.Count())
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
            }

            var getResponse = roomClient.GetRoom(new GetRequest() { Id = allRooms.Items[position].Id });
            Console.WriteLine("SELECTED Room No." + getResponse.Room.Number.ToString() + " Description: " + getResponse.Room.Description + "\n");


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
                Console.Write("Select the Variable: ");
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
                if (position < 0 || position >= allVariables.Items.Count())
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
            }

            var getResponse = variableClient.GetVariable(new GetRequest() { Id = allVariables.Items[position].Id });
            Console.WriteLine("SELECTED Variable Code: " + getResponse.Variable.Code + " Name: " + getResponse.Variable.VariableType.Name + " MeasurementUnit: " + getResponse.Variable.VariableType.MeasurementUnit + "\n");

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
                Console.Write("Select the Sample: ");
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
                if (position < 0 || position >= allSamples.Items.Count())
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
            }

            var getResponse = allSamples.Items[position];

            VariableDTO variable = variableClient.GetVariable(new GetRequest() { Id = getResponse.VariableId }).Variable;
            
            Console.WriteLine("SELECTED SAMPLE \n" +
            "Variable: " + variable.Code + "\n" +
            "Date & Time: " + getResponse.DateTime + "\n" +
            "Value: " + getResponse.Value.ToString() + "\n");

            return new NullableSampleIntDTO() {SampleInt = getResponse};
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
                Console.Write("Select the Sample: ");
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
                if (position < 0 || position >= allSamples.Items.Count())
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
            }

            var getResponse = allSamples.Items[position];

            VariableDTO variable = variableClient.GetVariable(new GetRequest() { Id = getResponse.VariableId }).Variable;

            Console.WriteLine("SELECTED SAMPLE \n" +
            "Variable: " + variable.Code + "\n" +
            "Date & Time: " + getResponse.DateTime + "\n" +
            "Value: " + getResponse.Value.ToString() + "\n");

            return new NullableSampleDoubleDTO() { SampleDouble = getResponse};
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
                Console.Write("Select the Sample: ");
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
                if (position < 0 || position >= allSamples.Items.Count())
                {
                    Console.WriteLine("Invalid Input\n");
                    loop = true;
                }
            }

            var getResponse = allSamples.Items[position];

            VariableDTO variable = variableClient.GetVariable(new GetRequest() { Id = getResponse.VariableId }).Variable;

            Console.WriteLine("SELECTED SAMPLE \n" +
            "Variable: " + variable.Code + "\n" +
            "Date & Time: " + getResponse.DateTime + "\n" +
            "Value: " + getResponse.Value.ToString() + "\n");

            return new NullableSampleBoolDTO() { SampleBool = getResponse };
        }

        public static SampleInts? GetSampleIntByVariableId(GrpcChannel channel)
        {
            var variableClient = new Variable.VariableClient(channel);
            var sampleClient = new SampleInt.SampleIntClient(channel);
            Console.WriteLine("Select the Variable you want to get its samples: ");
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
            Console.WriteLine("Select the Variable you want to get its samples: ");
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
            Console.WriteLine("Select the Variable you want to get its samples: ");
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











