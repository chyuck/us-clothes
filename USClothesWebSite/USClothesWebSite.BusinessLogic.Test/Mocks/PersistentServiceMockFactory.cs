using System.Linq;
using Moq;
using USClothesWebSite.BusinessLogic.Extensions;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.Test.Mocks
{
    public static class PersistentServiceMockFactory
    {
        public static Mock<IPersistentService> Create()
        {
            var persistentServiceMock = new Mock<IPersistentService>(MockBehavior.Strict);

            MockDataInitializer.Reset();
            MockDataInitializer.InitializeRelations();
            MockDataInitializer.InitializeCollections();

            persistentServiceMock.Setup(m => m.GetEntitySet<User>()).Returns(UserMockFactory.Users);
            persistentServiceMock.Setup(m => m.GetEntitySet<Role>()).Returns(RoleMockFactory.Roles);
            persistentServiceMock.Setup(m => m.GetEntitySet<UserRole>()).Returns(UserRoleMockFactory.UserRoles);
            persistentServiceMock.Setup(m => m.GetEntitySet<DataAccess.Category>()).Returns(CategoryMockFactory.Categories);
            persistentServiceMock.Setup(m => m.GetEntitySet<SubCategory>()).Returns(SubCategoryMockFactory.SubCategories);
            persistentServiceMock.Setup(m => m.GetEntitySet<DataAccess.Brand>()).Returns(BrandMockFactory.Brands);
            persistentServiceMock.Setup(m => m.GetEntitySet<DataAccess.Size>()).Returns(SizeMockFactory.Sizes);
            persistentServiceMock.Setup(m => m.GetEntitySet<DataAccess.ActionLog>()).Returns(ActionLogMockFactory.ActionLogs);
            persistentServiceMock.Setup(m => m.GetEntitySet<ActionLogType>()).Returns(ActionLogTypeMockFactory.ActionLogTypes);
            persistentServiceMock.Setup(m => m.GetEntitySet<DataAccess.Product>()).Returns(ProductMockFactory.Products);
            persistentServiceMock.Setup(m => m.GetEntitySet<DataAccess.ProductSize>()).Returns(ProductSizeMockFactory.ProductSizes);
            persistentServiceMock.Setup(m => m.GetEntitySet<DataAccess.Settings>()).Returns(SettingsMockFactory.Settings);
            persistentServiceMock.Setup(m => m.GetEntitySet<DataAccess.Parcel>()).Returns(ParcelMockFactory.Parcels);
            persistentServiceMock.Setup(m => m.GetEntitySet<DataAccess.Order>()).Returns(OrderMockFactory.Orders);
            persistentServiceMock.Setup(m => m.GetEntitySet<OrderItem>()).Returns(OrderItemMockFactory.OrderItems);
            persistentServiceMock.Setup(m => m.GetEntitySet<DataAccess.DistributorTransfer>()).Returns(DistributorTransferMockFactory.DistributorTransfers);

            persistentServiceMock.Setup(m => m.SaveChanges()).Callback(() => SaveChanges(persistentServiceMock.Object)).Returns(0);

            return persistentServiceMock;
        }

        private static void SaveChanges(IPersistentService persistentService)
        {
            SetIds<User>(persistentService);
            SetIds<Role>(persistentService);
            SetIds<UserRole>(persistentService);
            SetIds<DataAccess.Category>(persistentService);
            SetIds<SubCategory>(persistentService);
            SetIds<DataAccess.Brand>(persistentService);
            SetIds<DataAccess.Size>(persistentService);
            SetIds<DataAccess.ActionLog>(persistentService);
            SetIds<ActionLogType>(persistentService);
            SetIds<DataAccess.Product>(persistentService);
            SetIds<DataAccess.ProductSize>(persistentService);
            SetIds<DataAccess.Settings>(persistentService);
            SetIds<DataAccess.Parcel>(persistentService);
            SetIds<DataAccess.Order>(persistentService);
            SetIds<OrderItem>(persistentService);
            SetIds<DataAccess.DistributorTransfer>(persistentService);

            MockDataInitializer.InitializeCollections();
        }

        private static void SetIds<TEntity>(IPersistentService persistentService)
            where TEntity : class, IEntity, new()
        {
            var entities = persistentService.GetEntitySet<TEntity>().ToArray();
            var newEntities = entities.Where(e => e.IsNew()).ToArray();

            if (newEntities.Any())
            {
                var maxId = entities.Max(e => e.Id);

                foreach (var newEntity in newEntities)
                    newEntity.Id = ++maxId;
            }
        }
    }
}
