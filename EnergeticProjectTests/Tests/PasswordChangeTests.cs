using EnergeticProjectX.Classes;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UserChangePasswordForm;
using UserControl;

namespace PasswordChangeTests
{
    [TestClass]
    public class PasswordChangeTests
    {

        BCryptRealization bCrypt = new BCryptRealization();
        UserChangePassword changePasswordForm = new UserChangePassword("rpakjj7");

        private DbContextOptions<ApplicationContextDB> GetInMemoryOptions()
        {
            return new DbContextOptionsBuilder<ApplicationContextDB>()
                .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
                .Options;
        }

        [TestMethod]
        public void PasswordChange_ValidOldAndNewPasswords_SuccefulChange()
        {
            //Arrange
            ApplicationContextDB db = new(GetInMemoryOptions());

           

            var user = new User
            {
                UserCode = "47534",
                Login = "rpakjj7",
                Password = bCrypt.PasswordHash("123321dDd"),
                Surname = "Petukhov",
                Name = "Nikita",
                UserRole = "Admin"
            };
            db.Add(user);
            db.SaveChanges();

            //Act
            changePasswordForm.IsAllPasswordsAndLoginValid("123321dDd", "123321DDd", "123321DDd", db);

            //Assert
            Debug.Assert(changePasswordForm.isOldPasswordEqualDB);
            Debug.Assert(changePasswordForm.isPasswordsEqual);
            Debug.Assert(changePasswordForm.isUserFound);
        }

        [TestMethod]
        public void PasswordChange_InvaldOldAndValidNewPasswords_ShouldntChange()
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
           changePasswordForm.IsAllPasswordsAndLoginValid("qwerty", "123321DDd", "123321DDd", db);

            //Assert
            Assert.IsTrue(changePasswordForm.isUserFound);
            Assert.IsFalse(changePasswordForm.isOldPasswordEqualDB);
        }

        [TestMethod]
        public void PasswordChange_ValidOldAndNewPasswordsDoesntMatch_ShouldntChange()
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
            changePasswordForm.IsAllPasswordsAndLoginValid("123321dDd", "123321DDd", "123321D", db);

            //Assert
            Assert.IsFalse(changePasswordForm.isPasswordsEqual);
            Assert.IsTrue(changePasswordForm.isOldPasswordEqualDB);
        }

        [TestMethod]
        public void PasswordChange_AllInvalid_ShouldntChange()
        {
            //Arrange
            ApplicationContextDB db = new(GetInMemoryOptions());

            var user = new User
            {
                UserCode = "47534",
                Login = "qwerty",
                Password = bCrypt.PasswordHash("123321dDd"),
                Surname = "Petukhov",
                Name = "Nikitos",
                UserRole = "Admin"
            };
            db.Add(user);
            db.SaveChanges();

            //Act
            changePasswordForm.IsAllPasswordsAndLoginValid("qwerty", "qweqewqeq123", "123321DDd", db);

            //Assert
            Assert.IsFalse(changePasswordForm.isOldPasswordEqualDB);
            Assert.IsFalse(changePasswordForm.isPasswordsEqual);
            Assert.IsFalse(changePasswordForm.isUserFound);
        }
    }
}