using System.Runtime.InteropServices;
using System.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.Test.Common
{
    public static class SecureStringAssert
    {
        public static void AreEqual(string expected, SecureString actual)
        {
            CheckHelper.ArgumentNotNull(actual, "actual");

            var passwordBSTR = Marshal.SecureStringToBSTR(actual);
            var actualString = Marshal.PtrToStringBSTR(passwordBSTR);

            Assert.AreEqual(expected, actualString);
        }
    }
}
