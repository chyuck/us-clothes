using DepIC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.BusinessLogic.Test.Mocks;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.Test
{
    [TestClass]
    [Ignore]
    public class DatabaseGenerateTest
    {
        [TestMethod]
        public void Insert_Mock_Data_Into_Database()
        {
            using (var container = ContainerFactory.Create())
            {
                IoCRegistrator.Register(container);

                using (var persistentService = container.Get<IPersistentService>())
                {
                    #region User

                    UserMockFactory.InitializeRelations();
                    var users =
                        new[]
                        {
                            UserMockFactory.Jenya,
                            UserMockFactory.Olesya,
                            UserMockFactory.Diana
                        };

                    foreach (var user in users)
                    {
                        var entitySet = persistentService.GetEntitySet<User>();

                        user.Id = 0;
                        user.CreatedBy = null;
                        user.ChangedBy = null;
                        user.ChangeUserId = 1;
                        user.PasswordHash = "7FD968BDC1BF0C55CFEC23DE9DE0145E";
                        user.PasswordSalt = "1B8A40A0C5C7309A457830A7045D1802";

                        entitySet.Add(user);
                        persistentService.SaveChanges();
                    }

                    #endregion
                    
                    #region UserRole
                    
                    UserRoleMockFactory.InitializeRelations();
                    var userRoles =
                        new[]
                        {
                            UserRoleMockFactory.JenyaAdministrator,
                            UserRoleMockFactory.JenyaPurchaser,
                            UserRoleMockFactory.JenyaDistributor,
                            UserRoleMockFactory.JenyaSeller,
                            UserRoleMockFactory.OlesyaAdministrator,
                            UserRoleMockFactory.OlesyaPurchaser,
                            UserRoleMockFactory.OlesyaDistributor,
                            UserRoleMockFactory.OlesyaSeller,
                            UserRoleMockFactory.DianaAdministrator,
                            UserRoleMockFactory.DianaPurchaser,
                            UserRoleMockFactory.DianaDistributor,
                            UserRoleMockFactory.DianaSeller
                        };

                    foreach (var userRole in userRoles)
                    {
                        var entitySet = persistentService.GetEntitySet<UserRole>();

                        userRole.Id = 0;
                        userRole.CreatedBy = null;
                        userRole.ChangedBy = null;
                        userRole.User = null;
                        userRole.Role = null;

                        entitySet.Add(userRole);
                        persistentService.SaveChanges();
                    }

                    #endregion

                    #region Category

                    CategoryMockFactory.InitializeRelations();
                    foreach (var category in CategoryMockFactory.Categories)
                    {
                        var entitySet = persistentService.GetEntitySet<DataAccess.Category>();
                        category.Id = 0;
                        category.CreatedBy = null;
                        category.ChangedBy = null;

                        entitySet.Add(category);
                        persistentService.SaveChanges();
                    }
                    
                    #endregion

                    #region SubCategory

                    SubCategoryMockFactory.InitializeRelations();
                    foreach (var subCategory in SubCategoryMockFactory.SubCategories)
                    {
                        var entitySet = persistentService.GetEntitySet<SubCategory>();
                        subCategory.Id = 0;
                        subCategory.CreatedBy = null;
                        subCategory.ChangedBy = null;
                        subCategory.Category = null;

                        entitySet.Add(subCategory);
                        persistentService.SaveChanges();
                    }

                    #endregion

                    #region Brand

                    BrandMockFactory.InitializeRelations();
                    foreach (var brand in BrandMockFactory.Brands)
                    {
                        var entitySet = persistentService.GetEntitySet<DataAccess.Brand>();
                        brand.Id = 0;
                        brand.CreatedBy = null;
                        brand.ChangedBy = null;

                        entitySet.Add(brand);
                        persistentService.SaveChanges();
                    }

                    #endregion

                    #region Size

                    SizeMockFactory.InitializeRelations();
                    foreach (var size in SizeMockFactory.Sizes)
                    {
                        var entitySet = persistentService.GetEntitySet<DataAccess.Size>();
                        size.Id = 0;
                        size.CreatedBy = null;
                        size.ChangedBy = null;
                        size.Brand = null;
                        size.SubCategory = null;

                        entitySet.Add(size);
                        persistentService.SaveChanges();
                    }

                    #endregion

                    #region ActionLog

                    ActionLogMockFactory.InitializeRelations();
                    foreach (var actionLog in ActionLogMockFactory.ActionLogs)
                    {
                        var entitySet = persistentService.GetEntitySet<DataAccess.ActionLog>();
                        actionLog.Id = 0;
                        actionLog.ActionLogType = null;
                        actionLog.CreateUser = null;

                        entitySet.Add(actionLog);
                        persistentService.SaveChanges();
                    }

                    #endregion

                    #region Product

                    ProductMockFactory.InitializeRelations();
                    foreach (var product in ProductMockFactory.Products)
                    {
                        var entitySet = persistentService.GetEntitySet<DataAccess.Product>();
                        product.Id = 0;
                        product.CreatedBy = null;
                        product.ChangedBy = null;
                        product.Brand = null;
                        product.SubCategory = null;

                        entitySet.Add(product);
                        persistentService.SaveChanges();
                    }

                    #endregion
                    
                    #region ProductSize

                    ProductSizeMockFactory.InitializeRelations();
                    foreach (var productSize in ProductSizeMockFactory.ProductSizes)
                    {
                        var entitySet = persistentService.GetEntitySet<DataAccess.ProductSize>();
                        productSize.Id = 0;
                        productSize.CreatedBy = null;
                        productSize.ChangedBy = null;
                        productSize.Product = null;
                        productSize.Size = null;

                        entitySet.Add(productSize);
                        persistentService.SaveChanges();
                    }

                    #endregion

                    #region Parcel

                    ParcelMockFactory.InitializeRelations();
                    foreach (var parcel in ParcelMockFactory.Parcels)
                    {
                        var entitySet = persistentService.GetEntitySet<DataAccess.Parcel>();
                        parcel.Id = 0;
                        parcel.CreatedBy = null;
                        parcel.ChangedBy = null;
                        parcel.Distributor = null;

                        entitySet.Add(parcel);
                        persistentService.SaveChanges();
                    }

                    #endregion

                    #region Order

                    OrderMockFactory.InitializeRelations();
                    foreach (var order in OrderMockFactory.Orders)
                    {
                        var entitySet = persistentService.GetEntitySet<DataAccess.Order>();
                        order.Id = 0;
                        order.CreatedBy = null;
                        order.ChangedBy = null;
                        order.Parcel = null;

                        entitySet.Add(order);
                        persistentService.SaveChanges();
                    }

                    #endregion

                    #region OrderItem

                    OrderItemMockFactory.InitializeRelations();
                    foreach (var orderItem in OrderItemMockFactory.OrderItems)
                    {
                        var entitySet = persistentService.GetEntitySet<OrderItem>();
                        orderItem.Id = 0;
                        orderItem.CreatedBy = null;
                        orderItem.ChangedBy = null;
                        orderItem.Order = null;

                        entitySet.Add(orderItem);
                        persistentService.SaveChanges();
                    }

                    #endregion


                    #region DistributorTransfer

                    DistributorTransferMockFactory.InitializeRelations();
                    foreach (var distributorTransfer in DistributorTransferMockFactory.DistributorTransfers)
                    {
                        var entitySet = persistentService.GetEntitySet<DataAccess.DistributorTransfer>();
                        distributorTransfer.Id = 0;
                        distributorTransfer.CreatedBy = null;
                        distributorTransfer.ChangedBy = null;

                        entitySet.Add(distributorTransfer);
                        persistentService.SaveChanges();
                    }

                    #endregion
                }
            }
        }
    }
}
