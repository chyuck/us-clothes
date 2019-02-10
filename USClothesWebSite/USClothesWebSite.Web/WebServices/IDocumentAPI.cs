using System;
using System.ServiceModel;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Web.WebServices
{
    [ServiceContract(Namespace = "http://usclothes.ru/webservice/documentapi")]
    public interface IDocumentAPI
    {
        #region Parcel

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        Parcel[] GetParcels(DateTime startDate, DateTime endDate, string filter);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string CreateParcel(ref Parcel parcel);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string UpdateParcel(Parcel parcel);

        #endregion


        #region Order

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        Order[] GetOrders(DateTime startDate, DateTime endDate, string filter);

        [OperationContract(Name = "GetOrdersByParcel")]
        [FaultContract(typeof(ErrorData))]
        Order[] GetOrders(Parcel parcel, string filter);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string CreateOrder(ref Order order);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string UpdateOrder(Order order);

        #endregion


        #region Order Item

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        OrderItem[] GetOrderItems(Order order);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string CreateOrderItem(ref OrderItem orderItem);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string UpdateOrderItem(OrderItem orderItem);

        #endregion


        #region Distributor Transfer

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        DistributorTransfer[] GetDistributorTransfers(User distributor);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string CreateDistributorTransfer(ref DistributorTransfer distributorTransfer);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string UpdateDistributorTransfer(DistributorTransfer distributorTransfer);

        #endregion
    }
}
