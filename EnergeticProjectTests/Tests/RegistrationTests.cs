using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Objects;
using Microsoft.EntityFrameworkCore;
using Registration;
using System.Diagnostics;

namespace EnergeticProjectTestt.Tests
{
    [TestClass]
    public class RegistrationTests
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
        public void FreeLoginAndCorrectPasswords()
        {
            //Arrange
            db.Add(user);
            db.SaveChanges();

            var newPassword = "123321dDd";
            var confirmationPassword = "123321dDd";


            //Act

            var newUserLogin = "xqwift";
            var isloginFree = RegistrationForm.IsUserLoginFree(newUserLogin, db);
            (var isPasswordMatch, var isPasswordRelevant) = User.IsPasswordRelevant(newPassword, confirmationPassword);

            //Assert
            Debug.Assert(isloginFree && isPasswordMatch && isPasswordRelevant);
        }

        [TestMethod]
        public void BusyLogin()
        {
            //Arrange
            db.Add(user);
            db.SaveChanges();

            //Act
            var isloginFree = RegistrationForm.IsUserLoginFree(userLogin, db);

            //Assert
            Debug.Assert(!isloginFree);
        }

        [TestMethod]
        public void FreeLoginAndInCorrectPassword()
        {
            //Arrange
            db.Add(user);
            db.SaveChanges();

            var newPassword = "123321dDd";
            var confirmationPassword = "123321dD";

            //Act
            var newUserLogin = "xqwift";
            var isloginFree = RegistrationForm.IsUserLoginFree(newUserLogin, db);
            (var isPasswordMatch, var isPasswordRelevant) = User.IsPasswordRelevant(newPassword, confirmationPassword);

            //Assert
            Debug.Assert(!(isloginFree && isPasswordMatch && isPasswordRelevant));
        }
    }
}