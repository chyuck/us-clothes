using USClothesWebSite.DTO;
using USClothesWebSite.Win.Forms.Administration;
using USClothesWebSite.Win.Forms.Dictionary;
using USClothesWebSite.Win.Forms.Document;
using USClothesWebSite.Win.Forms.Product;
using USClothesWebSite.Win.Forms.Report;
using USClothesWebSite.Win.Forms.Security;
using USClothesWebSite.Win.Logic;
using USClothesWebSite.Win.Logic.Form;

namespace USClothesWebSite.Win.Helpers
{
    public static class FormRegistrationHelper
    {
        public static void Register()
        {
            var formService = IoC.Container.Get<IFormService>();

            formService.RegisterEditForm<User, UserEditForm>();
            formService.RegisterListForm<User, UserListForm>();

            formService.RegisterEditForm<Brand, BrandEditForm>();
            formService.RegisterListForm<Brand, BrandListForm>();

            formService.RegisterEditForm<Category, CategoryEditForm>();
            formService.RegisterListForm<Category, CategoryMasterDetailForm>();

            formService.RegisterEditForm<SubCategory, SubCategoryEditForm>();
            formService.RegisterListForm<SubCategory, SubCategoryListForm>();

            formService.RegisterEditForm<Size, SizeEditForm>();
            formService.RegisterListForm<Size, SizeListForm>();

            formService.RegisterEditForm<Product, ProductEditForm>();
            formService.RegisterListForm<Product, ProductMasterDetailForm>();

            formService.RegisterEditForm<ProductSize, ProductSizeEditForm>();
            formService.RegisterListForm<ProductSize, ProductSizeListForm>();

            formService.RegisterEditForm<ActionLog, LogEditForm>();
            formService.RegisterListForm<ActionLog, LogListForm>();

            formService.RegisterEditForm<Settings, SettingsEditForm>();

            formService.RegisterListForm<Parcel, ParcelMasterDetailForm>();
            formService.RegisterEditForm<Parcel, ParcelEditForm>();

            formService.RegisterListForm<Order, OrderMasterDetailForm>();
            formService.RegisterEditForm<Order, OrderEditForm>();
            formService.RegisterEditForm<OrderItem, OrderItemEditForm>();

            formService.RegisterListForm<DistributorTransfer, DistributorTransferListForm>();
            formService.RegisterEditForm<DistributorTransfer, DistributorTransferEditForm>();

            formService.RegisterListForm<ParcelReportItem, ParcelReportListForm>();
            formService.RegisterEditForm<ParcelReportItem, ParcelReportEditForm>();

            formService.RegisterListForm<DistributorReportItem, DistributorReportListForm>();
            formService.RegisterEditForm<DistributorReportItem, DistributorReportEditForm>();
        }
    }
}
