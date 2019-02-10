using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.Common.Services.Validate.Attributes;

namespace USClothesWebSite.Common.Test.Validate
{
    [TestClass]
    public class LoginValidateAttributeTest
    {
        [TestMethod]
        public void Test_IsValid_Should_Return_False_When_Value_Is_Invalid_Login()
        {
            var values =
                new[]
                {
                    "",
                    null,
                    "AbcdefghijAbcdefghijAbcdefghijAbcdefghijachyuckacob", // Greater than 50
                    "Ab", // Less than 3
                    "_.ahzAHZ19 0АРЯаря._achyuckacom" // Space (invalid character)
                };

            foreach (var value in values)
            {
                // Arrange
                var attr = new LoginValidateAttribute("Test message");

                // Act
                bool result = attr.IsValid(value);

                // Assert
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void Test_IsValid_Should_Return_True_When_Value_Is_Valid_Login()
        {
             var values =
                new[]
                {
                    "AbcdefghijAbcdefghijAbcdefghijAbcdefghiachyuckacom", // Equal 50
                    "abc", // Equal 3
                    "_.ahzAHZ190АРЯаря._" // Between 3 and 50
                };

            foreach (var value in values)
            {
                // Arrange
                var attr = new LoginValidateAttribute("Test message");

                // Act
                bool result = attr.IsValid(value);

                // Assert
                Assert.IsTrue(result);
            }
        }
    }
}
