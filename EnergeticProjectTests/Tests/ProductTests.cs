using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Objects;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Xml.Linq;

namespace EnergeticProjectTestt.Tests
{
    [TestClass]
    public class ProductTests
    {
        private static DbContextOptions<ApplicationContextDB> GetInMemoryOptions()
        {
            return new DbContextOptionsBuilder<ApplicationContextDB>()
                .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
                .Options;
        }

        private readonly ApplicationContextDB db = new(GetInMemoryOptions());

        private static readonly Guid CategoryId = Guid.NewGuid();

        private static Product MakeProduct() => new()
        {
            Article = "A000001",
            Name = "Ноутбук",
            CategoryId = CategoryId,
            PurchasePrice = 50000m,
            SalePrice = 75000m,
            DiscountDate = new DateOnly(2026, 1, 1)
        };

        private User MakeUser(string login) => new()
        {
            Login = login,
            Password = BCryptRealization.PasswordHash("Test1234"),
            Surname = "Тестов",
            Name = "Тест",
            UserRole = UserRole.Administrator,
            CurrencyId = Guid.NewGuid()
        };

        public static bool UserExists(ApplicationContextDB db, string login)
        {
            return db.Users.Any(u => u.Login == login);
        }

        public static bool TryParseDiscountDate(string input, out DateOnly result)
        {
            return DateOnly.TryParse(input, out result);
        }

        [TestMethod]
        public void TryParseDiscountDate_ValidFormat_ReturnsTrue()
        {
            // Arrange & Act
            var result = TryParseDiscountDate("01.01.2026", out _);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryParseDiscountDate_InvalidText_ReturnsFalse()
        {
            // Arrange & Act
            var result = TryParseDiscountDate("абвгд", out _);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParseDiscountDate_EmptyString_ReturnsFalse()
        {
            // Arrange & Act
            var result = TryParseDiscountDate("", out _);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParseDiscountDate_ValidFormat_ParsedDateIsCorrect()
        {
            // Arrange & Act
            TryParseDiscountDate("15.06.2025", out var date);

            // Assert
            Assert.AreEqual(new DateOnly(2025, 6, 15), date);
        }

        [TestMethod]
        public void UserExists_UserInDb_ReturnsTrue()
        {
            // Arrange
            db.Users.Add(MakeUser("admin"));
            db.SaveChanges();

            // Act
            var result = UserExists(db, "admin");

            // Assert
            Debug.Assert(result);
        }

        [TestMethod]
        public void UserExists_UserNotInDb_ReturnsFalse()
        {
            // Arrange

            // Act
            var result = UserExists(db, "ghost");

            // Assert
            Debug.Assert(!result);
        }

        [TestMethod]
        public void UserExists_EmptyLogin_ReturnsFalse()
        {
            // Arrange
            db.Users.Add(MakeUser("admin"));
            db.SaveChanges();

            // Act
            var result = UserExists(db, "");

            // Assert
            Debug.Assert(!result);
        }
    }
}
