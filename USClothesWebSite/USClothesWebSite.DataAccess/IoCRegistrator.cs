using DepIC;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.DataAccess
{
    public static class IoCRegistrator
    {
        public static void Register(IContainer container)
        {
            CheckHelper.ArgumentNotNull(container, "container");

            container.SetImplementation<IPersistentService, USClothesShopEntities>(Lifetime.PerContainer);
        }
    }
}
