using System;

namespace USClothesWebSite.BusinessLogic.Dto
{
    internal interface IDtoService
    {
        DTO.Category CreateCategory(DataAccess.Category category, bool includeOnlyActive = true);
        DTO.SubCategory CreateSubCategory(DataAccess.SubCategory subCategory, bool includeOnlyActive = true);

        DTO.User CreateUser(DataAccess.User user, bool includeOnlyActive = true);
        DTO.Role CreateRole(DataAccess.Role role, bool includeOnlyActive = true);

        DTO.Size CreateSize(DataAccess.Size size, bool includeOnlyActive = true);
        DTO.Brand CreateBrand(DataAccess.Brand brand, bool includeOnlyActive = true);

        DTO.Product CreateProduct(DataAccess.Product product, bool includeOnlyActive = true);
        DTO.ProductSize CreateProductSize(DataAccess.ProductSize productSize, bool includeOnlyActive = true);

        DTO.Parcel CreateParcel(DataAccess.Parcel parcel, bool includeOnlyActive = false, Func<DataAccess.Order, bool> predicate = null);
        DTO.Order CreateOrder(DataAccess.Order order, bool includeOnlyActive = false, Func<DataAccess.Order, bool> predicate = null);
        DTO.OrderItem CreateOrderItem(DataAccess.OrderItem orderItem, bool includeOnlyActive = false, Func<DataAccess.Order, bool> predicate = null);

        DTO.Session CreateSession(DataAccess.Session session, bool includeOnlyActive = true);
        DTO.ShoppingCart CreateShoppingCart(DataAccess.ShoppingCart shoppingCart, bool includeOnlyActive = true);

        DTO.DistributorTransfer CreateDistributorTransfer(DataAccess.DistributorTransfer distributorTransfer, bool includeOnlyActive = true);

        DTO.ActionLogType CreateActionLogType(DataAccess.ActionLogType actionLogType);
        DTO.ActionLog CreateActionLog(DataAccess.ActionLog actionLog);

        DTO.Settings CreateSettings(DataAccess.Settings settings);
    }
}
