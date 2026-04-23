using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Objects;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EnergeticProjectTestt.Tests
{
    [TestClass]
    public class UserTest
    {
        private static DbContextOptions<ApplicationContextDB> GetInMemoryOptions()
        {
            return new DbContextOptionsBuilder<ApplicationContextDB>()
                .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
                .Options;
        }

        private readonly ApplicationContextDB db = new(GetInMemoryOptions());

        [TestMethod]
        public void LegalEntityTrueValidateINN()
        {
            //Arrange
            var iNN = "1461278904";
            var contractorType = Contractors.LegalEntity.GetDescriptionOfEnumValue();

            //Act
            var result = Client.ValidateINN(iNN, contractorType.ToString());

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PhysicalPersonTrueValidateINN()
        {
            //Arrange
            var iNN = "146127890495";
            var contractorType = Contractors.PhysicalPerson.GetDescriptionOfEnumValue();

            //Act
            var result = Client.ValidateINN(iNN, contractorType.ToString());

            //Assert
            Assert.IsTrue(result);
        }
    }
}
