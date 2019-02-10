using USClothesWebSite.DTO;
using USClothesWebSite.Win.Logic.Security;

namespace USClothesWebSite.Win.Logic.Extensions
{
    public static class ParcelExtensions
    {
        public static ISecurityService SecurityService
        {
            get { return IoC.Container.Get<ISecurityService>(); }
        }

        public static bool IsCurrentUserDistributorForParcel(this Parcel parcel)
        {
            return
                parcel != null && 
                parcel.Distributor != null && 
                SecurityService.IsCurrentUserDistributor &&
                parcel.Distributor.Id == SecurityService.CurrentUser.Id;
        }
    }
}
