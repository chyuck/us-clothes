using System;
using USClothesWebSite.BusinessLogic.DistributorTransfer;
using USClothesWebSite.BusinessLogic.Order;
using USClothesWebSite.BusinessLogic.Parcel;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Web.WebServices
{
    public class DocumentAPI : BaseAPI, IDocumentAPI
    {
        #region Parcel

        public Parcel[] GetParcels(DateTime startDate, DateTime endDate, string filter)
        {
            return Container.Get<IParcelService>().GetParcels(startDate, endDate, filter);
        }

        public string CreateParcel(ref Parcel parcel)
        {
            Container.Get<IParcelService>().CreateParcel(parcel);

            return null;
        }

        public string UpdateParcel(Parcel parcel)
        {
            Container.Get<IParcelService>().UpdateParcel(parcel);

            return null;
        }

        #endregion


        #region Order

        public Order[] GetOrders(DateTime startDate, DateTime endDate, string filter)
        {
            return Container.Get<IOrderService>().GetOrders(startDate, endDate, filter);
        }

        public Order[] GetOrders(Parcel parcel, string filter)
        {
            return Container.Get<IOrderService>().GetOrdersByParcel(parcel, filter);
        }

        public string CreateOrder(ref Order order)
        {
            var o = order;

            return
                RunAndCatchException<OrderServiceException>(
                    () => Container.Get<IOrderService>().CreateOrder(o));
        }

        public string UpdateOrder(Order order)
        {
            return
                RunAndCatchException<OrderServiceException>(
                    () => Container.Get<IOrderService>().UpdateOrder(order));
        }

        #endregion


        #region Order Item

        public OrderItem[] GetOrderItems(Order order)
        {
            return Container.Get<IOrderService>().GetOrderItems(order);
        }

        public string CreateOrderItem(ref OrderItem orderItem)
        {
            var oi = orderItem;

            return
                RunAndCatchException<OrderServiceException>(
                    () => Container.Get<IOrderService>().CreateOrderItem(oi));
        }

        public string UpdateOrderItem(OrderItem orderItem)
        {
            return
                RunAndCatchException<OrderServiceException>(
                    () => Container.Get<IOrderService>().UpdateOrderItem(orderItem));
        }
        
        #endregion


        #region Distributor Transfer

        public DistributorTransfer[] GetDistributorTransfers(User distributor)
        {
            return Container.Get<IDistributorTransferService>().GetDistributorTransfers(distributor);
        }

        public string CreateDistributorTransfer(ref DistributorTransfer distributorTransfer)
        {
            Container.Get<IDistributorTransferService>().CreateDistributorTransfer(distributorTransfer);

            return null;
        }

        public string UpdateDistributorTransfer(DistributorTransfer distributorTransfer)
        {
            Container.Get<IDistributorTransferService>().UpdateDistributorTransfer(distributorTransfer);

            return null;
        } 

        #endregion
    }
}
