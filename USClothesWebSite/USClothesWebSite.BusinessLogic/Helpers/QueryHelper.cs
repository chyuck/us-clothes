using System.Linq;
using DepIC;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.BusinessLogic.Helpers
{
    public static class QueryHelper
    {
        public static IQueryable<DataAccess.Parcel> FilterParcelsBySecurityPermissions(
            IQueryable<DataAccess.Parcel> initialQuery, IReadOnlyContainer container)
        {
            CheckHelper.ArgumentNotNull(initialQuery, "initialQuery");
            CheckHelper.ArgumentNotNull(container, "container");

            var securityService = container.Get<ISecurityService>();

            CheckHelper.WithinCondition(securityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(
                securityService.IsCurrentUserSeller ||
                securityService.IsCurrentUserPurchaser ||
                securityService.IsCurrentUserDistributor,
                "Only seller, purchaser and distributor can query parcels.");

            if (!securityService.IsCurrentUserPurchaser)
            {
                var currentUserId = securityService.CurrentUser.Id;

                if (securityService.IsCurrentUserSeller && securityService.IsCurrentUserDistributor)
                {
                    return
                        initialQuery
                            .Where(p =>
                                (p.DistributorId != null && p.DistributorId == currentUserId)
                                ||
                                p.Orders.Any(o => o.CreateUserId == currentUserId));
                }
                
                if (securityService.IsCurrentUserSeller)
                {
                    return
                        initialQuery
                            .Where(p => p.Orders.Any(o => o.CreateUserId == currentUserId));
                }
                
                if (securityService.IsCurrentUserDistributor)
                {
                    return
                        initialQuery
                            .Where(p => p.DistributorId != null && p.DistributorId == currentUserId);
                }
            }

            return initialQuery;
        }
    }
}
