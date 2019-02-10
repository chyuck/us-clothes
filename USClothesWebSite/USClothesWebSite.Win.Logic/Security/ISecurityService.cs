using USClothesWebSite.DTO;

namespace USClothesWebSite.Win.Logic.Security
{
    public interface ISecurityService
    {
        string Login(string login, string password);

        SecurityData SecurityData { get; }
        User CurrentUser { get; }
        Role[] CurrentRoles { get; }

        bool IsLoggedIn { get; }
        bool IsCurrentUserAdministrator { get; }
        bool IsCurrentUserPurchaser { get; }
        bool IsCurrentUserDistributor { get; }
        bool IsCurrentUserSeller { get; }

        Role[] AvailableRoles { get; }

        string CreateUser(User user);
        string UpdateUser(User user);
        string ResetPassword(User user);

        string ChangePassword(string newPassword, string passwordConfirmation);

        User[] GetUsers(string filter);
    }
}
