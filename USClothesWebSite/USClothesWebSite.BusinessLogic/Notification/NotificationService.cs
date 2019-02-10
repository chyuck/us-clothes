using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Reflection;
using System.Resources;
using System.Text;
using DepIC;
using DepIC.Attributes;
using USClothesWebSite.BusinessLogic.Extensions;
using USClothesWebSite.BusinessLogic.Http;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services;
using USClothesWebSite.Common.Services.Smtp;
using USClothesWebSite.Common.Services.Validate;
using USClothesWebSite.DTO;

namespace USClothesWebSite.BusinessLogic.Notification
{
    internal class NotificationService : BaseService, INotificationService
    {
        #region Constructors

        [Inject]
        public NotificationService(IReadOnlyContainer container) 
            : base(container)
        {
        }

        #endregion


        #region Properties

        private ISecurityService SecurityService
        {
            get { return Container.Get<ISecurityService>(); }
        }

        #endregion


        #region Methods

        private static string GetTemplate(string templateName)
        {
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(templateName, "templateName");

            var resourceName = string.Format("USClothesWebSite.BusinessLogic.Notification.{0}.html", templateName);
            
            using (var templateStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (templateStream == null)
                    throw new MissingManifestResourceException(
                        string.Format(@"Embedded resource ""{0}"" is not found.", resourceName));

                using (var streamReader = new StreamReader(templateStream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        private string GetEmailBody(string templateName, IDictionary<string, string> parameters)
        {
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(templateName, "templateName");
            CheckHelper.ArgumentNotNull(parameters, "parameters");

            var template = GetTemplate(templateName);
            
            var stringBuilder = new StringBuilder(template);

            var httpService = Container.Get<IHttpService>();

            var logo = httpService.GetAbsoluteURLFromRelativeURL("Images/email_logo.png");
            var install = httpService.GetAbsoluteURLFromRelativeURL("Install/UsClothes.msi");

            stringBuilder.Replace("@logo", logo);
            stringBuilder.Replace("@install", install);

            foreach (var parameter in parameters)
                stringBuilder.Replace(parameter.Key, parameter.Value);

            return stringBuilder.ToString();
        }

        private void SendEmailMessage(string toName, string toAddress, string subject, string body)
        {
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(toName, "toName");
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(toAddress, "toAddress");
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(subject, "subject");
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(body, "body");
            
            var mailMessage =
                new MailMessage(
                    new MailAddress("info@usclothes.ru", "US Clothes", Encoding.UTF8),
                    new MailAddress(toName, toAddress, Encoding.UTF8))
                    {
                        BodyEncoding = Encoding.UTF8,
                        IsBodyHtml = true,
                        Body = body,

                        SubjectEncoding = Encoding.UTF8,
                        Subject = subject
                    };

            Container.Get<ISmtpService>().SendEmail(mailMessage);
        }

        #endregion


        #region INotificationService

        public void NotifyUserCreated(User createdUser, string password)
        {
            CheckHelper.ArgumentNotNull(createdUser, "createdUser");
            CheckHelper.ArgumentWithinCondition(!createdUser.IsNew(), "!createdUser.IsNew()");
            Container.Get<IValidateService>().CheckIsValid(createdUser);
            
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(password, "password");
            CheckHelper.ArgumentWithinCondition(StringValidator.ValidatePassword(password), "password");

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserAdministrator, "Current user is not administrator.");

            var install = Container.Get<IHttpService>().GetAbsoluteURLFromRelativeURL("Install/UsClothesSetup.exe");
            var userFullName = createdUser.ToString();

            var body =
                GetEmailBody("UserCreatedEmailTemplate",
                    new Dictionary<string, string>
                    {
                        {"@user", userFullName},
                        {"@login", createdUser.Login},
                        {"@password", password},
                        {"@install", install}
                    });

            SendEmailMessage(createdUser.Email, userFullName, "Регистрация в системе US Clothes", body);
        }

        public void NotifyPasswordReseted(User user, string password)
        {
            CheckHelper.ArgumentNotNull(user, "user");
            CheckHelper.ArgumentWithinCondition(!user.IsNew(), "!user.IsNew()");
            Container.Get<IValidateService>().CheckIsValid(user);

            CheckHelper.ArgumentNotNullAndNotWhiteSpace(password, "password");
            CheckHelper.ArgumentWithinCondition(StringValidator.ValidatePassword(password), "password");

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");

            var userFullName = user.ToString();

            var body =
                GetEmailBody("PasswordResetedEmailTemplate",
                    new Dictionary<string, string>
                    {
                        {"@user", userFullName},
                        {"@password", password}
                    });

            SendEmailMessage(user.Email, userFullName, "Пароль сброшен в системе US Clothes", body);
        }

        #endregion
    }
}
