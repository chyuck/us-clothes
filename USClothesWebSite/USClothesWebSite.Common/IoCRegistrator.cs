using DepIC;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services.Configuration;
using USClothesWebSite.Common.Services.Encrypt;
using USClothesWebSite.Common.Services.LocalizedName;
using USClothesWebSite.Common.Services.Serialize;
using USClothesWebSite.Common.Services.Smtp;
using USClothesWebSite.Common.Services.Time;
using USClothesWebSite.Common.Services.Validate;

namespace USClothesWebSite.Common
{
    public static class IoCRegistrator
    {
        private static void RegisterConfigurationServiceSafe(IContainer container)
        {
            CheckHelper.ArgumentNotNull(container, "container");

            if (!container.Contains<IConfigurationService>())
                container.SetImplementation<IConfigurationService, ConfigurationService>(Lifetime.PerContainer);
        }

        public static void RegisterSmtpService(IContainer container)
        {
            CheckHelper.ArgumentNotNull(container, "container");

            RegisterConfigurationServiceSafe(container);

            container.SetImplementation<ISmtpService, SmtpService>(Lifetime.PerContainer);
        }

        public static void RegisterTimeService(IContainer container)
        {
            CheckHelper.ArgumentNotNull(container, "container");

            container.SetImplementation<ITimeService, TimeService>(Lifetime.PerContainer);
        }

        public static void RegisterEncryptService(IContainer container)
        {
            CheckHelper.ArgumentNotNull(container, "container");

            container.SetImplementation<IEncryptService, EncryptService>(Lifetime.PerContainer);
        }

        public static void RegisterSerializeService(IContainer container)
        {
            CheckHelper.ArgumentNotNull(container, "container");

            container.SetImplementation<ISerializeService, SerializeService>(Lifetime.PerContainer);
        }

        public static void RegisterValidateService(IContainer container)
        {
            CheckHelper.ArgumentNotNull(container, "container");

            container.SetImplementation<IValidateService, ValidateService>(Lifetime.PerContainer);
        }

        public static void RegisterLocalizedNameService(IContainer container)
        {
            CheckHelper.ArgumentNotNull(container, "container");

            container.SetImplementation<ILocalizedNameService, LocalizedNameService>(Lifetime.PerContainer);
        }
    }
}
