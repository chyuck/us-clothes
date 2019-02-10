using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Web.WebServices
{
    public class SecurityAPI : BaseAPI, ISecurityAPI
    {
        public string LogIn(SecurityData securityData)
        {
            var securityService = Container.Get<ISecurityService>();

            try
            {
                securityService.LogIn(securityData);
            }
            catch (SecurityServiceException ex)
            {
                return ex.Message;
            }

            return null;
        }
        
        public User GetCurrentUser()
        {
            return Container.Get<ISecurityService>().CurrentUser;
        }
        
        public Role[] GetAvailableRoles()
        {
                return Container.Get<ISecurityService>().AvailableRoles;
        }
        
        public string CreateUser(ref User user)
        {
            try
            {
                Container.Get<ISecurityService>().CreateUser(user);
            }
            catch (SecurityServiceException ex)
            {
                return ex.Message;
            }

            return null;
        }

        public string UpdateUser(User user)
        {
            try
            {
                Container.Get<ISecurityService>().UpdateUser(user);
            }
            catch (SecurityServiceException ex)
            {
                return ex.Message;
            }

            return null;
        }
        
        public string ChangePassword(string newPassword)
        {
            try
            {
                Container.Get<ISecurityService>().ChangePassword(newPassword);
            }
            catch (SecurityServiceException ex)
            {
                return ex.Message;
            }

            return null;
        }

        public User[] GetUsers(string filter)
        {
            return Container.Get<ISecurityService>().GetUsers(filter);
        }
        
        public string ResetPassword(User user)
        {
            try
            {
                Container.Get<ISecurityService>().ResetPassword(user);
            }
            catch (SecurityServiceException ex)
            {
                return ex.Message;
            }

            return null;
        }
    }
}
