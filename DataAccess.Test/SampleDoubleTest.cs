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
    public class SampledoubleTests
    {
        private List<Sampledouble> sampledoubles;

        [TestInitialize]
        public void Setup()
        {
            sampledoubles = new List<Sampledouble>();
        }

        [TestMethod]
        public void AddSampledouble_ShouldAddSampledouble()
        {
            // Arrange
            var id = Guid.NewGuid();
            var variable = new Variable(); // Asume que tienes un constructor por defecto para Variable
            var sampledouble = new Sampledouble(id, variable, true);

            // Act
            sampledoubles.Add(sampledouble);

            // Assert
            Assert.IsTrue(sampledoubles.Contains(sampledouble));
        }

        [TestMethod]
        public void GetSampledouble_ShouldReturnSampledouble()
        {
            // Arrange
            var id = Guid.NewGuid();
            var variable = new Variable();
            var sampledouble = new Sampledouble(id, variable, true);
            sampledoubles.Add(sampledouble);

            // Act
            var result = sampledoubles.Find(s => s.Id == id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(sampledouble, result);
        }

        [TestMethod]
        public void DeleteSampledouble_ShouldRemoveSampledouble()
        {
            // Arrange
            var id = Guid.NewGuid();
            var variable = new Variable();
            var sampledouble = new Sampledouble(id, variable, true);
            sampledoubles.Add(sampledouble);

            // Act
            sampledoubles.Remove(sampledouble);

            // Assert
            Assert.IsFalse(sampledoubles.Contains(sampledouble));
        }

        [TestMethod]
        public void UpdateSampledouble_ShouldUpdateSampledouble()
        {
            // Arrange
            var id = Guid.NewGuid();
            var variable = new Variable();
            var sampledouble = new Sampledouble(id, variable, true);
            sampledoubles.Add(sampledouble);

            // Act
            var updatedSampledouble = sampledoubles.Find(s => s.Id == id);
            if (updatedSampledouble != null)
            {
                updatedSampledouble.Value = false;
            }

            // Assert
            Assert.IsNotNull(updatedSampledouble);
            Assert.AreEqual(false, updatedSampledouble.Value);
        }
    }
}