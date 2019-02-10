using USClothesWebSite.DTO;

namespace USClothesWebSite.BusinessLogic.Security
{
    public interface ISecurityService
    {
        void LogIn(SecurityData securityData);
        void LogInGuest();
        void LogOut();

        bool IsLoggedIn { get; }
        User CurrentUser { get; }
        Role[] CurrentRoles { get; }
        
        bool IsCurrentUserAdministrator { get; }
        bool IsCurrentUserPurchaser { get; }
        bool IsCurrentUserDistributor { get; }
        bool IsCurrentUserGuest { get; }
        bool IsCurrentUserSeller { get; }

        Role[] AvailableRoles { get; }
        
        User[] GetUsers(string filter);
        
        void ChangePassword(string newPassword);
        void UpdateUser(User updatedUser);
        void CreateUser(User createdUser);
        void ResetPassword(User user);
    }
}
