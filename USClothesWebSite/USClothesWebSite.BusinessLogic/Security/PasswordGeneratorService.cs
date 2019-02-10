using DepIC;
using DepIC.Attributes;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services;
using USClothesWebSite.Common.Services.Time;

namespace USClothesWebSite.BusinessLogic.Security
{
    internal class PasswordGeneratorService : BaseService, IPasswordGeneratorService
    {
        [Inject]
        public PasswordGeneratorService(IReadOnlyContainer container) 
            : base(container)
        {
        }

        public string GenerateTemporaryPassword(string login)
        {
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(login, "login");

            var utcNow = Container.Get<ITimeService>().UtcNow;

            return string.Format("{0}!{1}", login, utcNow.Ticks);
        }
    }
}
