using System;
using System.Security;

namespace USClothesWebSite.Common.Services.Configuration
{
    internal class SmtpSettings : ICloneable
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }

        public string Username { get; set; }
        public SecureString Password { get; set; }

        public int Timeout { get; set; }

        public object Clone()
        {
            return
                new SmtpSettings
                {
                    Host = Host,
                    Port = Port,
                    EnableSsl = EnableSsl,
                    Username = Username,
                    Password = Password,
                    Timeout = Timeout
                };
        }
    }
}
