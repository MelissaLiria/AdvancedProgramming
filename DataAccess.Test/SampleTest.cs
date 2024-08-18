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
            SampleInt sampleInt = new SampleInt(variable.Id, value);
            
            // Execute
            _sampleRepository.AddSample(sampleInt);
            _unitOfWork.SaveChanges();

            // Assert
            var samples = _sampleRepository.GetSamplesByVariableId<SampleInt>(sampleInt.VariableId).ToList();
            SampleInt? loadedSample = samples.FirstOrDefault(x => x.DateTime == sampleInt.DateTime);
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
            SampleDouble sampleDouble = new SampleDouble(variable.Id, value);

            // Execute
            _sampleRepository.AddSample(sampleDouble);
            _unitOfWork.SaveChanges();

            // Assert
            var samples = _sampleRepository.GetSamplesByVariableId<SampleDouble>(sampleDouble.VariableId).ToList();
            SampleDouble? loadedSample = samples.FirstOrDefault(x => x.DateTime == sampleDouble.DateTime);
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
            SampleBool sampleBool = new SampleBool(variable.Id, value);

            // Execute
            _sampleRepository.AddSample(sampleBool);
            _unitOfWork.SaveChanges();

            // Assert
            var samples = _sampleRepository.GetSamplesByVariableId<SampleBool>(sampleBool.VariableId).ToList();
            SampleBool? loadedSample = samples.FirstOrDefault(x => x.DateTime == sampleBool.DateTime);
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
        public void SampleTest07_Can_Get_SampleInts_By_VariableId(int position)
        {
            // Arrange
            var sampleInts = _sampleRepository
                .GetAllSamples<SampleInt>()
                .ToList();

            Assert.IsNotNull(sampleInts);
            Assert.IsTrue(position < sampleInts.Count);
            SampleInt sampleIntToGet = sampleInts[position];

            // Execute
            var samples = _sampleRepository
                .GetSamplesByVariableId<SampleInt>(sampleIntToGet.VariableId).ToList();

            // Assert
            var loadedsamples = _sampleRepository.GetAllSamples<SampleInt>().Where(x => x.VariableId == sampleIntToGet.VariableId).ToList();
            Assert.AreEqual(samples.Count, loadedsamples.Count);
        }

        [DataRow(0)]
        [TestMethod]
        public void SampleTest08_Can_Get_SampleDoubles_By_VariableId(int position)
        {
            // Arrange
            var sampleDoubles = _sampleRepository
                .GetAllSamples<SampleDouble>()
                .ToList();

            Assert.IsNotNull(sampleDoubles);
            Assert.IsTrue(position < sampleDoubles.Count);
            SampleDouble sampleDoubleToGet = sampleDoubles[position];

            // Execute
            var samples = _sampleRepository
                .GetSamplesByVariableId<SampleDouble>(sampleDoubleToGet.VariableId).ToList();

            // Assert
            var loadedsamples = _sampleRepository.GetAllSamples<SampleDouble>().Where(x => x.VariableId == sampleDoubleToGet.VariableId).ToList();
            Assert.AreEqual(samples.Count, loadedsamples.Count);
        }

        [DataRow(0)]
        [TestMethod]
        public void SampleTest09_Can_Get_SampleBools_By_VariableId(int position)
        {
            // Arrange
            var sampleBools = _sampleRepository
                .GetAllSamples<SampleBool>()
                .ToList();

            Assert.IsNotNull(sampleBools);
            Assert.IsTrue(position < sampleBools.Count);
            SampleBool sampleBoolToGet = sampleBools[position];

            // Execute
            var samples = _sampleRepository
                .GetSamplesByVariableId<SampleBool>(sampleBoolToGet.VariableId).ToList();

            // Assert
            var loadedsamples = _sampleRepository.GetAllSamples<SampleBool>().Where(x => x.VariableId == sampleBoolToGet.VariableId).ToList();
            Assert.AreEqual(samples.Count, loadedsamples.Count);
        }

        [DataRow(0)]
        [TestMethod]
        public void SampleTest10_Can_Get_SampleInt_By_TimeSpan(int position)
        {
            // Arrange
            var sampleInts = _sampleRepository
                .GetAllSamples<SampleInt>()
                .ToList();

            Assert.IsNotNull(sampleInts);
            Assert.IsTrue(position < sampleInts.Count);
            SampleInt sampleIntToGet = sampleInts[position];

            // Execute
            var samples = _sampleRepository
                .GetSamplesByTimeSpan<SampleInt>(sampleIntToGet.DateTime, DateTime.Now).ToList();

            // Assert
            Assert.AreEqual(sampleInts.Count, samples.Count);
        }

        [DataRow(0)]
        [TestMethod]
        public void SampleTest11_Can_Get_SampleDouble_By_TimeSpan(int position)
        {
            // Arrange
            var sampleDoubles = _sampleRepository
                .GetAllSamples<SampleDouble>()
                .ToList();

            Assert.IsNotNull(sampleDoubles);
            Assert.IsTrue(position < sampleDoubles.Count);
            SampleDouble sampleDoubleToGet = sampleDoubles[position];

            // Execute
            var samples = _sampleRepository
                .GetSamplesByTimeSpan<SampleDouble>(sampleDoubleToGet.DateTime, DateTime.Now).ToList();

            // Assert
            Assert.AreEqual(sampleDoubles.Count, samples.Count);
        }

        [DataRow(0)]
        [TestMethod]
        public void SampleTest12_Can_Get_SampleBools_By_TimeSpan(int position)
        {
            // Arrange
            var sampleBools = _sampleRepository
                .GetAllSamples<SampleBool>()
                .ToList();

            Assert.IsNotNull(sampleBools);
            Assert.IsTrue(position < sampleBools.Count);
            SampleBool sampleBoolToGet = sampleBools[position];

            // Execute
            var samples = _sampleRepository
                .GetSamplesByTimeSpan<SampleBool>(sampleBoolToGet.DateTime, DateTime.Now).ToList();

            // Assert
            Assert.AreEqual(sampleBools.Count, samples.Count);
        }

        [TestMethod]
        public void SampleTest13_Cannot_Get_SampleInt_By_Invalid_TimeSpan()
        {
            // Arrange

            // Execute
            var loadedSamples = _sampleRepository
                .GetSamplesByTimeSpan<SampleInt>(DateTime.MaxValue,DateTime.MinValue).ToList();

            // Assert
            Assert.AreEqual(loadedSamples.Count, 0);
        }

        [TestMethod]
        public void SampleTest14_Cannot_Get_SampleDouble_By_Invalid_Id()
        {
            /// Arrange

            // Execute
            var loadedSamples = _sampleRepository
                .GetSamplesByTimeSpan<SampleDouble>(DateTime.MaxValue, DateTime.MinValue).ToList();

            // Assert
            Assert.AreEqual(loadedSamples.Count, 0);
        }

        [TestMethod]
        public void SampleTest15_Cannot_Get_SampleBool_By_Invalid_Id()
        {
            // Arrange

            // Execute
            var loadedSamples = _sampleRepository
                .GetSamplesByTimeSpan<SampleBool>(DateTime.MaxValue, DateTime.MinValue).ToList();

            // Assert
            Assert.AreEqual(loadedSamples.Count, 0);
        }

        [DataRow(0, 8)]
        [TestMethod]
        public void SampleTest16_Can_Update_SampleInt(int position, int value)
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
            var samples = _sampleRepository.GetSamplesByVariableId<SampleInt>(sampleIntToUpdate.VariableId).ToList();
            SampleInt? loadedSample = samples.FirstOrDefault(x => x.DateTime == sampleIntToUpdate.DateTime);
            Assert.IsNotNull(loadedSample);
            Assert.AreEqual(loadedSample.Value, value);
        }

        [DataRow(0, 45.12)]
        [TestMethod]
        public void SampleTest17_Can_Update_SampleDouble(int position, double value)
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
            var samples = _sampleRepository.GetSamplesByVariableId<SampleDouble>(sampleDoubleToUpdate.VariableId).ToList();
            SampleDouble? loadedSample = samples.FirstOrDefault(x => x.DateTime == sampleDoubleToUpdate.DateTime);
            Assert.IsNotNull(loadedSample);
            Assert.AreEqual(loadedSample.Value, value);
        }

        [DataRow(0, false)]
        [TestMethod]
        public void SampleTest18_Can_Update_SampleBool(int position, bool value)
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
            var samples = _sampleRepository.GetSamplesByVariableId<SampleBool>(sampleBoolToUpdate.VariableId).ToList();
            SampleBool? loadedSample = samples.FirstOrDefault(x => x.DateTime == sampleBoolToUpdate.DateTime);
            Assert.IsNotNull(loadedSample);
            Assert.AreEqual(loadedSample.Value, value);
        }

        [DataRow(0)]
        [TestMethod]
        public void SampleTest19_Can_Delete_SampleInt(int position)
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
            var samples = _sampleRepository.GetSamplesByVariableId<SampleInt>(sampleIntToDelete.VariableId).ToList();
            SampleInt? loadedSample = samples.FirstOrDefault(x => x.DateTime == sampleIntToDelete.DateTime);
            Assert.IsNull(loadedSample);
        }

        [DataRow(0)]
        [TestMethod]
        public void SampleTest20_Can_Delete_SampleDouble(int position)
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
            var samples = _sampleRepository.GetSamplesByVariableId<SampleDouble>(sampleDoubleToDelete.VariableId).ToList();
            SampleDouble? loadedSample = samples.FirstOrDefault(x => x.DateTime == sampleDoubleToDelete.DateTime);
            Assert.IsNull(loadedSample);
        }

        [DataRow(0)]
        [TestMethod]
        public void SampleTest21_Can_Delete_SampleBool(int position)
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
            var samples = _sampleRepository.GetSamplesByVariableId<SampleBool>(sampleBoolToDelete.VariableId).ToList();
            SampleBool? loadedSample = samples.FirstOrDefault(x => x.DateTime == sampleBoolToDelete.DateTime);
            Assert.IsNull(loadedSample);
        }
    }
}
