using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Test
{
    [TestClass]
    public class SampleDoubleTests
    {
        [TestMethod]
        public void DefaultConstructor_ShouldInitializeProperties()
        {
            // Arrange
            var sample = new MockSampleDouble();

            // Act & Assert
            Assert.AreNotEqual(Guid.Empty, sample.Id); // Id should be generated
            Assert.AreEqual(default(Guid), sample.VariableId);
            Assert.AreEqual(default(DateTime), sample.DateTime);
            Assert.IsNull(sample.Variable);
            Assert.AreEqual(default(double), sample.Value);
        }

        [TestMethod]
        public void ConstructorWithParameters_ShouldInitializeProperties()
        {
            // Arrange
            var variable = new Variable { Id = Guid.NewGuid() };
            var id = Guid.NewGuid();
            var value = 123.45;
            var sample = new MockSampleDouble(id, variable, value);

            // Act & Assert
            Assert.AreEqual(id, sample.Id);
            Assert.AreEqual(variable.Id, sample.VariableId);
            Assert.AreEqual(variable, sample.Variable);
            Assert.IsTrue((DateTime.Now - sample.DateTime).TotalSeconds < 1); // Allow a margin for DateTime.Now
            Assert.AreEqual(value, sample.Value);
        }
    }
}