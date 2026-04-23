using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Objects;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UserChangePasswordForm;

namespace EnergeticProjectTestt.Tests
{
    [TestClass]
    public class PasswordChangeTests
    {
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

        private readonly UserChangePassword changePasswordForm = new("rpakjj7");
        private static DbContextOptions<ApplicationContextDB> GetInMemoryOptions()
        {
            return new DbContextOptionsBuilder<ApplicationContextDB>()
                .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
                .Options;
        }

        private readonly ApplicationContextDB db = new(GetInMemoryOptions());

        [TestMethod]
        public void ValidOldAndNewPasswords()
        {
            //Arrange

            db.Add(user);
            db.SaveChanges();

            //Act
            (var result, var message) = changePasswordForm.
                IsAllPasswordsValid("123321dDd", "123321DDd", "123321DDd", db, userLogin);

            //Assert
            Debug.Assert(result);
        }

        [TestMethod]
        public void InvalidOldPassword()
        {
            //Arrange
            db.Add(user);
            db.SaveChanges();

            //Act
            (var result, var message) = changePasswordForm.
                IsAllPasswordsValid("qwerty", "123321DDd", "123321DDd", db, userLogin);

            //Assert
            Debug.Assert(!result);
        }

        [TestMethod]
        public void NotMatchOldAndNewPassword()
        {
            //Arrange
            db.Add(user);
            db.SaveChanges();

            //Act
            (var result, var message) = changePasswordForm.
                IsAllPasswordsValid("123321dDd", "123321DDd", "123321D", db, userLogin);

            //Assert
            Debug.Assert(!result);
        }
    }
}