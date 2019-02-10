using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.Common.Services.Encrypt;

namespace USClothesWebSite.Common.Test
{
    [TestClass]
    public class EncryptServiceTest
    {
        [TestMethod]
        public void GeneratePasswordSalt_Should_Generate_Random_String()
        {
            // Arrange
            var encryptService = new EncryptService();

            // Act
            var salt1 = encryptService.GeneratePasswordSalt();
            var salt2 = encryptService.GeneratePasswordSalt();

            // Assert
            Assert.AreNotEqual(salt1, salt2);
        }

        [TestMethod]
        public void GeneratePasswordSalt_Should_Return_String_Consists_Of_32_Characters()
        {
            // Arrange
            var encryptService = new EncryptService();

            // Act
            var salt = encryptService.GeneratePasswordSalt();

            // Assert
            Assert.AreEqual(32, salt.Length);
        }

        [TestMethod]
        public void EncryptPassword_Should_Generate_Password_And_Salt()
        {
            // Arrange
            const string PASSWORD = "Password!@#$%^&*()_+|}{{POIIUUYTTRREEQWASDFGHJKL:><MNBVCXZZ[]";
            var encryptService = new EncryptService();

            // Act
            var passwordData = encryptService.EncryptPassword(PASSWORD);

            // Assert
            Assert.AreEqual(PASSWORD, passwordData.Password);
            Assert.AreEqual(32, passwordData.PasswordSalt.Length);
            Assert.AreEqual(32, passwordData.PasswordHash.Length);
        }

        [TestMethod]
        public void EncryptPassword_Should_Generate_Password()
        {
            // Arrange
            const string PASSWORD = "Password!@#$%^&*()_+|}{{POIIUUYTTRREEQWASDFGHJKL:><MNBVCXZZ[]";
            var encryptService = new EncryptService();
            var salt = encryptService.GeneratePasswordSalt();

            // Act
            var passwordData = encryptService.EncryptPassword(PASSWORD, salt);

            // Assert
            Assert.AreEqual(PASSWORD, passwordData.Password);
            Assert.AreEqual(salt, passwordData.PasswordSalt);
            Assert.AreEqual(32, passwordData.PasswordHash.Length);
        }

        [TestMethod]
        public void EncryptPassword_Should_Generate_The_Same_HashPassword_For_Given_Salt_And_Password()
        {
            // Arrange
            const string PASSWORD = "Password!@#$%^&*()_+|}{{POIIUUYTTRREEQWASDFGHJKL:><MNBVCXZZ[]";
            var encryptService = new EncryptService();
            var salt = encryptService.GeneratePasswordSalt();

            // Act
            var passwordData1 = encryptService.EncryptPassword(PASSWORD, salt);
            var passwordData2 = encryptService.EncryptPassword(PASSWORD, salt);

            // Assert
            Assert.AreEqual(passwordData1.Password, passwordData2.Password);
            Assert.AreEqual(passwordData1.PasswordSalt, passwordData2.PasswordSalt);
            Assert.AreEqual(passwordData1.PasswordHash, passwordData2.PasswordHash);
        }
    }
}
