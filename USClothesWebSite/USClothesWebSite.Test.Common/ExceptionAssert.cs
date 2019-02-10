using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.Test.Common
{
    public static class ExceptionAssert
    {
        public static T Throw<T>(Action action)
            where T : Exception
        {
            CheckHelper.ArgumentNotNull(action, "action");

            try
            {
                action();
            }
            catch (T ex)
            {
                return ex;
            }

            Assert.Fail("Exception of type {0} should be thrown.", typeof(T));

            return null;
        }

        public static T Throw<T>(Action action, string expectedMessage)
            where T : Exception
        {
            CheckHelper.ArgumentNotNull(action, "action");
            CheckHelper.ArgumentNotNull(expectedMessage, "expectedMessage");

            try
            {
                action();
            }
            catch (T ex)
            {
                Assert.AreEqual(expectedMessage, ex.Message);

                return ex;
            }

            Assert.Fail(@"Exception of type {0} with message ""{1}"" should be thrown.", typeof(T), expectedMessage);

            return null;
        }
    }
}
