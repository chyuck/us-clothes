using USClothesWebSite.DTO;

namespace USClothesWebSite.Win.Logic.Extensions
{
    public static class OrderItemExtensions
    {
        public static bool IsCurrentUserSellerForOrderItem(this OrderItem orderItem)
        {
            return
                orderItem != null &&
                orderItem.Order.IsCurrentUserSellerForOrder();
        }
    }
}
