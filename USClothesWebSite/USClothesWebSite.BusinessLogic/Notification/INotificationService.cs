using USClothesWebSite.DTO;

namespace USClothesWebSite.BusinessLogic.Notification
{
    internal interface INotificationService
    {
        void NotifyUserCreated(User createdUser, string password);
        void NotifyPasswordReseted(User user, string password);
    }
}
