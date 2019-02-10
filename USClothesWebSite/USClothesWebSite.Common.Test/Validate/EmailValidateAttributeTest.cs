using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.Common.Services.Validate.Attributes;

namespace USClothesWebSite.Common.Test.Validate
{
    [TestClass]
    public class EmailValidateAttributeTest
    {
        [TestMethod]
        public void Test_IsValid_Should_Return_False_When_Value_Is_Invalid_Email()
        {
            var values =
                new[]
                {
                    "",
                    null,
                    "AbcdefghijAbcdefghijAbcdefghijAbcdefghij@chyuck.com", // Greater than 50
                    "a@a.a", // Less than 6
                    "_.ahzAHZ19 0АРЯаря._@chyuck.com" // Space (invalid character)
                };

            foreach (var value in values)
            {
                // Arrange
                var attr = new EmailValidateAttribute("Test message");

                // Act
                bool result = attr.IsValid(value);

                // Assert
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void Test_IsValid_Should_Return_True_When_Value_Is_Valid_Email()
        {
            var values =
                new[]
                {
                    "AbcdefghijAbcdefghijAbcdefghijAbcdefghi@chyuck.com", // Equal 50
                    "a@a.aa", // Equal 6
                    "ANDREY.-_andrey9@CHYUCK-chyuck.ru.com" // Between 6 and 50
                };

            foreach (var value in values)
            {
                // Arrange
                var attr = new EmailValidateAttribute("Test message");

                // Act
                bool result = attr.IsValid(value);

                // Assert
                Assert.IsTrue(result);
            }
        }
    }
}
