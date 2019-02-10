using System;

namespace USClothesWebSite.BusinessLogic.Order
{
    public interface IOrderService
    {
        DTO.Order[] GetOrders(DateTime startDate, DateTime endDate, string filter);
        DTO.Order[] GetOrdersByParcel(DTO.Parcel parcel, string filter);
        DTO.OrderItem[] GetOrderItems(DTO.Order order);

        void CreateOrder(DTO.Order createdOrder);
        void UpdateOrder(DTO.Order updatedOrder);

        void CreateOrderItem(DTO.OrderItem createdOrderItem);
        void UpdateOrderItem(DTO.OrderItem updatedOrderItem);
    }
}
