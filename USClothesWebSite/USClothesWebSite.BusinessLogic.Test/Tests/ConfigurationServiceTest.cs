using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.BusinessLogic.Configuration;

namespace USClothesWebSite.BusinessLogic.Test
{
    [TestClass]
    public class ConfigurationServiceTest
    {
        [TestMethod]
        public void ImagesDirectory_Should_Return_ImageDirectory_From_Configuration_File()
        {
            // Arrange
            var configurationService = new ConfigurationService();

            // Act
            var imagesDirectoryName = configurationService.ImagesDirectoryName;

            // Assert
            Assert.AreEqual("Images", imagesDirectoryName);
        }
    }
}
