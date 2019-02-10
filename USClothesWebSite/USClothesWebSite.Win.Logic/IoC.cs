using DepIC;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Win.Logic.Administration;
using USClothesWebSite.Win.Logic.AdministrationAPI;
using USClothesWebSite.Win.Logic.Async;
using USClothesWebSite.Win.Logic.Dictionary;
using USClothesWebSite.Win.Logic.DictionaryAPI;
using USClothesWebSite.Win.Logic.Document;
using USClothesWebSite.Win.Logic.DocumentAPI;
using USClothesWebSite.Win.Logic.Error;
using USClothesWebSite.Win.Logic.Form;
using USClothesWebSite.Win.Logic.Image;
using USClothesWebSite.Win.Logic.ImageAPI;
using USClothesWebSite.Win.Logic.Log;
using USClothesWebSite.Win.Logic.LogAPI;
using USClothesWebSite.Win.Logic.Menu;
using USClothesWebSite.Win.Logic.Product;
using USClothesWebSite.Win.Logic.ProductAPI;
using USClothesWebSite.Win.Logic.Report;
using USClothesWebSite.Win.Logic.ReportAPI;
using USClothesWebSite.Win.Logic.Security;
using USClothesWebSite.Win.Logic.SecurityAPI;

namespace USClothesWebSite.Win.Logic
{
    public static class IoC
    {
        private static volatile IContainer _container;
        private static readonly object _syncRoot = new object();

        private static IContainer EditableContainer
        {
            get
            {
                if (_container == null)
                {
                    lock (_syncRoot)
                    {
                        if (_container == null)
                            _container = CreateContainer();
                    }
                }

                return _container;
            }
        }

        public static IReadOnlyContainer Container
        {
            get { return EditableContainer; }
        }

        public static void RegisterMenuHolder(IMenuHolder menuHolder)
        {
            CheckHelper.ArgumentNotNull(menuHolder, "menuHolder");

            EditableContainer.SetConstant<IMenuHolder, IMenuHolder>(menuHolder);
        }

        public static void RegisterAsyncStatusPresenter(IAsyncStatusPresenter asyncStatusPresenter)
        {
            CheckHelper.ArgumentNotNull(asyncStatusPresenter, "asyncStatusPresenter");

            EditableContainer.SetConstant<IAsyncStatusPresenter, IAsyncStatusPresenter>(asyncStatusPresenter);
        }

        private static IContainer CreateContainer()
        {
            var container = ContainerFactory.Create();

            Common.IoCRegistrator.RegisterSerializeService(container);
            Common.IoCRegistrator.RegisterValidateService(container);
            Common.IoCRegistrator.RegisterLocalizedNameService(container);
            Common.IoCRegistrator.RegisterTimeService(container);

            container.SetImplementation<IErrorService, ErrorService>(Lifetime.PerContainer);
            container.SetImplementation<IMenuService, MenuService>(Lifetime.PerContainer);
            container.SetImplementation<ISecurityService, SecurityService>(Lifetime.PerContainer);
            container.SetImplementation<IAsyncService, AsyncService>(Lifetime.PerContainer);
            container.SetImplementation<IFormService, FormService>(Lifetime.PerContainer);
            container.SetImplementation<IDictionaryService, DictionaryService>(Lifetime.PerContainer);
            container.SetImplementation<IImageService, ImageService>(Lifetime.PerContainer);
            container.SetImplementation<IProductService, ProductService>(Lifetime.PerContainer);
            container.SetImplementation<ILogService, LogService>(Lifetime.PerContainer);
            container.SetImplementation<IAdministrationService, AdministrationService>(Lifetime.PerContainer);
            container.SetImplementation<IDocumentService, DocumentService>(Lifetime.PerContainer);
            container.SetImplementation<IReportService, ReportService>(Lifetime.PerContainer);

            RegisterWebServiceReferences(container);

            return container;
        }

        private static void RegisterWebServiceReferences(IContainer container)
        {
            container.SetImplementation<SecurityAPIClient, SecurityAPIClient>();
            container.SetImplementation<DictionaryAPIClient, DictionaryAPIClient>();
            container.SetImplementation<ImageAPIClient, ImageAPIClient>();
            container.SetImplementation<ProductAPIClient, ProductAPIClient>();
            container.SetImplementation<LogAPIClient, LogAPIClient>();
            container.SetImplementation<AdministrationAPIClient, AdministrationAPIClient>();
            container.SetImplementation<DocumentAPIClient, DocumentAPIClient>();
            container.SetImplementation<ReportAPIClient, ReportAPIClient>();
        }
    }
}
