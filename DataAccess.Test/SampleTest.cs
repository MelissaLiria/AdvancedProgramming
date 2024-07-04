using Contracts;
using Contracts.Samples;
using Contracts.Variables;
using DataAccess.Contexts;
using DataAccess.Repositories.Samples;
using DataAccess.Repositories.Variables;
using DataAccess.Test.Utilities;
using Domain.Entities.ConfigurationData;
using Domain.Entities.HistoricalData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Test
{
    [TestClass]
    public class SampleTest
    {
        private ISampleRepository _sampleRepository;
        private IVariableRepository _variableRepository;
        private IUnitOfWork _unitOfWork;

        public SampleTest()
        {
            ApplicationContext context =
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _sampleRepository = new SampleRepository(context);
            _variableRepository = new VariableRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [DataRow(0, 15)]
        [TestMethod]
        public void SampleTest01_Can_Add_SampleInt(int variablePos, int value)
        {
            // Arrange
            Variable? variable = _variableRepository.GetAllVariables().ElementAtOrDefault(variablePos);
            Assert.IsNotNull(variable);
            Guid Id = Guid.NewGuid();
            SampleInt sampleInt = new SampleInt(Id, variable, value);

            // Execute
            _sampleRepository.AddSample(sampleInt);
            _unitOfWork.SaveChanges();

            // Assert
            SampleInt? loadedSample = _sampleRepository.GetSampleById<SampleInt>(Id);
            Assert.IsNotNull(loadedSample);
        }

        [DataRow(0, 2.65)]
        [TestMethod]
        public void SampleTest02_Can_Add_SampleDouble(int variablePos, double value)
        {
            // Arrange
            Variable? variable = _variableRepository.GetAllVariables().ElementAtOrDefault(variablePos);
            Assert.IsNotNull(variable);
            Guid Id = Guid.NewGuid();
            SampleDouble sampleDouble = new SampleDouble(Id, variable, value);

            // Execute
            _sampleRepository.AddSample(sampleDouble);
            _unitOfWork.SaveChanges();

            // Assert
            SampleDouble? loadedSample = _sampleRepository.GetSampleById<SampleDouble>(Id);
            Assert.IsNotNull(loadedSample);
        }
        [DataRow(0, true)]
        [TestMethod]
        public void SampleTest03_Can_Add_SampleBool(int variablePos, bool value)
        {
            // Arrange
            Variable? variable = _variableRepository.GetAllVariables().ElementAtOrDefault(variablePos);
            Assert.IsNotNull(variable);
            Guid Id = Guid.NewGuid();
            SampleBool sampleBool = new SampleBool(Id, variable, value);

            // Execute
            _sampleRepository.AddSample(sampleBool);
            _unitOfWork.SaveChanges();

            // Assert
            SampleBool? loadedSample = _sampleRepository.GetSampleById<SampleBool>(Id);
            Assert.IsNotNull(loadedSample);
        }

        [TestMethod]
        public void SampleTest04_Can_Get_All_SampleInt()
        {
            // Arrange

            // Execute
            var sampleInts = _sampleRepository.GetAllSamples<SampleInt>().ToList();

            // Assert
            Assert.IsNotNull(sampleInts);
            Assert.IsTrue(sampleInts.Count > 0);
        }

        [TestMethod]
        public void SampleTest05_Can_Get_All_SampleDouble()
        {
            // Arrange

            // Execute
            var sampleDoubles = _sampleRepository.GetAllSamples<SampleDouble>().ToList();

            // Assert
            Assert.IsNotNull(sampleDoubles);
            Assert.IsTrue(sampleDoubles.Count > 0);
        }

        [TestMethod]
        public void SampleTest06_Can_Get_All_SampleBool()
        {
            // Arrange

            // Execute
            var sampleBools = _sampleRepository.GetAllSamples<SampleBool>().ToList();

            // Assert
            Assert.IsNotNull(sampleBools);
            Assert.IsTrue(sampleBools.Count > 0);
        }

        [DataRow(0)]
        [TestMethod]
        public void SampleTest07_Can_Get_SampleInt_By_Id(int position)
        {
            // Arrange
            var sampleInts = _sampleRepository
                .GetAllSamples<SampleInt>()
                .ToList();

            Assert.IsNotNull(sampleInts);
            Assert.IsTrue(position < sampleInts.Count);
            SampleInt sampleIntToGet = sampleInts[position];

            // Execute
            SampleInt? loadedSampleInt = _sampleRepository
                .GetSampleById<SampleInt>(sampleIntToGet.Id);

            // Assert
            Assert.IsNotNull(loadedSampleInt);
        }

        [DataRow(0)]
        [TestMethod]
        public void SampleTest08_Can_Get_SampleDouble_By_Id(int position)
        {
            // Arrange
            var sampleDoubles = _sampleRepository
                .GetAllSamples<SampleDouble>()
                .ToList();

            Assert.IsNotNull(sampleDoubles);
            Assert.IsTrue(position < sampleDoubles.Count);
            SampleDouble sampleDoubleToGet = sampleDoubles[position];

            // Execute
            SampleDouble? loadedSampleDouble = _sampleRepository
                .GetSampleById<SampleDouble>(sampleDoubleToGet.Id);

            // Assert
            Assert.IsNotNull(loadedSampleDouble);
        }

        [DataRow(0)]
        [TestMethod]
        public void SampleTest09_Can_Get_SampleBool_By_Id(int position)
        {
            // Arrange
            var sampleBools = _sampleRepository
                .GetAllSamples<SampleBool>()
                .ToList();

            Assert.IsNotNull(sampleBools);
            Assert.IsTrue(position < sampleBools.Count);
            SampleBool sampleBoolToGet = sampleBools[position];

            // Execute
            SampleBool? loadedSampleBool = _sampleRepository
                .GetSampleById<SampleBool>(sampleBoolToGet.Id);

            // Assert
            Assert.IsNotNull(loadedSampleBool);
        }

        [TestMethod]
        public void SampleTest10_Cannot_Get_SampleInt_By_Invalid_Id()
        {
            // Arrange

            // Execute
            SampleInt? loadedSampleInt = _sampleRepository
                .GetSampleById<SampleInt>(Guid.Empty);

            // Assert
            Assert.IsNull(loadedSampleInt);
        }

        [TestMethod]
        public void SampleTest11_Cannot_Get_SampleDouble_By_Invalid_Id()
        {
            // Arrange

            // Execute
            SampleDouble? loadedSampleDouble = _sampleRepository
                .GetSampleById<SampleDouble>(Guid.Empty);

            // Assert
            Assert.IsNull(loadedSampleDouble);
        }

        [TestMethod]
        public void SampleTest12_Cannot_Get_SampleBool_By_Invalid_Id()
        {
            // Arrange

            // Execute
            SampleBool? loadedSampleBool = _sampleRepository
                .GetSampleById<SampleBool>(Guid.Empty);

            // Assert
            Assert.IsNull(loadedSampleBool);
        }

        [DataRow(0, 8)]
        [TestMethod]
        public void SampleTest13_Can_Update_SampleInt(int position, int value)
        {
            // Arrange
            var sampleInts = _sampleRepository
                .GetAllSamples<SampleInt>()
                .ToList();

            Assert.IsNotNull(sampleInts);
            Assert.IsTrue(position < sampleInts.Count);
            SampleInt sampleIntToUpdate = sampleInts[position];

            // Execute
            sampleIntToUpdate.Value = value;
            _sampleRepository.UpdateSample(sampleIntToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            SampleInt? loadedSampleInt = _sampleRepository
                .GetSampleById<SampleInt>(sampleIntToUpdate.Id);
            Assert.IsNotNull(loadedSampleInt);
            Assert.AreEqual(loadedSampleInt.Value, value);
        }

        [DataRow(0, 45.12)]
        [TestMethod]
        public void SampleTest14_Can_Update_SampleDouble(int position, double value)
        {
            // Arrange
            var sampleDoubles = _sampleRepository
                .GetAllSamples<SampleDouble>()
                .ToList();

            Assert.IsNotNull(sampleDoubles);
            Assert.IsTrue(position < sampleDoubles.Count);
            SampleDouble sampleDoubleToUpdate = sampleDoubles[position];

            // Execute
            sampleDoubleToUpdate.Value = value;
            _sampleRepository.UpdateSample(sampleDoubleToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            SampleDouble? loadedSampleDouble = _sampleRepository
                .GetSampleById<SampleDouble>(sampleDoubleToUpdate.Id);
            Assert.IsNotNull(loadedSampleDouble);
            Assert.AreEqual(loadedSampleDouble.Value, value);
        }

        [DataRow(0, false)]
        [TestMethod]
        public void SampleTest15_Can_Update_SampleBool(int position, bool value)
        {
            // Arrange
            var sampleBools = _sampleRepository
                .GetAllSamples<SampleBool>()
                .ToList();

            Assert.IsNotNull(sampleBools);
            Assert.IsTrue(position < sampleBools.Count);
            SampleBool sampleBoolToUpdate = sampleBools[position];

            // Execute
            sampleBoolToUpdate.Value = value;
            _sampleRepository.UpdateSample(sampleBoolToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            SampleBool? loadedSampleBool = _sampleRepository
                .GetSampleById<SampleBool>(sampleBoolToUpdate.Id);
            Assert.IsNotNull(loadedSampleBool);
            Assert.AreEqual(loadedSampleBool.Value, value);
        }

        [DataRow(0)]
        [TestMethod]
        public void SampleTest16_Can_Delete_SampleInt(int position)
        {
            // Arrange
            var sampleInts = _sampleRepository
                .GetAllSamples<SampleInt>()
                .ToList();

            Assert.IsNotNull(sampleInts);
            Assert.IsTrue(position < sampleInts.Count);
            SampleInt sampleIntToDelete = sampleInts[position];

            // Execute
            _sampleRepository.DeleteSample(sampleIntToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            SampleInt? loadedSampleInt = _sampleRepository
                .GetSampleById<SampleInt>(sampleIntToDelete.Id);
            Assert.IsNull(loadedSampleInt);
        }

        [DataRow(0)]
        [TestMethod]
        public void SampleTest17_Can_Delete_SampleDouble(int position)
        {
            // Arrange
            var sampleDoubles = _sampleRepository
                .GetAllSamples<SampleDouble>()
                .ToList();

            Assert.IsNotNull(sampleDoubles);
            Assert.IsTrue(position < sampleDoubles.Count);
            SampleDouble sampleDoubleToDelete = sampleDoubles[position];

            // Execute
            _sampleRepository.DeleteSample(sampleDoubleToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            SampleDouble? loadedSampleDouble = _sampleRepository
                .GetSampleById<SampleDouble>(sampleDoubleToDelete.Id);
            Assert.IsNull(loadedSampleDouble);
        }

        [DataRow(0)]
        [TestMethod]
        public void SampleTest18_Can_Delete_SampleBool(int position)
        {
            // Arrange
            var sampleBools = _sampleRepository
                .GetAllSamples<SampleBool>()
                .ToList();

            Assert.IsNotNull(sampleBools);
            Assert.IsTrue(position < sampleBools.Count);
            SampleBool sampleBoolToDelete = sampleBools[position];

            // Execute
            _sampleRepository.DeleteSample(sampleBoolToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            SampleBool? loadedSampleBool = _sampleRepository
                .GetSampleById<SampleBool>(sampleBoolToDelete.Id);
            Assert.IsNull(loadedSampleBool);
        }
    }
}
