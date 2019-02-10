using System.Text.RegularExpressions;

namespace USClothesWebSite.Common.Services.Validate
{
    public static class StringValidator
    {
        public static bool ValidateString(string str,
            int minLength = -1, int maxLength = -1, bool canBeNull = true, bool canBeEmpty = true, string regEx = null)
        {
            if (str == null)
                return canBeNull;

            if (str == string.Empty)
                return canBeEmpty;

            return
                (canBeEmpty || str != string.Empty) &&
                (minLength < 0 || str.Length >= minLength) &&
                (maxLength < 0 || str.Length <= maxLength) &&
                (regEx == null || Regex.IsMatch(str, regEx));
        }

        public static bool ValidatePassword(string password)
        {
            return ValidateString(password, 5, 50, false, false);
        }

        public static bool ValidateLogin(string login)
        {
            return ValidateString(login, 3, 50, false, false, @"^[.\w]*$");
        }

        public static bool ValidateEmail(string email)
        {
            return ValidateString(email, 6, 50, false, false, @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$");
        }
    }
}
