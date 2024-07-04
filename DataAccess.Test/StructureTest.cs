using Contracts;
using Contracts.Structures;
using DataAccess.Contexts;
using DataAccess.Repositories.Structures;
using DataAccess.Test.Utilities;
using Domain.Entities.ConfigurationData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DataAccess.Test
{
    [TestClass]
    public class StructureTest
    {
        private IStructureRepository _structureRepository;

        private IUnitOfWork _unitOfWork;

        public StructureTest()
        {
            ApplicationContext context =
                new ApplicationContext(ConnectionStringProvider
                .GetConnectionString());
            _structureRepository = new StructureRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [DataRow("Calle 1ra", 23)]
        [TestMethod]
        public void StructureTest01_Can_Add_Building(
            string address,
            int number)
        {
            //Arrange
            Guid id = Guid.NewGuid();
            Building building = new Building(
                id,
                address,
                number);

            //Execute
            _structureRepository.AddStructure(building);
            _unitOfWork.SaveChanges();

            //Assert
            Structure? loadedStructure = _structureRepository
                .GetStructureById<Building>(id);
            Assert.IsNotNull(loadedStructure);
        }

        [DataRow("Lobby")]
        [TestMethod]
        public void StructureTest02_Can_Add_Floor(
            string location)
        {
            //Arrange
            Guid id = Guid.NewGuid();
            var buildings = _structureRepository
                .GetAllStructures<Building>()
                .ToList();

            Building? building = buildings[0];
            Assert.IsNotNull(building);
            Floor floor = new Floor(id, location, building);

            //Execute
            _structureRepository.AddStructure(floor);
            _unitOfWork.SaveChanges();

            //Assert
            Structure? loadedStructure = _structureRepository
                .GetStructureById<Floor>(id);
            Assert.IsNotNull(loadedStructure);
        }

        [DataRow(150, true, "Descripción genérica")]
        [TestMethod]
        public void StructureTest03_Can_Add_Room(
            int number,
            bool isProduction,
            string description)
        {
            //Arrange
            Guid id = Guid.NewGuid();
            var floors = _structureRepository
                .GetAllStructures<Floor>()
                .ToList();

            Floor? floor = floors[0];
            Assert.IsNotNull(floor);
            Room room = new Room(id, number, isProduction, description, floor);

            //Execute
            _structureRepository.AddStructure(room);
            _unitOfWork.SaveChanges();

            //Assert
            Structure? loadedStructure = _structureRepository
                .GetStructureById<Room>(id);
            Assert.IsNotNull(loadedStructure);
        }


        [TestMethod]
        public void StructureTest04_Can_Get_All_Buildings()
        {
            // Arrange

            // Execute
            var buildings = _structureRepository
                .GetAllStructures<Building>()
                .ToList();

            // Assert
            Assert.IsNotNull(buildings);
            Assert.IsTrue(buildings.Count > 0);
        }

        [TestMethod]
        public void StructureTest05_Can_Get_All_Floors()
        {
            // Arrange

            // Execute
            var floors = _structureRepository
                .GetAllStructures<Floor>()
                .ToList();

            // Assert
            Assert.IsNotNull(floors);
            Assert.IsTrue(floors.Count > 0);
        }

        [TestMethod]
        public void StructureTest06_Can_Get_All_Rooms()
        {
            // Arrange

            // Execute
            var rooms = _structureRepository
                .GetAllStructures<Room>()
                .ToList();

            // Assert
            Assert.IsNotNull(rooms);
            Assert.IsTrue(rooms.Count > 0);
        }

        [DataRow(0)]
        [TestMethod]
        public void StructureTest07_Can_Get_Building_By_Id(int position)
        {
            // Arrange
            var buildings = _structureRepository
                .GetAllStructures<Building>()
                .ToList();

            Assert.IsNotNull(buildings);
            Assert.IsTrue(position < buildings.Count);
            Building buildingToGet = buildings[position];

            // Execute
            Building? loadedBuilding = _structureRepository
                .GetStructureById<Building>(buildingToGet.Id);

            // Assert
            Assert.IsNotNull(loadedBuilding);
        }

        [DataRow(0)]
        [TestMethod]
        public void StructureTest08_Can_Get_Floor_By_Id(int position)
        {
            // Arrange
            var floors = _structureRepository
                .GetAllStructures<Floor>()
                .ToList();

            Assert.IsNotNull(floors);
            Assert.IsTrue(position < floors.Count);
            Floor floorToGet = floors[position];

            // Execute
            Floor? loadedFloor = _structureRepository
                .GetStructureById<Floor>(floorToGet.Id);

            // Assert
            Assert.IsNotNull(loadedFloor);
        }

        [DataRow(0)]
        [TestMethod]
        public void StructureTest09_Can_Get_Room_By_Id(int position)
        {
            // Arrange
            var rooms = _structureRepository
                .GetAllStructures<Room>()
                .ToList();

            Assert.IsNotNull(rooms);
            Assert.IsTrue(position < rooms.Count);
            Room roomToGet = rooms[position];

            // Execute
            Room? loadedRoom = _structureRepository
                .GetStructureById<Room>(roomToGet.Id);

            // Assert
            Assert.IsNotNull(loadedRoom);
        }

        [TestMethod]
        public void StructureTest10_Cannot_Get_Building_By_Invalid_Id()
        {
            // Arrange

            // Execute
            Building? loadedBuilding = _structureRepository
                .GetStructureById<Building>(Guid.Empty);

            // Assert
            Assert.IsNull(loadedBuilding);
        }

        [TestMethod]
        public void StructureTest11_Cannot_Get_Floor_By_Invalid_Id()
        {
            // Arrange

            // Execute
            Floor? loadedFloor = _structureRepository
                .GetStructureById<Floor>(Guid.Empty);

            // Assert
            Assert.IsNull(loadedFloor);
        }

        [TestMethod]
        public void StructureTest12_Cannot_Get_Room_By_Invalid_Id()
        {
            // Arrange

            // Execute
            Room? loadedRoom = _structureRepository
                .GetStructureById<Room>(Guid.Empty);

            // Assert
            Assert.IsNull(loadedRoom);
        }

        [DataRow(0, 4)]
        [TestMethod]
        public void StructureTest13_Can_Update_Building(
            int position,
            int number)
        {
            // Arrange
            var buildings = _structureRepository
                .GetAllStructures<Building>()
                .ToList();

            Assert.IsNotNull(buildings);
            Assert.IsTrue(position < buildings.Count);
            Building buildingToUpdate = buildings[position];

            // Execute
            buildingToUpdate.Number = number;
            _structureRepository.UpdateStructure(buildingToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            Building? loadedBuilding = _structureRepository
                .GetStructureById<Building>(buildingToUpdate.Id);
            Assert.IsNotNull(loadedBuilding);
            Assert.AreEqual(loadedBuilding.Number, number);
        }

        [DataRow(0, "Paqueo", "Calle 5ta", 25)]
        [TestMethod]
        public void StructureTest14_Can_Update_Floor(
           int position,
           string location,
           string address,
           int number)
        {
            // Arrange
            var floors = _structureRepository
                .GetAllStructures<Floor>()
                .ToList();

            Assert.IsNotNull(floors);
            Assert.IsTrue(position < floors.Count);
            Floor floorToUpdate = floors[position];
            Building building = new Building(Guid.NewGuid(), address, number);

            // Execute
            floorToUpdate.Location = location;
            floorToUpdate.Building = building;
            _structureRepository.AddStructure(building);
            _structureRepository.UpdateStructure(floorToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            Floor? loadedfloor = _structureRepository
                .GetStructureById<Floor>(floorToUpdate.Id);
            Assert.IsNotNull(loadedfloor);
            Assert.AreEqual(loadedfloor.Location, location);
            Assert.AreEqual(loadedfloor.Building.Address, address);
            Assert.AreEqual(loadedfloor.Building.Number, number);
        }

        [DataRow(0, 506, false)]
        [TestMethod]
        public void StructureTest15_Can_Update_Room(
          int position,
          int number,
          bool isProduction)
        {
            // Arrange
            var rooms = _structureRepository
                .GetAllStructures<Room>()
                .ToList();

            Assert.IsNotNull(rooms);
            Assert.IsTrue(position < rooms.Count);
            Room roomToUpdate = rooms[position];

            // Execute
            roomToUpdate.Number = number;
            roomToUpdate.IsProduction = isProduction;
            _structureRepository.UpdateStructure(roomToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            Room? loadedroom = _structureRepository
                .GetStructureById<Room>(roomToUpdate.Id);
            Assert.IsNotNull(loadedroom);
            Assert.AreEqual(loadedroom.Number, number);
            Assert.AreEqual(loadedroom.IsProduction, isProduction);
        }

        [DataRow(0)]
        [TestMethod]
        public void StructureTest16_Can_Delete_Room(int position)
        {
            // Arrange
            var rooms = _structureRepository
                .GetAllStructures<Room>()
                .ToList();

            Assert.IsNotNull(rooms);
            Assert.IsTrue(position < rooms.Count);
            Room roomToDelete = rooms[position];

            // Execute
            _structureRepository.DeleteStructure(roomToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            Room? loadedRoom = _structureRepository
                .GetStructureById<Room>(roomToDelete.Id);
            Assert.IsNull(loadedRoom);
        }

        [DataRow(0)]
        [TestMethod]
        public void StructureTest17_Can_Delete_Floor(int position)
        {
            // Arrange
            var floors = _structureRepository
                .GetAllStructures<Floor>()
                .ToList();

            Assert.IsNotNull(floors);
            Assert.IsTrue(position < floors.Count);
            Floor floorToDelete = floors[position];

            // Execute
            _structureRepository.DeleteStructure(floorToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            Floor? loadedFloor = _structureRepository
                .GetStructureById<Floor>(floorToDelete.Id);
            Assert.IsNull(loadedFloor);
        }


        [DataRow(0)]
        [TestMethod]
        public void StructureTest18_Can_Delete_Building(int position)
        {
            // Arrange
            var buildings = _structureRepository
                .GetAllStructures<Building>()
                .ToList();

            Assert.IsNotNull(buildings);
            Assert.IsTrue(position < buildings.Count);
            Building buildingToDelete = buildings[position];

            // Execute
            _structureRepository.DeleteStructure(buildingToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            Building? loadedBuilding = _structureRepository
                .GetStructureById<Building>(buildingToDelete.Id);
            Assert.IsNull(loadedBuilding);
        }

    }
}
