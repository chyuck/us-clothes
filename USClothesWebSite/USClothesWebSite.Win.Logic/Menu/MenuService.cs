using System.Windows.Forms;
using DepIC;
using DepIC.Attributes;
using USClothesWebSite.Common.Extensions;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services;
using USClothesWebSite.Win.Logic.Security;

namespace USClothesWebSite.Win.Logic.Menu
{
    internal class MenuService : BaseService, IMenuService
    {
        [Inject]
        public MenuService(IReadOnlyContainer container) 
            : base(container)
        {
        }

        public void SetUpMenu()
        {
            var menuHolder = Container.Get<IMenuHolder>();
            var securityService = Container.Get<ISecurityService>();

            SetupMenuItems(
                securityService.IsCurrentUserAdministrator,
                menuHolder.AdministrationMenuItem,
                menuHolder.LogsMenuItem,
                menuHolder.SettingsMenuItem);

            SetupMenuItems(
                securityService.IsCurrentUserAdministrator || 
                securityService.IsCurrentUserPurchaser || 
                securityService.IsCurrentUserDistributor ||
                securityService.IsCurrentUserSeller,
                menuHolder.SecurityMenuItem,
                menuHolder.CurrentUserMenuItem,
                menuHolder.ChangePasswordMenuItem);

            SetupMenuItems(
                securityService.IsCurrentUserSeller,
                menuHolder.DictionariesMenuItem,
                menuHolder.BrandsMenuItem,
                menuHolder.CategoriesMenuItem,
                menuHolder.SizesMenuItem,
                menuHolder.ProductsMenuItem);

            SetupMenuItems(
                securityService.IsCurrentUserPurchaser || 
                securityService.IsCurrentUserDistributor || 
                securityService.IsCurrentUserSeller,
                menuHolder.DocumentsMenuItem,
                menuHolder.OrdersMenuItem,
                menuHolder.ParcelsMenuItem,
                menuHolder.ReportsMenuItem,
                menuHolder.ParcelReportMenuItem);

            SetupMenuItems(
                securityService.IsCurrentUserPurchaser ||
                securityService.IsCurrentUserDistributor,
                menuHolder.DistributorTransfersMenuItem,
                menuHolder.DistributorReportMenuItem);

            SetupMenuItems(
                securityService.IsCurrentUserAdministrator ||
                securityService.IsCurrentUserPurchaser,
                menuHolder.UsersMenuItem);
        }

        private void SetupMenuItems(bool isEnabled, params ToolStripMenuItem[] menuItems)
        {
            CheckHelper.ArgumentNotNull(menuItems, "menuItems");

            menuItems.ForEach(mi => mi.Enabled = isEnabled);
        }
    }
}
