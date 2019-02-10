using System.Configuration;

namespace USClothesWebSite.Common.Services.Configuration
{
    internal class CommonConfigurationSection : ConfigurationSection
    {
        private const string SECTION_NAME = "USClothesWebSite.Common";

        public static CommonConfigurationSection Current
        {
            get
            {
                return (CommonConfigurationSection)ConfigurationManager.GetSection(SECTION_NAME);
            }
        }

        [ConfigurationProperty(SMTP_SETTINGS_ELEM, IsRequired = true)]
        public SmtpSettingsConfigurationElement SmtpSettings
        {
            get { return (SmtpSettingsConfigurationElement)this[SMTP_SETTINGS_ELEM]; }
            set { this[SMTP_SETTINGS_ELEM] = value; }
        }
        private const string SMTP_SETTINGS_ELEM = "smtpSettings";
    }
}
