using Contracts;
using Contracts.Variables;
using DataAccess.Contexts;
using DataAccess.Repositories.Variables;
using DataAccess.Test.Utilities;
using Domain.Entities.ConfigurationData;
using Domain.ValueObjects;
using Domain.Entities.HistoricalData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tests
    {
        [TestClass]
        public class SampleTests
        {
            [TestMethod]
            public void DefaultConstructor_ShouldInitializeProperties()
            {
                // Arrange
                var sample = new MockSample();

                // Act & Assert
                Assert.AreNotEqual(Guid.Empty, sample.Id); // Id should be generated
                Assert.AreEqual(default(Guid), sample.VariableId);
                Assert.AreEqual(default(DateTime), sample.DateTime);
                Assert.IsNull(sample.Variable);
            }

            [TestMethod]
            public void ConstructorWithParameters_ShouldInitializeProperties()
            {
                // Arrange
                var variable = new Variable { Id = Guid.NewGuid() };
                var id = Guid.NewGuid();
                var sample = new MockSample(id, variable);

                // Act & Assert
                Assert.AreEqual(id, sample.Id);
                Assert.AreEqual(variable.Id, sample.VariableId);
                Assert.AreEqual(variable, sample.Variable);
                Assert.IsTrue((DateTime.Now - sample.DateTime).TotalSeconds < 1); // Allow a margin for DateTime.Now
            }

            [TestMethod]
            public void Property_SettersAndGetters_ShouldWork()
            {
                // Arrange
                var sample = new MockSample();
                var newVariable = new Variable { Id = Guid.NewGuid() };
                var newDateTime = DateTime.Now;
                var newVariableId = Guid.NewGuid();

                // Act
                sample.Variable = newVariable;
                sample.DateTime = newDateTime;
                sample.VariableId = newVariableId;

                // Assert
                Assert.AreEqual(newVariable, sample.Variable);
                Assert.AreEqual(newDateTime, sample.DateTime);
                Assert.AreEqual(newVariableId, sample.VariableId);
            }
        }

        // Clase MockSample para instanciar Sample, ya que Sample es abstracta
        public class MockSample : Sample
        {
            public MockSample() : base() { }
            public MockSample(Guid id, Variable variable) : base(id, variable) { }
        }

        // Mock de Variable
        public class Variable
        {
            public Guid Id { get; set; }
        }

        // Mock de Entity
        public abstract class Entity
        {
            public Guid Id { get; set; }

            protected Entity()
            {
                Id = Guid.NewGuid();
            }

            protected Entity(Guid id)
            {
                Id = id;
            }
        }
    }