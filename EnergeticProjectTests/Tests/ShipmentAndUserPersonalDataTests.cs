using EnergeticProjectX.Classes;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EnergeticProjectTestt.Tests
{
    [TestClass]
    public class ShipmentTests
    {
        private static DbContextOptions<ApplicationContextDB> GetInMemoryOptions()
        {
            return new DbContextOptionsBuilder<ApplicationContextDB>()
                .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
                .Options;
        }

        private readonly ApplicationContextDB db = new(GetInMemoryOptions());

        private static List<ShipmentItemRow> MakeItems(string article, int quantity)
        {
            return
            [
                new ShipmentItemRow { Article = article, Quantity = quantity }
            ];
        }

        [TestMethod]
        public void ValidateStockAvailability_NoItemsYet_EnoughStock_ReturnsTrue()
        {
            // Arrange
            var items = new List<ShipmentItemRow>();

            // Act
            var result = ShipmentValidator.ValidateStockAvailability(items, "A000001", 5, 10);

            // Assert
            Debug.Assert(result);
        }

        [TestMethod]
        public void ValidateStockAvailability_RequestExceedsStock_ReturnsFalse()
        {
            // Arrange
            var items = new List<ShipmentItemRow>();

            // Act
            var result = ShipmentValidator.ValidateStockAvailability(items, "A000001", 11, 10);

            // Assert
            Debug.Assert(!result);
        }

        [TestMethod]
        public void ValidateStockAvailability_AlreadyAddedPlusNewExceedsStock_ReturnsFalse()
        {
            // Arrange
            var items = MakeItems("A000001", 8);

            // Act
            var result = ShipmentValidator.ValidateStockAvailability(items, "A000001", 5, 10);

            // Assert
            Debug.Assert(!result);
        }

        [TestMethod]
        public void ValidateStockAvailability_AlreadyAddedPlusNewEqualsStock_ReturnsTrue()
        {
            // Arrange
            var items = MakeItems("A000001", 5);

            // Act
            var result = ShipmentValidator.ValidateStockAvailability(items, "A000001", 5, 10);

            // Assert
            Debug.Assert(result);
        }

        [TestMethod]
        public void ValidateStockAvailability_DifferentArticleDoesNotCount()
        {
            // Arrange
            var items = MakeItems("A000002", 9);

            // Act
            var result = ShipmentValidator.ValidateStockAvailability(items, "A000001", 5, 10);

            // Assert
            Debug.Assert(result);
        }

        [TestMethod]
        public void ValidateStockAvailability_ExactlyZeroStock_ReturnsFalse()
        {
            // Arrange
            var items = new List<ShipmentItemRow>();

            // Act
            var result = ShipmentValidator.ValidateStockAvailability(items, "A000001", 1, 0);

            // Assert
            Debug.Assert(!result);
        }
    }

    [TestClass]
    public class UserPersonalDataTests
    {
        [TestMethod]
        public void IsUserPersonalDataRelevant_ValidName_ReturnsCapitalized()
        {
            // Arrange
            var result = User.IsUserPersonalDataRelevant("иванов");

            // Assert
            Assert.AreEqual("Иванов", result);
        }

        [TestMethod]
        public void IsUserPersonalDataRelevant_AllCaps_ReturnsCapitalized()
        {
            // Arrange
            var result = User.IsUserPersonalDataRelevant("ИВАНОВ");

            // Assert
            Assert.AreEqual("Иванов", result);
        }

        [TestMethod]
        public void IsUserPersonalDataRelevant_ContainsDigit_ReturnsNull()
        {
            // Arrange
            var result = User.IsUserPersonalDataRelevant("Иванов1");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IsUserPersonalDataRelevant_EmptyString_ReturnsNull()
        {
            // Arrange
            var result = User.IsUserPersonalDataRelevant("");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IsUserPersonalDataRelevant_WhitespaceOnly_ReturnsNull()
        {
            // Arrange & Act
            var result = User.IsUserPersonalDataRelevant("   ");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IsUserPersonalDataRelevant_ContainsSpace_ReturnsNull()
        {
            // Arrange
            var result = User.IsUserPersonalDataRelevant("Иван ов");

            // Assert
            Assert.IsNull(result);
        }
    }

    public class ShipmentValidator
    {
        public static bool ValidateStockAvailability(
            List<ShipmentItemRow> existingItems, string article, int requestedQty, int stockQty)
        {
            int alreadyAdded = existingItems
                .Where(i => i.Article == article)
                .Sum(i => i.Quantity);
            return alreadyAdded + requestedQty <= stockQty;
        }
    }
}
