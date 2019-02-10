using System.Configuration;

namespace USClothesWebSite.Common.Services.Configuration
{
    internal class SmtpSettingsConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty(HOST_PROP, IsRequired = true)]
        public string Host
        {
            get { return (string)this[HOST_PROP]; }
            set { this[HOST_PROP] = value; }
        }
        private const string HOST_PROP = "host";

        [ConfigurationProperty(PORT_PROP, IsRequired = true, DefaultValue = 0)]
        [IntegerValidator(MinValue = 0, MaxValue = 65535, ExcludeRange = false)]
        public int Port
        {
            get { return (int)this[PORT_PROP]; }
            set { this[PORT_PROP] = value; }
        }
        private const string PORT_PROP = "port";

        [ConfigurationProperty(ENABLE_SSL_PROP, IsRequired = true)]
        public bool EnableSsl
        {
            get { return (bool)this[ENABLE_SSL_PROP]; }
            set { this[ENABLE_SSL_PROP] = value; }
        }
        private const string ENABLE_SSL_PROP = "enableSsl";

        [ConfigurationProperty(USERNAME_PROP, IsRequired = true)]
        public string Username
        {
            get { return (string)this[USERNAME_PROP]; }
            set { this[USERNAME_PROP] = value; }
        }
        private const string USERNAME_PROP = "username";

        [ConfigurationProperty(PASSWORD_PROP, IsRequired = true)]
        public string Password
        {
            get { return (string)this[PASSWORD_PROP]; }
            set { this[PASSWORD_PROP] = value; }
        }
        private const string PASSWORD_PROP = "password";

        [ConfigurationProperty(TIMEOUT_PROP, IsRequired = true, DefaultValue = 1000)]
        [IntegerValidator(MinValue = 1000, MaxValue = 120000, ExcludeRange = false)]
        public int Timeout
        {
            get { return (int)this[TIMEOUT_PROP]; }
            set { this[TIMEOUT_PROP] = value; }
        }
        private const string TIMEOUT_PROP = "timeout";
    }
}
