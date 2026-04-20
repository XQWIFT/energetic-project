using EnergeticProjectX;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UserControl;
using EnergeticProjectX.Classes;

namespace AuthorizationTests
{
    [TestClass]
    public class Authorization_Tests
    {
        BCryptRealization bCrypt = new BCryptRealization();
        AuthorizationForm authorizationForm = new AuthorizationForm();

        private DbContextOptions<ApplicationContextDB> GetInMemoryOptions()
        {
            return new DbContextOptionsBuilder<ApplicationContextDB>()
                .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
                .Options;
        }

        [TestMethod]
        public void Authorization_ValidLoginAndPassword_SuccefulAuthorization()
        {

            //Arrange
            ApplicationContextDB db = new(GetInMemoryOptions());

            var user = new User
            {
                UserCode = "47534",
                Login = "rpakjj7",
                Password = bCrypt.PasswordHash("123321dDd"),
                Surname = "Petukhov",
                Name = "Nikitos",
                UserRole = "Admin"
            };
            db.Add(user);
            db.SaveChanges();

            //Act
            bool result = authorizationForm.IsLoginAndPasswordValid("rpakjj7", "123321dDd", db);

            //Assert
            Debug.Assert(result == true);
        }

        [TestMethod]
        public void Authorization_InvalidLogin_ValidPassword_ShouldnotAuthorization()
        {
            //Arrange
            ApplicationContextDB db = new(GetInMemoryOptions());

            var user = new User
            {
                UserCode = "47534",
                Login = "rpakjj7",
                Password = bCrypt.PasswordHash("123321dDd"),
                Surname = "Petukhov",
                Name = "Nikitos",
                UserRole = "Admin"
            };
            db.Add(user);
            db.SaveChanges();

            //Act
            bool result = authorizationForm.IsLoginAndPasswordValid("qwerty", "123321dDd", db);

            //Assert
            Debug.Assert(result == false);
        }

        [TestMethod]
        public void Authorization_ValidLogin_AndInvalidPassword_ShouldnotAuthorization()
        {
            ApplicationContextDB db = new(GetInMemoryOptions());

            var user = new User
            {
                UserCode = "47534",
                Login = "rpakjj7",
                Password = bCrypt.PasswordHash("123321dDd"),
                Surname = "Petukhov",
                Name = "Nikitos",
                UserRole = "Admin"
            };
            db.Add(user);
            db.SaveChanges();

            //Act
            bool result = authorizationForm.IsLoginAndPasswordValid("rpakjj7", "qwerty", db);

            //Assert
            Debug.Assert(result == false);
        }

        [TestMethod]
        public void Authorization_InvaliddLogin_AndInvalidPassword_ShouldnotAuthorization()
        {
            ApplicationContextDB db = new(GetInMemoryOptions());

            var user = new User
            {
                UserCode = "47534",
                Login = "rpakjj7",
                Password = bCrypt.PasswordHash("123321dDd"),
                Surname = "Petukhov",
                Name = "Nikitos",
                UserRole = "Admin"
            };
            db.Add(user);
            db.SaveChanges();

            //Act
            bool result = authorizationForm.IsLoginAndPasswordValid("login", "qwerty", db);

            //Assert
            Debug.Assert(result == false);
        }
    }
}