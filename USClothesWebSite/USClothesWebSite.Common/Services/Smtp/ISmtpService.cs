using System.Net.Mail;

namespace USClothesWebSite.Common.Services.Smtp
{
    public interface ISmtpService
    {
        void SendEmail(MailMessage mailMessage);
    }
}
