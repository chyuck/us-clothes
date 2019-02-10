using System.Security;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.Common.Extensions
{
    public static class StringExtensions
    {
        public static SecureString ToSecureString(this string str)
        {
            CheckHelper.ArgumentNotNull(str, "str");

            var secureString = new SecureString();

            foreach (var ch in str)
                secureString.AppendChar(ch);

            secureString.MakeReadOnly();

            return secureString;
        }
    }
}
