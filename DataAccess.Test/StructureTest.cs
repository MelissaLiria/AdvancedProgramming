using Contracts;
using Contracts.Structures;
using DataAccess.Contexts;
using DataAccess.Repositories.Structures;
using DataAccess.Test.Utilities;
using Domain.Entities.ConfigurationData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
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
            Structure? loadedStructure = _structureRepository.GetStructureById<Building>(id);
            Assert.IsNotNull(loadedStructure);
        }

        [DataRow("Lobby")]
        [TestMethod]
        public void StructureTest02_Can_Add_Floor(
            string location)
        {
            //Arrange
            Guid id = Guid.NewGuid();
            var buildings = _structureRepository.GetAllStructures<Building>().ToList();
            Building? building = buildings[0];
            Assert.IsNotNull(building);
            Floor floor = new Floor(id, location, building);

            //Execute
            _structureRepository.AddStructure(floor);
            _unitOfWork.SaveChanges();

            //Assert
            Structure? loadedStructure = _structureRepository.GetStructureById<Floor>(id);
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
            var floors = _structureRepository.GetAllStructures<Floor>().ToList();
            Floor? floor = floors[0];
            Assert.IsNotNull(floor);
            Room room = new Room(id, number, isProduction, description, floor);

            //Execute
            _structureRepository.AddStructure(room);
            _unitOfWork.SaveChanges();

            //Assert
            Structure? loadedStructure = _structureRepository.GetStructureById<Room>(id);
            Assert.IsNotNull(loadedStructure);
        }

        [DataRow(0)]
        [TestMethod]
        public void VariableTest04_Can_Get_Building_By_Id(int position)
        {
            // Arrange
            var buildings = _structureRepository.GetAllStructures<Building>().ToList();
            Assert.IsNotNull(buildings);
            Assert.IsTrue(position < buildings.Count);
            Building buildingToGet = buildings[position];

            // Execute
            Building? loadedBuilding = _structureRepository.GetStructureById<Building>(buildingToGet.Id);

            // Assert
            Assert.IsNotNull(loadedBuilding);
        }

        [DataRow(0)]
        [TestMethod]
        public void VariableTest05_Can_Get_Floor_By_Id(int position)
        {
            // Arrange
            var floors = _structureRepository.GetAllStructures<Floor>().ToList();
            Assert.IsNotNull(floors);
            Assert.IsTrue(position < floors.Count);
            Floor floorToGet = floors[position];

            // Execute
            Floor? loadedFloor = _structureRepository.GetStructureById<Floor>(floorToGet.Id);

            // Assert
            Assert.IsNotNull(loadedFloor);
        }
    }
}
