using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.Common.Services.Validate.Attributes;

namespace USClothesWebSite.Common.Test.Validate
{
    [TestClass]
    public class NotNullValidateAttributeTest
    {
        [TestMethod]
        public void Test_IsValid_Should_Return_True_When_Value_Is_Not_Null()
        {
            // Arrange
            var attr = new NotNullValidateAttribute("Test message");

            // Act
            bool result = attr.IsValid("Value");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_IsValid_Should_Return_False_When_Value_Is_Null()
        {
            // Arrange
            var attr = new NotNullValidateAttribute("Test message");

            // Act
            bool result = attr.IsValid(null);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
