using EnergeticProjectX;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Objects;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EnergeticProjectTestt.Tests
{
    [TestClass]
    public class Authorization_Tests
    {
        private static DbContextOptions<ApplicationContextDB> GetInMemoryOptions()
        {
            return new DbContextOptionsBuilder<ApplicationContextDB>()
                .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
                .Options;
        }

        private readonly ApplicationContextDB db = new(GetInMemoryOptions());

        static string userLogin = "rpakjj7";

        User user = new User
        {
            Login = userLogin,
            Password = BCryptRealization.PasswordHash("123321dDd"),
            Surname = "Petukhov",
            Name = "Nikitos",
            UserRole = UserRole.Administrator,
            CurrencyId = Guid.NewGuid(),
        };

        [TestMethod]
        public void Authorization_ValidLoginAndPassword_SuccefulAuthorization()
        {

            //Arrange
            db.Add(user);
            db.SaveChanges();

            //Act
            bool result = AuthorizationForm.IsLoginAndPasswordValid("rpakjj7", "123321dDd", db);

            //Assert
            Debug.Assert(result == true);
        }

        [TestMethod]
        public void Authorization_InvalidLogin_ValidPassword_ShouldnotAuthorization()
        {
            //Arrange
            db.Add(user);
            db.SaveChanges();

            //Act
            bool result = AuthorizationForm.IsLoginAndPasswordValid("qwerty", "123321dDd", db);

            //Assert
            Debug.Assert(result == false);
        }

        [TestMethod]
        public void Authorization_ValidLogin_AndInvalidPassword_ShouldnotAuthorization()
        {
            //Arrange
            db.Add(user);
            db.SaveChanges();

            //Act
            bool result = AuthorizationForm.IsLoginAndPasswordValid("rpakjj7", "qwerty", db);

            //Assert
            Debug.Assert(result == false);
        }

        [TestMethod]
        public void Authorization_InvaliddLogin_AndInvalidPassword_ShouldnotAuthorization()
        {
            //Arrange
            db.Add(user);
            db.SaveChanges();

            //Act
            bool result = AuthorizationForm.IsLoginAndPasswordValid("login", "qwerty", db);

            //Assert
            Debug.Assert(result == false);
        }
    }
}