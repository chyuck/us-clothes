using USClothesWebSite.Common.Extensions;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.Common.Services.Configuration
{
    internal class ConfigurationService : IConfigurationService
    {
        public SmtpSettings SmtpSettings
        {
            get
            {
                var smtpSettings = CacheHelper.Get(ref _smtpSettings, CreateSmtpSettings);

                return (SmtpSettings)smtpSettings.Clone();
            }
        }
        private SmtpSettings _smtpSettings;

        private static CommonConfigurationSection GetConfiguration()
        {
            var configuration = CommonConfigurationSection.Current;
            CheckHelper.NotNull(configuration, "configuration");

            return configuration;
        }

        private static SmtpSettings CreateSmtpSettings()
        {
            var configuration = GetConfiguration();
            var smtpSettingsConfiguration = configuration.SmtpSettings;

            return
                new SmtpSettings
                    {
                        Host = smtpSettingsConfiguration.Host,
                        Port = smtpSettingsConfiguration.Port,
                        EnableSsl = smtpSettingsConfiguration.EnableSsl,
                        Username = smtpSettingsConfiguration.Username,
                        Password = smtpSettingsConfiguration.Password.ToSecureString(),
                        Timeout = smtpSettingsConfiguration.Timeout
                    };
        }
    }
}
