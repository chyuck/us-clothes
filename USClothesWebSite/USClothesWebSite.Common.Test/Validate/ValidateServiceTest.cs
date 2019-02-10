using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.Common.Services.Validate;
using USClothesWebSite.Common.Services.Validate.Attributes;

namespace USClothesWebSite.Common.Test.Validate
{
    [TestClass]
    public class ValidateServiceTest
    {
        #region Test classes
        
        private class TestEmptyClass
        {
        }

        private class TestClassWithoutAttrs
        {
            public string TestProperty { get; set; } 

            public ValidationError TestMethod()
            {
                throw new NotImplementedException();
            }
        }

        private class TestClassWithAttrs
        {
            public string TestPropertyWithoutAttr { get; set; }

            public ValidationError TestMethodWithoutAttr()
            {
                throw new NotImplementedException();
            }

            [NotNullValidate("Static_Property", Key = "staticproperty")]
            public static string TestStaticPropertyWithAttr { get; set; }

            [ValidateMethod]
            public static ValidationError TestStaticMethodWithAttr()
            {
                return new ValidationError("staticmethod", "Static_Method");
            }

            [NotNullValidate("Public_Property", Key = "publicproperty")]
            public string TestPublicPropertyWithAttr { get; set; }

            [ValidateMethod]
            public ValidationError TestPublicMethodWithAttr()
            {
                return new ValidationError("publicmethod", "Public_Method");
            }

            [NotNullValidate("Internal_Property", Key = "internalproperty")]
            internal string TestInternalPropertyWithAttr { get; set; }

            [ValidateMethod]
            internal ValidationError TestInternalMethodWithAttr()
            {
                return new ValidationError("internalmethod", "Internal_Method");
            }

            [NotNullValidate("Protected_Property", Key = "protectedproperty")]
            protected string TestProtectedPropertyWithAttr { get; set; }

            [ValidateMethod]
            protected ValidationError TestProtectedMethodWithAttr()
            {
                return new ValidationError("protectedmethod", "Protected_Method");
            }

            [NotNullValidate("Private_Property", Key = "privateproperty")]
            private string TestPrivatePropertyWithAttr { get; set; }

            [ValidateMethod]
            private ValidationError TestPrivateMethodWithAttr()
            {
                return new ValidationError("privatemethod", "Private_Method");
            }
        }
        
        private class TestClassWithAnotherAttr
        {
            [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
            private class TestAttrAttribute : Attribute
            {
            }

            [TestAttr]
            public string TestProperty { get; set; }

            [TestAttr]
            public ValidationError TestMethod()
            {
                throw new NotImplementedException();
            }
        }

        private class TestClassWithValidValues
        {
            public TestClassWithValidValues()
            {
                TestProperty = "value";
            }

            [NotNullValidate("Public_Property", Key = "publicproperty")]
            private string TestProperty { get; set; }

            [ValidateMethod]
            public ValidationError TestMethod()
            {
                return null;
            }
        }

        private class TestClassWithInvalidMethod
        {
            [ValidateMethod]
            public ValidationError TestMethod(int t)
            {
                return new ValidationError("publicmethod", "Public_Method");
            }
        }

        private class TestClassWithAttrWithoutKey
        {
            [NotNullValidate("Public_Property")]
            private string TestProperty { get; set; }
        }

        private class TestClassWithSimilarValidationErrors
        {
            [NotNullValidate("Public_Property", Key = "similarError")]
            public string TestPropertyWithAttr { get; set; }

            [ValidateMethod]
            public ValidationError TestMethodWithAttr()
            {
                return new ValidationError("similarError", "Public_Property");
            }
        }
        
        private class TestBaseClass { }

        private class TestDerivedClass : TestBaseClass
        {
            [NotNullValidate("Public_Property", Key = "testKey")]
            public string TestPropertyWithAttr { get; set; }
        }

        #endregion


        #region Tests
       
        [TestMethod]
        public void Test_Validate_Should_Return_Null_When_Empty_Class()
        {
            // Arrange
            var ValidateService = new ValidateService();
            var testClass = new TestEmptyClass();

            // Act
            var errors = ValidateService.Validate(testClass);

            // Assert
            Assert.IsNull(errors);
        }

        [TestMethod]
        public void Test_Validate_Should_Return_Null_When_Class_Without_Attributes()
        {
            // Arrange
            var ValidateService = new ValidateService();
            var testClass = new TestClassWithoutAttrs();

            // Act
            var errors = ValidateService.Validate(testClass);

            // Assert
            Assert.IsNull(errors);
        }

        [TestMethod]
        public void Test_Validate_Should_Return_Errors()
        {
            // Arrange
            var ValidateService = new ValidateService();
            var testClass = new TestClassWithAttrs();

            // Act
            var errors = ValidateService.Validate(testClass);

            // Assert
            Assert.AreSame(testClass, errors.Object);
            Assert.AreEqual(10, errors.Errors.Length);

            CollectionAssert.AreEquivalent(
                new[]
                    {
                        new ValidationError("staticproperty", "Static_Property"),
                        new ValidationError("publicproperty", "Public_Property"),
                        new ValidationError("internalproperty", "Internal_Property"),
                        new ValidationError("protectedproperty", "Protected_Property"),
                        new ValidationError("privateproperty", "Private_Property"),

                        new ValidationError("staticmethod", "Static_Method"),
                        new ValidationError("publicmethod", "Public_Method"),
                        new ValidationError("internalmethod", "Internal_Method"),
                        new ValidationError("protectedmethod", "Protected_Method"),
                        new ValidationError("privatemethod", "Private_Method")
                    },
                errors.Errors);
        }

        [TestMethod]
        public void Test_Validate_Should_Return_Null_When_Class_With_Another_Attributes()
        {
            // Arrange
            var ValidateService = new ValidateService();
            var testClass = new TestClassWithAnotherAttr();

            // Act
            var errors = ValidateService.Validate(testClass);

            // Assert
            Assert.IsNull(errors);
        }

        [TestMethod]
        public void Test_Validate_Should_Return_Null_When_Class_Is_Valid()
        {
            // Arrange
            var ValidateService = new ValidateService();
            var testClass = new TestClassWithValidValues();

            // Act
            var errors = ValidateService.Validate(testClass);

            // Assert
            Assert.IsNull(errors);
        }

        [TestMethod]
        public void Test_Validate_Should_Return_Null_When_Class_With_Invalid_Method()
        {
            // Arrange
            var ValidateService = new ValidateService();
            var testClass = new TestClassWithInvalidMethod();

            // Act
            var errors = ValidateService.Validate(testClass);

            // Assert
            Assert.IsNull(errors);
        }

        [TestMethod]
        public void Test_Validate_Should_Return_ValidationError_With_Property_Name_As_Key()
        {
            // Arrange
            var ValidateService = new ValidateService();
            var testClass = new TestClassWithAttrWithoutKey();

            // Act
            var errors = ValidateService.Validate(testClass);

            // Assert
            Assert.AreEqual("TestProperty", errors.Errors[0].Key);
        }

        [TestMethod]
        public void Test_Validate_Should_Return_Only_One_ValidationError_When_Two_Similar_Errors_Are_Triggered()
        {
            // Arrange
            var ValidateService = new ValidateService();
            var testClass = new TestClassWithSimilarValidationErrors();

            // Act
            var errors = ValidateService.Validate(testClass);

            // Assert
            Assert.AreEqual(1, errors.Errors.Length);
            Assert.AreEqual("similarError", errors.Errors[0].Key);
        }

        [TestMethod]
        public void Test_Validate_Should_Return_Null_Object_When_T_Is_Base_Type()
        {
            // Arrange
            var ValidateService = new ValidateService();
            var testClass = new TestDerivedClass();

            // Act
            var errors = ValidateService.Validate<TestBaseClass>(testClass);

            // Assert
            Assert.IsNull(errors);
        }

        #endregion
    }
}
