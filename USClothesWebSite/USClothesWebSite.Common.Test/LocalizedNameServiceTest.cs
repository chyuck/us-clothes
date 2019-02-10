using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.Common.Services.LocalizedName;

namespace USClothesWebSite.Common.Test
{
    [TestClass]
    public class LocalizedNameServiceTest
    {
        private const string TEST_SINGLE_NAME = "Test Single Name";
        private const string TEST_PLURAL_NAME = "Test Plural Name";

        [LocalizedName(TEST_SINGLE_NAME, TEST_PLURAL_NAME)]
        private class TestClass
        {
        }

        [TestMethod]
        public void GetSingleLocalizedName_Should_Return_Single_LocalizedName_From_Attribute()
        {
            // Arrange
            var localizedNameService = new LocalizedNameService();

            // Act
            var actual = localizedNameService.GetSingleLocalizedName<TestClass>();

            // Assert
            Assert.AreEqual(TEST_SINGLE_NAME, actual);
        }

        [TestMethod]
        public void GetPluralLocalizedName_Should_Return_Plural_LocalizedName_From_Attribute()
        {
            // Arrange
            var localizedNameService = new LocalizedNameService();

            // Act
            var actual = localizedNameService.GetPluralLocalizedName<TestClass>();

            // Assert
            Assert.AreEqual(TEST_PLURAL_NAME, actual);
        }
    }
}
