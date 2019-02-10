using USClothesWebSite.DTO;
using USClothesWebSite.Win.Logic.Security;

namespace USClothesWebSite.Win.Logic.Extensions
{
    public static class OrderExtensions
    {
        public static ISecurityService SecurityService
        {
            get { return IoC.Container.Get<ISecurityService>(); }
        }

        public static bool IsCurrentUserDistributorForOrder(this Order order)
        {
            return
                order != null &&
                order.Parcel.IsCurrentUserDistributorForParcel();
        }

        public static bool IsCurrentUserSellerForOrder(this Order order)
        {
            return
                order != null &&
                SecurityService.IsCurrentUserSeller &&
                order.CreateUserId == SecurityService.CurrentUser.Id;
        }
    }
}
