using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Tests.Entities.HistoricalData;
using System.Collections.Generic;
using Domain.Entities.HistoricalData;
using Domain.Entities.ConfigurationData;
using global::Domain.Entities.ConfigurationData;
using global::Domain.Entities.HistoricalData;

namespace DataAccess.Test



{
    [TestClass]
    public class SampleBoolTests
    {
        private List<SampleBool> sampleBools;

        [TestInitialize]
        public void Setup()
        {
            sampleBools = new List<SampleBool>();
        }

        [TestMethod]
        public void AddSampleBool_ShouldAddSampleBool()
        {
            // Arrange
            var id = Guid.NewGuid();
            var variable = new Variable(); // Asume que tienes un constructor por defecto para Variable
            var sampleBool = new SampleBool(id, variable, true);

            // Act
            sampleBools.Add(sampleBool);

            // Assert
            Assert.IsTrue(sampleBools.Contains(sampleBool));
        }

        [TestMethod]
        public void GetSampleBool_ShouldReturnSampleBool()
        {
            // Arrange
            var id = Guid.NewGuid();
            var variable = new Variable();
            var sampleBool = new SampleBool(id, variable, true);
            sampleBools.Add(sampleBool);

            // Act
            var result = sampleBools.Find(s => s.Id == id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(sampleBool, result);
        }

        [TestMethod]
        public void DeleteSampleBool_ShouldRemoveSampleBool()
        {
            // Arrange
            var id = Guid.NewGuid();
            var variable = new Variable();
            var sampleBool = new SampleBool(id, variable, true);
            sampleBools.Add(sampleBool);

            // Act
            sampleBools.Remove(sampleBool);

            // Assert
            Assert.IsFalse(sampleBools.Contains(sampleBool));
        }

        [TestMethod]
        public void UpdateSampleBool_ShouldUpdateSampleBool()
        {
            // Arrange
            var id = Guid.NewGuid();
            var variable = new Variable();
            var sampleBool = new SampleBool(id, variable, true);
            sampleBools.Add(sampleBool);

            // Act
            var updatedSampleBool = sampleBools.Find(s => s.Id == id);
            if (updatedSampleBool != null)
            {
                updatedSampleBool.Value = false;
            }

            // Assert
            Assert.IsNotNull(updatedSampleBool);
            Assert.AreEqual(false, updatedSampleBool.Value);
        }
    }
}
