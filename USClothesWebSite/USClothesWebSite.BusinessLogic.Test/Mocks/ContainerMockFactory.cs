using System.Net.Mail;
using DepIC;
using Moq;
using USClothesWebSite.BusinessLogic.Http;
using USClothesWebSite.Common.Services.Encrypt;
using USClothesWebSite.Common.Services.Smtp;
using USClothesWebSite.Common.Services.Time;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.Test.Mocks
{
    public static class ContainerMockFactory
    {
        public static IContainer Create()
        {
            var container = ContainerFactory.Create();

            var timeServiceMock = TimeServiceMockFactory.Create();
            container.SetConstant<ITimeService, ITimeService>(timeServiceMock.Object);

            var persistentServiceMock = PersistentServiceMockFactory.Create();
            container.SetConstant<IPersistentService, IPersistentService>(persistentServiceMock.Object);

            var encryptServiceMock = EncryptServiceMockFactory.Create();
            container.SetConstant<IEncryptService, IEncryptService>(encryptServiceMock.Object);
            
            Common.IoCRegistrator.RegisterValidateService(container);

            IoCFactory.RegisterAssemblyTypes(container);

            container.Remove<IHttpService>();
            var httpServiceMock = HttpServiceMockFactory.Create();
            container.SetConstant<IHttpService, HttpService>(httpServiceMock.Object);

            var smtpServiceMock = new Mock<ISmtpService>(MockBehavior.Strict);
            smtpServiceMock.Setup(m => m.SendEmail(It.IsAny<MailMessage>()));
            container.SetConstant<ISmtpService, ISmtpService>(smtpServiceMock.Object);

            return container;
        }
    }
}
