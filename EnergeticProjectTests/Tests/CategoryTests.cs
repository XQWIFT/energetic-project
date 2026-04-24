using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Objects;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EnergeticProjectTestt.Tests
{
    [TestClass]
    public class CategoryTests
    {
        private static DbContextOptions<ApplicationContextDB> GetInMemoryOptions()
        {
            return new DbContextOptionsBuilder<ApplicationContextDB>()
                .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
                .Options;
        }

        private readonly ApplicationContextDB db = new(GetInMemoryOptions());

        public static bool IsCategoryNameUnique(ApplicationContextDB db, string name)
        {
            return !db.Categories.
                Any(c => c.Status == CategoryStatus.Active && 
                string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase) && c.Name != string.Empty);
        }

        private void AddCategory(string name, CategoryStatus status = CategoryStatus.Active)
        {
            db.Categories.Add(new Category
            {
                Name = name,
                Status = status,
                Unit_Id = Guid.NewGuid()
            });
            db.SaveChanges();
        }

        [TestMethod]
        public void IsCategoryNameUnique_EmptyDb_ReturnsTrue()
        {
            // Arrange

            // Act
            var result = IsCategoryNameUnique(db, "Электроника");

            // Assert
            Debug.Assert(result);
        }

        [TestMethod]
        public void IsCategoryNameUnique_ExactSameActiveName_ReturnsFalse()
        {
            // Arrange
            AddCategory("Электроника");

            // Act
            var result = IsCategoryNameUnique(db, "Электроника");

            // Assert
            Debug.Assert(!result);
        }

        [TestMethod]
        public void IsCategoryNameUnique_SameNameDifferentCase_ReturnsFalse()
        {
            // Arrange
            AddCategory("электроника");

            // Act
            var result = IsCategoryNameUnique(db, "ЭЛЕКТРОНИКА");

            // Assert
            Debug.Assert(!result);
        }

        [TestMethod]
        public void IsCategoryNameUnique_HiddenCategory_ReturnsTrue()
        {
            // Arrange
            AddCategory("Электроника", CategoryStatus.Hidden);

            // Act
            var result = IsCategoryNameUnique(db, "Электроника");

            // Assert
            Debug.Assert(result);
        }

        [TestMethod]
        public void IsCategoryNameUnique_DifferentName_ReturnsTrue()
        {
            // Arrange
            AddCategory("Электроника");

            // Act
            var result = IsCategoryNameUnique(db, "Мебель");

            // Assert
            Debug.Assert(result);
        }
    }
}
