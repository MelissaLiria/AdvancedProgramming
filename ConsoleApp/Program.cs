using Grpc.Net.Client;
using GrpcProtos;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            Console.WriteLine("Presione una tecla para iniciar la conexión\n");
            Console.ReadKey();

            Console.WriteLine("Conectando...\n");
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress("http://localhost:5051", new GrpcChannelOptions { HttpHandler = httpHandler });
            if (channel is null)
            {
                Console.WriteLine("Cannot connect\n");
                channel.Dispose();
                return;
            }
            
            while (loop is true)
            {
                Console.WriteLine("Options: \n" +
                "1 - Create \n" +
                "2 - Update \n" +
                "3 - Delete \n" +
                "4 - Search \n" +
                "5 - Finish conection \n");

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
                                Console.WriteLine("Invalid input");
                                break;
                        }
                        break;

                    case "2":
                        Console.WriteLine("Select the data type: \n" +
                           "1 - Building \n" +
                           "2 - Floor \n" +
                           "3 - Room \n" +
                           "4 - Variable \n" +
                           "5 - Sample \n");

                        switch (Console.ReadLine())
                        {
                            case "1":
                                UpdateBuilding(channel);
                                break;

                            case "2":
                                UpdateFloor(channel);
                                break;

                            case "3":
                                UpdateRoom(channel);
                                break;

                            case "4":
                                UpdateVariable(channel);
                                break;

                            case "5":
                                UpdateSample(channel);
                                break;

                            default:
                                Console.WriteLine("Invalid input");
                                break;
                        }
                        break;

                    case "3":
                        Console.WriteLine("Select the data type: \n" +
                           "1 - Building \n" +
                           "2 - Floor \n" +
                           "3 - Room \n" +
                           "4 - Variable \n" +
                           "5 - Sample \n");

                        switch (Console.ReadLine())
                        {
                            case "1":
                                DeleteBuilding(channel);
                                break;

                            case "2":
                                DeleteFloor(channel);
                                break;

                            case "3":
                                DeleteRoom(channel);
                                break;

                            case "4":
                                DeleteVariable(channel);
                                break;

                            case "5":
                                DeleteSample(channel);
                                break;

                            default:
                                Console.WriteLine("Invalid input");
                                break;
                        }
                        break;

                    case "4":
                        Console.WriteLine("Options: \n" +
                            "1 - Find one \n" +
                            "2 - Get all \n" +
                            "3 - Get range \n");

                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.WriteLine("Select the data type: \n" +
                                     "1 - Building \n" +
                                     "2 - Floor \n" +
                                     "3 - Room \n" +
                                     "4 - Variable \n");

                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        GetBuilding(channel);
                                        break;

                                    case "2":
                                        GetFloor(channel);
                                        break;

                                    case "3":
                                        GetRoom(channel);
                                        break;

                                    case "4":
                                        GetVariable(channel);
                                        break;

                                    default:
                                        Console.WriteLine("Invalid input");
                                        break;
                                }
                                break;

                            case "2":
                                Console.WriteLine("Select the data type: \n" +
                                     "1 - Building \n" +
                                     "2 - Floor \n" +
                                     "3 - Room \n" +
                                     "4 - Variable \n" +
                                     "5 - Sample \n");

                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        GetAllBuildings(channel);
                                        break;

                                    case "2":
                                        GetAllFloors(channel);
                                        break;

                                    case "3":
                                        GetAllRooms(channel);
                                        break;

                                    case "4":
                                        GetAllVariables(channel);
                                        break;

                                    case "5":
                                        GetAllSamples(channel);
                                        break;

                                    default:
                                        Console.WriteLine("Invalid input");
                                        break;
                                }
                                break;

                            case "3":
                                Console.WriteLine("Select the type of search: \n" +
                                     "1 - By Variable \n" +
                                     "2 - By TimeSpan \n");

                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        GetSampleByVariableId(channel);
                                        break;

                                    case "2":
                                        GetSampleByTimeSpan(channel);
                                        break;

                                    default:
                                        Console.WriteLine("Invalid input");
                                        break;

                                }

                                break;

                            default:
                                Console.WriteLine("Invalid input");
                                break;

                        }
                        break;

                    case "5":
                        channel.Dispose();
                        return;

                    default:
                        Console.WriteLine("Invalid action \n");
                        break;
                }
            }
        

        }

        public static void CreateBuilding(GrpcChannel channel)
        {
            var buildingClient = new Building.BuildingClient(channel);
            Console.WriteLine("Insert the following data: \n" +
                           "Address: ");
            var address = Console.ReadLine();
            Console.WriteLine("Number: ");
            var number = Convert.ToInt32(Console.ReadLine());
            var createResponse = buildingClient.CreateBuilding(new GrpcProtos.CreateBuildingRequest()
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
                Console.WriteLine($"Creación exitosa.");
            }
        }

        public static void CreateFloor(GrpcChannel channel)
        {
            var floorClient = new Floor.FloorClient(channel);
            var buildingClient = new Building.BuildingClient(channel);

            Console.WriteLine("Insert the following data: \n" +
                "Location: ");
            var location = Console.ReadLine();

            Console.WriteLine("Select the corresponding building: \n");

            var allBuildings  = GetAllBuildings(channel);
            
            var createResponse = floorClient.CreateFloor(new CreateFloorRequest()
            {
                Location = location,
                Building = allBuildings.Items[Convert.ToInt32(Console.ReadLine()) - 1]
            });


            if (createResponse is null)
            {
                Console.WriteLine("Cannot create floor");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
            }
        }

        public static void CreateRoom(GrpcChannel channel)
        {
            var roomClient = new Room.RoomClient(channel);
            var floorClient = new Floor.FloorClient(channel);

            Console.WriteLine("Insert the following data: \n" +
                "Number: ");
            var roomNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n Description: ");
            var description = Console.ReadLine();

            Console.WriteLine("\n Is a production room or an office ? \n" +
                "1 - Production \n" +
                "2 - Office\n");

            bool isProduction;

            if (Console.Read() == 1)
            {
                isProduction = true;
            }
            else /*if (Console.Read() == 2)*/
            {
                isProduction = false;
            }
            

            Console.WriteLine("Select the corresponding floor: \n");
            var allFloors = GetAllFloors(channel);

            var createResponse = roomClient.CreateRoom(new GrpcProtos.CreateRoomRequest()
            {
                Number = roomNumber,
                Description = description,
                IsProduction = isProduction,
                Floor = allFloors.Items[Convert.ToInt32(Console.ReadLine()) - 1]
            });


            if (createResponse is null)
            {
                Console.WriteLine("Cannot create room");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
            }
        }

        public static void CreateVariable(GrpcChannel channel)
        {
            var variableClient = new Variable.VariableClient(channel);
            var buildingClient = new Building.BuildingClient(channel);
            var floorClient = new Floor.FloorClient(channel);
            var roomClient = new Room.RoomClient(channel);

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

            //Lista de Edificios, pisos o habitaciones para escoger la ubicacion de la variable
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Select the corresponding building: \n");
                    var allBuildings = GetAllBuildings(channel);

                    
                    break;

                case "2":

                    Console.WriteLine("Select the corresponding floor: \n");
                    var allFloors = GetAllFloors(channel);

                    break;

                case "3":

                    Console.WriteLine("Select the corresponding room: \n");
                    var allRooms = GetAllRooms(channel);

                    break;

                default:
                    Console.WriteLine("Invalid action");
                    break;
            }

            var createResponse = variableClient.CreateVariable(new GrpcProtos.CreateVariableRequest()
            {
                Code = code,
                VariableType = new VariableType() { Name = name, MeasurementUnit = measurementUnit },
                //LocationCase
            });

            if (createResponse is null)
            {
                Console.WriteLine("Cannot create variable");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
            }
        }

        public static void CreateSample(GrpcChannel channel)
        {

        }

        public static void UpdateBuilding(GrpcChannel channel)
        {
            var buildingClient = new Building.BuildingClient(channel);

            Console.WriteLine("Select the corresponding building \n");
            var allBuildings = GetAllBuildings(channel);

            var buildingToUpdate = buildingClient.GetBuilding(new GetRequest() { Id = allBuildings.Items[Convert.ToInt32(Console.ReadLine()) - 1].Id });
            Console.WriteLine("What do you want to modify? \n" +
                "Number: " + buildingToUpdate.Building.Number + "\n" +
                "Address: " + buildingToUpdate.Building.Address + "\n" +
                "Write 1 for Number or 2 for Address");

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

                default:
                    Console.WriteLine("Invalid action");
                    break;
            }

            buildingClient.UpdateBuilding(buildingToUpdate.Building);

            var updatedGetResponse = buildingClient.GetBuilding(new GetRequest() { Id = buildingToUpdate.Building.Id });
            if (updatedGetResponse is not null &&
                updatedGetResponse.KindCase == NullableBuildingDTO.KindOneofCase.Building &&
                updatedGetResponse.Building.Number == buildingToUpdate.Building.Number &&
                updatedGetResponse.Building.Address == buildingToUpdate.Building.Address)
            {
                Console.WriteLine($"Modificación exitosa.");
            }
        }

        public static void UpdateFloor(GrpcChannel channel)
        {
            var floorClient = new Floor.FloorClient(channel);

            Console.WriteLine("Select the corresponding floor \n");
            var allFloors = GetAllFloors(channel);

            var floorToUpdate = floorClient.GetFloor(new GetRequest() { Id = allFloors.Items[Convert.ToInt32(Console.ReadLine()) - 1].Id });
            Console.WriteLine("What do you want to modify? \n" +
                "Location: " + floorToUpdate.Floor.Location + "\n" +
                "Building Number: " + floorToUpdate.Floor.Building.Number + "\n" +
                "Building Address: " + floorToUpdate.Floor.Building.Address + "\n" +
                "Write 1 for Location, 2 for Building");

            //Se modifica la locacion del piso o el edifico al que esta asosiado.
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Write the new Location \n");
                    floorToUpdate.Floor.Location = Console.ReadLine();
                    break;

                case "2":
                    Console.WriteLine("Select the corresponding building \n");
                    var allBuildings = GetAllBuildings(channel);
                    floorToUpdate.Floor.Building = allBuildings.Items[Convert.ToInt32(Console.ReadLine()) - 1];
                    break;

                default:
                    Console.WriteLine("Invalid action");
                    break;
            }

            floorClient.UpdateFloor(floorToUpdate.Floor);

            var updatedGetResponse = floorClient.GetFloor(new GetRequest() { Id = floorToUpdate.Floor.Id });
            if (updatedGetResponse is not null &&
                updatedGetResponse.KindCase == NullableFloorDTO.KindOneofCase.Floor &&
                updatedGetResponse.Floor.Location == floorToUpdate.Floor.Location &&
                updatedGetResponse.Floor.Building == floorToUpdate.Floor.Building)
            {
                Console.WriteLine($"Modificación exitosa.");
            }
        }

        public static void UpdateRoom(GrpcChannel channel)
        {
            var roomClient = new Room.RoomClient(channel);
            Console.WriteLine("Select the corresponding room: \n");
            var allRooms = GetAllRooms(channel);

            var roomToUpdate = roomClient.GetRoom(new GetRequest() { Id = allRooms.Items[Convert.ToInt32(Console.ReadLine()) - 1].Id });
            Console.WriteLine("What do you want to modify? \n" +
                "Description: " + roomToUpdate.Room.Description + "\n" +
                "Floor Location: " + roomToUpdate.Room.Floor.Location + "\n" +
                "Building Number: " + roomToUpdate.Room.Floor.Building.Number + "\n" +
                "Building Address: " + roomToUpdate.Room.Floor.Building.Address + "\n");
            if (roomToUpdate.Room.IsProduction is true)
            {
                Console.WriteLine("Type: Production \n");
            }
            else
            {
                Console.WriteLine("Type: Office \n");
            }
            Console.WriteLine("Write 1 for Description, 2 for Floor or 3 for Building");

            //Se modifica la descripcion de la habitacion, 
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Write the new description \n");
                    roomToUpdate.Room.Description = Console.ReadLine();
                    break;

                case "2":
                    Console.WriteLine("Select the corresponding floor \n");
                    var allFloors = GetAllFloors(channel);
                    roomToUpdate.Room.Floor = allFloors.Items[Convert.ToInt32(Console.ReadLine()) - 1];
                    break;

                case "3":
                    Console.WriteLine("Select the corresponding building \n");
                    var allBuildings = GetAllBuildings(channel);
                    roomToUpdate.Room.Floor.Building = allBuildings.Items[Convert.ToInt32(Console.ReadLine()) - 1];
                    break;

                default:
                    Console.WriteLine("Invalid action");
                    break;
            }

            roomClient.UpdateRoom(roomToUpdate.Room);

            var updatedGetResponse = roomClient.GetRoom(new GetRequest() { Id = roomToUpdate.Room.Id });
            if (updatedGetResponse is not null &&
                updatedGetResponse.KindCase == NullableRoomDTO.KindOneofCase.Room &&
                updatedGetResponse.Room.Description == roomToUpdate.Room.Description &&
                updatedGetResponse.Room.Floor == roomToUpdate.Room.Floor &&
                updatedGetResponse.Room.Floor.Building == roomToUpdate.Room.Floor.Building)
            {
                Console.WriteLine($"Modificación exitosa.");
            }

        }

        public static void UpdateVariable(GrpcChannel channel)
        {
            var variableClient = new Variable.VariableClient(channel);
            Console.WriteLine("Select the corresponding variable: \n");
            var allVariables = GetAllVariables(channel);

            var variableToUpdate = variableClient.GetVariable(new GetRequest() { Id = allVariables.Items[Convert.ToInt32(Console.ReadLine()) - 1].Id });
            Console.WriteLine("What do you want to modify? \n" +
                "Code: " + variableToUpdate.Variable.Code + "\n" +
                "Name: " + variableToUpdate.Variable.VariableType.Name + "\n" +
                "Measurement unit: " + variableToUpdate.Variable.VariableType.MeasurementUnit + "\n");
            //Falta mostrar la informacion de la locacion

            Console.WriteLine("Write 1 for Code, 2 for Name, 3 for Measurement unit or 4 for Location");

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
                            var buildingClient = new Building.BuildingClient(channel);
                            var allBuildings = GetAllVariables(channel);

                            var buildingLocation = buildingClient.GetBuilding(new GetRequest() { Id = allBuildings.Items[Convert.ToInt32(Console.ReadLine()) - 1].Id });

                            //Actualizar location igualandolo a buildingLocation?
                            break;

                        case "2":
                            Console.WriteLine("Select the corresponding floor \n");
                            var floorClient = new Floor.FloorClient(channel);
                            var allFloors = GetAllFloors(channel);

                            var floorLocation = floorClient.GetFloor(new GetRequest() { Id = allFloors.Items[Convert.ToInt32(Console.ReadLine()) - 1].Id });
                            //Actualizar location igualandolo a floorLocation
                            break;

                        case "3":
                            Console.WriteLine("Select the corresponding room: \n");
                            var roomClient = new Room.RoomClient(channel);
                            var allRooms = GetAllRooms(channel);
                           
                            var roomLocation = roomClient.GetRoom(new GetRequest() { Id = allRooms.Items[Convert.ToInt32(Console.ReadLine()) - 1].Id });
                            //Actualizar location igualandolo a roomLocation
                            break;
                    }
                    break;

                default:
                    Console.WriteLine("Invalid action");
                    break;
            }

            variableClient.UpdateVariable(variableToUpdate.Variable);

            var updatedGetResponse = variableClient.GetVariable(new GetRequest() { Id = variableToUpdate.Variable.Id });
            if (updatedGetResponse is not null &&
                updatedGetResponse.KindCase == NullableVariableDTO.KindOneofCase.Variable &&
                updatedGetResponse.Variable.Code == variableToUpdate.Variable.Code &&
                updatedGetResponse.Variable.VariableType == variableToUpdate.Variable.VariableType &&
                updatedGetResponse.Variable.LocationCase == variableToUpdate.Variable.LocationCase)
            {
                Console.WriteLine($"Modificación exitosa.");
            }
        }

        public static void UpdateSample(GrpcChannel channel)
        {

        }

        public static void DeleteBuilding(GrpcChannel channel)
        {
            var buildingClient = new Building.BuildingClient(channel);
            Console.WriteLine("Select the corresponding building \n");
            var allBuildings = GetAllBuildings(channel);

            var buildingToDelete = buildingClient.GetBuilding(new GetRequest() { Id = allBuildings.Items[Convert.ToInt32(Console.ReadLine()) - 1].Id });
            buildingClient.DeleteBuilding(new DeleteRequest() { Id = buildingToDelete.Building.Id });
            var deletedGetResponse = buildingClient.GetBuilding(new GetRequest() { Id = buildingToDelete.Building.Id });
            if (deletedGetResponse is null ||
                deletedGetResponse.KindCase != NullableBuildingDTO.KindOneofCase.Building)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }
        }

        public static void DeleteFloor(GrpcChannel channel)
        {
            var floorClient = new Floor.FloorClient(channel);
            Console.WriteLine("Select the corresponding floor \n");
            var allFloors = GetAllFloors(channel);

            var floorToDelete = floorClient.GetFloor(new GetRequest() { Id = allFloors.Items[Convert.ToInt32(Console.ReadLine()) - 1].Id });
            floorClient.DeleteFloor(new DeleteRequest() { Id = floorToDelete.Floor.Id });
            var deletedGetResponse = floorClient.GetFloor(new GetRequest() { Id = floorToDelete.Floor.Id });
            if (deletedGetResponse is null ||
                deletedGetResponse.KindCase != NullableFloorDTO.KindOneofCase.Floor)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }
        }

        public static void DeleteRoom(GrpcChannel channel)
        {
            var roomClient = new Room.RoomClient(channel);
            Console.WriteLine("Select the corresponding room: \n");
            var allRooms = GetAllRooms(channel);

            var roomToDelete = roomClient.GetRoom(new GetRequest() { Id = allRooms.Items[Convert.ToInt32(Console.ReadLine()) - 1].Id });
            roomClient.DeleteRoom(new DeleteRequest() { Id = roomToDelete.Room.Id });
            var deletedGetResponse = roomClient.GetRoom(new GetRequest() { Id = roomToDelete.Room.Id });
            if (deletedGetResponse is null ||
                deletedGetResponse.KindCase != NullableRoomDTO.KindOneofCase.Room)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }
        }

        public static void DeleteVariable(GrpcChannel channel)
        {
            var variableClient = new Variable.VariableClient(channel);
            Console.WriteLine("Select the corresponding variable: \n");
            var allVariables = GetAllVariables(channel);

            var variableToDelete = variableClient.GetVariable(new GetRequest() { Id = allVariables.Items[Convert.ToInt32(Console.ReadLine()) - 1].Id });
            variableClient.DeleteVariable(new DeleteRequest() { Id = variableToDelete.Variable.Id });
            var deletedGetResponse = variableClient.GetVariable(new GetRequest() { Id = variableToDelete.Variable.Id });
            if (deletedGetResponse is null ||
                deletedGetResponse.KindCase != NullableVariableDTO.KindOneofCase.Variable)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }
        }

        public static void DeleteSample(GrpcChannel channel)
        {

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
                for (int i = 1; i == getResponse.Items.Count; i++)
                {
                    Console.WriteLine(i + " - Number: " + getResponse.Items[i - 1].Number + "\n" +
                        "Address: " + getResponse.Items[i - 1].Address + "\n");
                };              
            }
            return getResponse;
        }

        public static Floors? GetAllFloors(GrpcChannel channel)
        {
            var floorClient = new Floor.FloorClient(channel);
            var getResponse = floorClient.GetAllFloors(new Google.Protobuf.WellKnownTypes.Empty());

            if (getResponse.Items is null)
            {
                Console.WriteLine("There is none");
                channel.Dispose();
            }
            else
            {
                for (int i = 1; i == getResponse.Items.Count; i++)
                {
                    Console.WriteLine(i + " - Location: " + getResponse.Items[i - 1].Location + "\n" +
                        "Building Number: " + getResponse.Items[i - 1].Building.Number + "\n" +
                        "Building Address: " + getResponse.Items[i - 1].Building.Address + "\n");
                };
            }
            return getResponse;
        }

        public static Rooms? GetAllRooms(GrpcChannel channel)
        {
            var roomClient = new Room.RoomClient(channel);
            var getResponse = roomClient.GetAllRooms(new Google.Protobuf.WellKnownTypes.Empty());

            if (getResponse.Items is null)
            {
                Console.WriteLine("There is none");
                channel.Dispose();
            }
            else
            {
                for (int i = 1; i == getResponse.Items.Count; i++)
                {
                    Console.WriteLine(i + " - Number: " + getResponse.Items[i - 1].Number + "\n" +
                        "Description: " + getResponse.Items[i - 1].Description + "\n" +
                        "Floor Location: " + getResponse.Items[i - 1].Floor.Location + "\n" +
                        "Building Number: " + getResponse.Items[i - 1].Floor.Building.Number + "\n" +
                        "Building Address: " + getResponse.Items[i - 1].Floor.Building.Address + "\n");
                    if (getResponse.Items[i - 1].IsProduction is true)
                    {
                        Console.WriteLine("Type: Production \n");
                    }
                    else
                    {
                        Console.WriteLine("Type: Office \n");
                    }
                }
            }
            return getResponse;
        }

        public static Variables? GetAllVariables(GrpcChannel channel)
        {
            var variableClient = new Variable.VariableClient(channel);
            var getResponse = variableClient.GetAllVariables(new Google.Protobuf.WellKnownTypes.Empty());

            if (getResponse.Items is null)
            {
                Console.WriteLine("There is none");
                channel.Dispose();
            }
            else
            {
                for (int i = 1; i == getResponse.Items.Count; i++)
                {
                    Console.WriteLine(i + " - Code: " + getResponse.Items[i - 1].Code + "\n" +
                        "Name: " + getResponse.Items[i - 1].VariableType.Name + "\n" +
                        "Measurement unit: " + getResponse.Items[i - 1].VariableType.MeasurementUnit + "\n");
                    //Falta mostrar la informacion de la locacion
                };
            }
            return getResponse;
        }

        public static void GetAllSamples(GrpcChannel channel)
        {

        }

        public static void GetBuilding(GrpcChannel channel)
        {

        }

        public static void GetFloor(GrpcChannel channel)
        {

        }

        public static void GetRoom(GrpcChannel channel)
        {

        }

        public static void GetVariable(GrpcChannel channel)
        {

        }

        public static void GetSampleByVariableId(GrpcChannel channel)
        {

        }

        public static void GetSampleByTimeSpan(GrpcChannel channel)
        {

        }
    }


}











        