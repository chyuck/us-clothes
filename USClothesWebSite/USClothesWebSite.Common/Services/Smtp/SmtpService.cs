using System.Net;
using System.Net.Mail;
using DepIC;
using DepIC.Attributes;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services.Configuration;

namespace USClothesWebSite.Common.Services.Smtp
{
    internal class SmtpService : BaseService, ISmtpService
    {
        [Inject]
        public SmtpService(IReadOnlyContainer container) 
            : base(container)
        {
        }

        public void SendEmail(MailMessage mailMessage)
        {
            CheckHelper.ArgumentNotNull(mailMessage, "mailMessage");

            var smtpSettings = Container.Get<IConfigurationService>().SmtpSettings;

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Host = smtpSettings.Host;
                smtpClient.Port = smtpSettings.Port;
                smtpClient.EnableSsl = smtpSettings.EnableSsl;
                smtpClient.Credentials = new NetworkCredential(smtpSettings.Username, smtpSettings.Password);
                smtpClient.Timeout = smtpSettings.Timeout;

                smtpClient.DeliveryFormat = SmtpDeliveryFormat.International;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtpClient.Send(mailMessage);
            }
        }
    }
}
