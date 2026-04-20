using EnergeticProjectX.Classes;
using Microsoft.EntityFrameworkCore;
using Registration;
using UserControl;

namespace RegistrationTests
{
    [TestClass]
    public class RegistrationTests
    {
        BCryptRealization bCrypt = new BCryptRealization();

        RegistrationForm registrationForm = new RegistrationForm();

        private DbContextOptions<ApplicationContextDB> GetInMemoryOptions()
        {
            return new DbContextOptionsBuilder<ApplicationContextDB>()
                .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
                .Options;
        }


        [TestMethod]
        public void Registration_FreeLoginAndCorrectPasswordsMatch_SuccefulRegistration()
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
            registrationForm.IsUserDataValid("sigma777", "123321dDd", "123321dDd", db);

            //Assert
            Assert.IsTrue(registrationForm.isLoginFree);
            Assert.IsTrue(registrationForm.isPasswordsMatch);
            Assert.IsTrue(registrationForm.isPasswordCorrect);
        }

        [TestMethod]
        public void Registration_BusyLoginCorrectPasswords_ShouldntlRegistration()
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
            registrationForm.IsUserDataValid("rpakjj7", "123321dDd", "123321dDd", db);

            //Assert
            Assert.IsFalse(registrationForm.isLoginFree);
        }

        [TestMethod]
        public void Registration_FreeLoginAndInCorrectPassword_ShouldntlRegistration()
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
            registrationForm.IsUserDataValid("rpakjj7", "123321", "123321", db);

            //Assert
            Assert.IsFalse(registrationForm.isPasswordCorrect);
        }

        [TestMethod]
        public void Registration_BusyLoginAndInCorrectPasswordsDoesntMatch_ShouldntlRegistration()
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
            registrationForm.IsUserDataValid("rpakjj7", "123321d", "1233", db);

            //Assert
            Assert.IsFalse(registrationForm.isLoginFree);  
        }

        [TestMethod]
        public void Registration_BusyLoginAndCorrectPasswordsDoesntMatch_ShouldntlRegistration()
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
            registrationForm.IsUserDataValid("rpakjj7", "123321dDd", "123321dDd", db);

            //Assert
            Assert.IsFalse(registrationForm.isLoginFree);
        }

    }
}