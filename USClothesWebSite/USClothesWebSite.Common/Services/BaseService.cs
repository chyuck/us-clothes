using DepIC;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.Common.Services
{
    public abstract class BaseService
    {
        protected BaseService(IReadOnlyContainer container)
        {
            CheckHelper.ArgumentNotNull(container, "container");

            Container = container;
        }

        protected IReadOnlyContainer Container { get; private set; }
    }
}
