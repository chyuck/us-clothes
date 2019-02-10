using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.Common.Services.Serialize;

namespace USClothesWebSite.Common.Test
{
    [TestClass]
    public class SerializeServiceTest
    {
        [DataContract]
        public class TestClass
        {
            [DataMember]
            public int TestProperty1 { get; set; }

            [DataMember]
            public string TestProperty2 { get; set; }
        }

        [TestMethod]
        public void Serialize_Should_Serialize_Object()
        {
            // Arrange
            var serializeService = new SerializeService();
            var obj = new TestClass { TestProperty1 = 3, TestProperty2 = "test" };

            // Act
            var data = serializeService.Serialize(obj);

            // Assert
            const string expected = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<TestClass xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <TestProperty1>3</TestProperty1>\r\n  <TestProperty2>test</TestProperty2>\r\n</TestClass>";
            Assert.AreEqual(expected, data);
        }

        [TestMethod]
        public void Deserialize_Should_Deserialize_Data()
        {
            // Arrange
            var serializeService = new SerializeService();
            const string data = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<TestClass xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <TestProperty1>3</TestProperty1>\r\n  <TestProperty2>test</TestProperty2>\r\n</TestClass>";

            // Act
            var obj = serializeService.Deserialize<TestClass>(data);

            // Assert
            Assert.IsNotNull(obj);
            Assert.AreEqual(3, obj.TestProperty1);
            Assert.AreEqual("test", obj.TestProperty2);
        }
    }
}
