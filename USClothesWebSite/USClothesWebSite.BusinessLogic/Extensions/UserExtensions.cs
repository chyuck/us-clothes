using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services.Encrypt;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.Extensions
{
    internal static class UserExtensions
    {
        public static void UpdatePasswordData(this User user, PasswordData passwordData)
        {
            CheckHelper.ArgumentNotNull(user, "user");
            CheckHelper.ArgumentNotNull(passwordData, "passwordData");

            user.PasswordHash = passwordData.PasswordHash;
            user.PasswordSalt = passwordData.PasswordSalt;
        }

        public static string GetFullName(this User user)
        {
            CheckHelper.ArgumentNotNull(user, "user");

            return string.Format("{0} {1}", user.LastName, user.FirstName);
        }

        public static string GetDataString(this User user)
        {
            CheckHelper.ArgumentNotNull(user, "user");

            return
                string.Format(
                    "Пользователь (Id:{0}, Логин:{1}, Имя:{2})",
                    user.Id,
                    user.Login,
                    user.GetFullName());
        }
    }
}
