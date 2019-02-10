using System;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Win.Logic.Document
{
    public interface IDocumentService
    {
        Parcel[] GetParcels(DateTime startDate, DateTime endDate, string filter);
        string CreateParcel(Parcel parcel);
        string UpdateParcel(Parcel parcel);

        Order[] GetOrders(DateTime startDate, DateTime endDate, string filter);
        Order[] GetOrders(Parcel parcel, string filter);
        string CreateOrder(Order order);
        string UpdateOrder(Order order);

        OrderItem[] GetOrderItems(Order order);
        string CreateOrderItem(OrderItem orderItem);
        string UpdateOrderItem(OrderItem orderItem);

        DistributorTransfer[] GetDistributorTransfers(User distributor);
        string CreateDistributorTransfer(DistributorTransfer distributorTransfer);
        string UpdateDistributorTransfer(DistributorTransfer distributorTransfer);
    }
}
