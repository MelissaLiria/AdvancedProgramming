using Contracts;
using Contracts.Variables;
using DataAccess.Contexts;
using DataAccess.Repositories.Variables;
using DataAccess.Test.Utilities;
using Domain.Entities.ConfigurationData;
using Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Test
{
    [TestClass]
    public class VariableTest
    {
        private IVariableRepository _variableRepository;
        private IUnitOfWork _unitOfWork;
    
        public VariableTest()
        {
             ApplicationContext context = new ApplicationContext(ConnectionStringProvider.GetConnectionString());
             _variableRepository = new VariableRepository(context);
             _unitOfWork = new UnitOfWork(context);
        }

        [DataRow("Calle 1", 1, "Temperatura", "ºC", "TP-01")]
        [TestMethod]
        public void VariableTest01_Can_Add_Variable(
            string address,
            int number,
            string variableType_name,
            string variableType_measurementUnit,
            string code)
        {
            // Arrange
            Guid variableId = Guid.NewGuid();
            Variable variable = new Variable(
                variableId, 
                new Building(Guid.NewGuid(), address, number), 
                new VariableType(variableType_name, variableType_measurementUnit), 
                code);

            // Execute
            _variableRepository.AddVariable(variable);
            _unitOfWork.SaveChanges();

            // Assert
            Variable? loadedVariable= _variableRepository.GetVariableById(variableId);
            Assert.IsNotNull(loadedVariable);
        }

        [TestMethod]
        public void VariableTest02_Can_Get_All_Variables()
        {
            // Arrange

            // Execute
            var variables = _variableRepository.GetAllVariables().ToList();

            // Assert
            Assert.IsNotNull(variables);
            Assert.IsTrue(variables.Count > 0);

        }

        [DataRow(0)]
        [TestMethod]
        public void VariableTest03_Can_Get_Variable_By_Id(int position)
        {
            // Arrange
            var variables = _variableRepository.GetAllVariables().ToList();
            Assert.IsNotNull(variables);
            Assert.IsTrue(position < variables.Count);
            Variable variableToGet = variables[position];

            // Execute
            Variable? loadedVariable= _variableRepository.GetVariableById(variableToGet.Id);

            // Assert
            Assert.IsNotNull(loadedVariable);
        }
        
        [TestMethod]
        public void VariableTest04_Cannot_Get_Variable_By_Invalid_Id()
        {
            // Arrange

            // Execute
            Variable? loadedVariable = _variableRepository.GetVariableById(Guid.Empty);

            // Assert
            Assert.IsNull(loadedVariable);
        }

        [DataRow(0)]
        [TestMethod]
        public void VariableTest05_Can_Update_Variable(int position)
        {
            // Arrange
            var variables = _variableRepository.GetAllVariables().ToList();
            Assert.IsNotNull(variables);
            Assert.IsTrue(position < variables.Count);
            string code = variables[position].Code;
            Variable variableToUpdate = variables[position];
            variableToUpdate.Code = code+".";
            Assert.IsTrue(code != variableToUpdate.Code);

            // Execute
            _variableRepository.UpdateVariable(variableToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            Variable? loadedVariable = _variableRepository.GetVariableById(variableToUpdate.Id);
            Assert.IsNotNull(loadedVariable);
            Assert.IsTrue(loadedVariable.Code == variableToUpdate.Code);
        }

        [DataRow(0)]
        [TestMethod]
        public void VariableTest06_Can_Delete_Variable(int position)
        {
            // Arrange
            var variables = _variableRepository.GetAllVariables().ToList();
            Assert.IsNotNull(variables);
            Assert.IsTrue(position < variables.Count);
            Variable variableToDelete = variables[position];

            // Execute
            _variableRepository.DeleteVariable(variableToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            Variable? loadedVariable = _variableRepository.GetVariableById(variableToDelete.Id);
            Assert.IsNull(loadedVariable);
        }

    }
}
