using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.Common.Services.Configuration;
using USClothesWebSite.Test.Common;

namespace USClothesWebSite.Common.Test
{
    [TestClass]
    public class ConfigurationServiceTest
    {
        [TestMethod]
        public void SmtpSettings_Should_Return_SmtpSettings_From_Configuration_File()
        {
            // Arrange
            var configurationService = new ConfigurationService();

            // Act
            var smtpSettings = configurationService.SmtpSettings;

            // Assert
            Assert.AreEqual("mail.test.com", smtpSettings.Host);
            Assert.AreEqual(443, smtpSettings.Port);
            Assert.IsTrue(smtpSettings.EnableSsl);
            Assert.AreEqual("test", smtpSettings.Username);
            SecureStringAssert.AreEqual("test", smtpSettings.Password);
            Assert.AreEqual(10000, smtpSettings.Timeout);
        }
    }
}
