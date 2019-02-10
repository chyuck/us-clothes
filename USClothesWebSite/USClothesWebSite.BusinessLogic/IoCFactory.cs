using DepIC;
using USClothesWebSite.BusinessLogic.ActionLog;
using USClothesWebSite.BusinessLogic.Brand;
using USClothesWebSite.BusinessLogic.Category;
using USClothesWebSite.BusinessLogic.Configuration;
using USClothesWebSite.BusinessLogic.DistributorTransfer;
using USClothesWebSite.BusinessLogic.Dto;
using USClothesWebSite.BusinessLogic.Http;
using USClothesWebSite.BusinessLogic.Image;
using USClothesWebSite.BusinessLogic.Log;
using USClothesWebSite.BusinessLogic.Notification;
using USClothesWebSite.BusinessLogic.Order;
using USClothesWebSite.BusinessLogic.Parcel;
using USClothesWebSite.BusinessLogic.Product;
using USClothesWebSite.BusinessLogic.ProductSize;
using USClothesWebSite.BusinessLogic.Report;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.BusinessLogic.Settings;
using USClothesWebSite.BusinessLogic.Size;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.BusinessLogic
{
    public static class IoCFactory
    {
        public static IContainer CreateContainer()
        {
            var container = ContainerFactory.Create();

            Common.IoCRegistrator.RegisterTimeService(container);
            Common.IoCRegistrator.RegisterEncryptService(container);
            Common.IoCRegistrator.RegisterSmtpService(container);
            Common.IoCRegistrator.RegisterSerializeService(container);
            Common.IoCRegistrator.RegisterValidateService(container);
            Common.IoCRegistrator.RegisterLocalizedNameService(container);
            
            DataAccess.IoCRegistrator.Register(container);

            RegisterAssemblyTypes(container);

            return container;
        }

        internal static void RegisterAssemblyTypes(IContainer container)
        {
            CheckHelper.ArgumentNotNull(container, "container");

            container.SetImplementation<IActionLogService, ActionLogService>(Lifetime.PerContainer);
            container.SetImplementation<IConfigurationService, ConfigurationService>(Lifetime.PerContainer);
            container.SetImplementation<INotificationService, NotificationService>(Lifetime.PerContainer);
            container.SetImplementation<ISettingsService, SettingsService>(Lifetime.PerContainer);
            container.SetImplementation<IImageService, ImageService>(Lifetime.PerContainer);

            container.SetImplementation<IDtoCache, DtoCache>();
            container.SetImplementation<IDtoService, DtoService>();

            container.SetImplementation<IPasswordGeneratorService, PasswordGeneratorService>(Lifetime.PerContainer);
            container.SetImplementation<ISecurityService, SecurityService>(Lifetime.PerContainer);

            container.SetImplementation<ICategoryService, CategoryService>(Lifetime.PerContainer);
            container.SetImplementation<IBrandService, BrandService>(Lifetime.PerContainer);
            container.SetImplementation<ISizeService, SizeService>(Lifetime.PerContainer);
            container.SetImplementation<IProductSizeService, ProductSizeService>(Lifetime.PerContainer);
            container.SetImplementation<IProductService, ProductService>(Lifetime.PerContainer);
            
            container.SetImplementation<IOrderService, OrderService>(Lifetime.PerContainer);
            container.SetImplementation<IParcelService, ParcelService>(Lifetime.PerContainer);

            container.SetImplementation<IHttpService, HttpService>(Lifetime.PerContainer);

            container.SetImplementation<IDistributorTransferService, DistributorTransferService>(Lifetime.PerContainer);

            container.SetImplementation<IReportService, ReportService>(Lifetime.PerContainer);

            container.SetImplementation<ILogService, LogService>(Lifetime.PerContainer);
        }
    }
}
