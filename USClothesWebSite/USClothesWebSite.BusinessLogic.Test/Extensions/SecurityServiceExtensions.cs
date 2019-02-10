using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DTO;

namespace USClothesWebSite.BusinessLogic.Test.Extensions
{
    public static class SecurityServiceExtensions
    {
        public static void LogIn(this ISecurityService securityService, string login, string password)
        {
            CheckHelper.ArgumentNotNull(securityService, "securityService");

            var securityData =
                new SecurityData
                {
                    Login = login,
                    Password = password
                };

            securityService.LogIn(securityData);
        }
    }
}
