using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.Common.Extensions;

namespace USClothesWebSite.Common.Test
{
    [TestClass]
    public class DecimalExtensionsTest
    {
        [TestMethod]
        public void ToMoney_Should_Round_To_3456_25_When_3456_2459()
        {
            Assert.AreEqual(3456.25m, 3456.2459m.ToMoney());
        }

        [TestMethod]
        public void ToMoney_Should_Round_To_3456_24_When_3456_2449()
        {
            Assert.AreEqual(3456.24m, 3456.2449m.ToMoney());
        }

        [TestMethod]
        public void ToMoney_Should_Round_To_0_20_When_0_2()
        {
            Assert.AreEqual(0.2m, 0.2m.ToMoney());
        }
    }
}
