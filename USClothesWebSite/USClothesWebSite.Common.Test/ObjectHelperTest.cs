using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.Common.Helpers.Object;

namespace USClothesWebSite.Common.Test
{
    [TestClass]
    public class ObjectHelperTest
    {
        #region Test Classes

        public class TestClass1 : ICloneable
        {
            public override int GetHashCode()
            {
                return 399;
            }

            public override bool Equals(object obj)
            {
                return true;
            }

            public object Clone()
            {
                return new TestClass1();
            }
        }

        public class TestClass2
        {
            public int TestProperty1 { get; set; }
            public TestClass1 TestProperty2 { get; set; }
            public string TestProperty3 { get; set; }
            public int TestProperty4 
            {
                get { return 980; }
            }

            public TestClass1[] TestProperty5 { get; set; }

            [IgnoreInClone]
            [IgnoreInEquals]
            [IgnoreInGetHashCode]
            public int TestProperty6 { get; set; }

            public int TestMethod()
            {
                return 678678;
            }
        }

        #endregion


        #region Tests

        [TestMethod]
        public void GetHashCode_Should_Return_HashCode_Of_Object()
        {
            // Arrange
            var obj =
                new TestClass2
                {
                    TestProperty1 = 3454,
                    TestProperty2 = new TestClass1(),
                    TestProperty5 = new[] { new TestClass1() }
                };

            // Act
            var actual = ObjectHelper.GetHashCode(obj);

            // Assert
            Assert.AreEqual(obj.TestProperty1 | obj.TestProperty2.GetHashCode(), actual);
        }

        [TestMethod]
        public void Equals_Should_Return_True_When_Both_Object_Are_Null()
        {
            // Act
            var result = ObjectHelper.Equals<TestClass1>(null, null);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_Should_Return_False_When_One_Is_Null()
        {
            // Act
            var result = ObjectHelper.Equals(new TestClass1(), null);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_Should_Return_True_When_Both_Are_The_Same_Object()
        {
            // Arrange
            var obj = new TestClass1();

            // Act
            var result = ObjectHelper.Equals(obj, obj);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_Should_Return_True_When_Objects_Are_Equal()
        {
            // Arrange
            var obj1 = 
                new TestClass2
                    {
                        TestProperty1 = 4,
                        TestProperty2 = new TestClass1()
                    };
            var obj2 =
                new TestClass2
                {
                    TestProperty1 = 4,
                    TestProperty2 = new TestClass1(),
                    TestProperty6 = 490,
                    TestProperty5 = new[] { new TestClass1() }
                };

            // Act
            var result = ObjectHelper.Equals(obj1, obj2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_Should_Return_False_When_Objects_Are_Not_Equal()
        {
            // Arrange
            var obj1 =
                new TestClass2
                {
                    TestProperty1 = 4,
                    TestProperty2 = new TestClass1()
                };
            var obj2 =
                new TestClass2
                {
                    TestProperty1 = 5,
                    TestProperty2 = new TestClass1()
                };

            // Act
            var result = ObjectHelper.Equals(obj1, obj2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Clone_Should_Clone_Object()
        {
            // Arrange
            var obj =
                new TestClass2
                {
                    TestProperty1 = 3454,
                    TestProperty2 = new TestClass1()
                };

            // Act
            var clone = ObjectHelper.Clone(obj);

            // Assert
            Assert.AreEqual(obj.TestProperty1, clone.TestProperty1);
            Assert.IsNotNull(clone.TestProperty2);
            Assert.AreNotSame(obj.TestProperty2, clone.TestProperty2);
            Assert.AreEqual(obj.TestProperty3, clone.TestProperty3);
            Assert.IsNull(clone.TestProperty5);
            Assert.AreEqual(default(int), clone.TestProperty6); 
        }

        #endregion
    }
}
