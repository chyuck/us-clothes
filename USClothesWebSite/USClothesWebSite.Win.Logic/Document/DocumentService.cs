using System;
using DepIC;
using DepIC.Attributes;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services;
using USClothesWebSite.Common.Services.Validate;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Logic.DocumentAPI;
using USClothesWebSite.Win.Logic.Helpers;
using USClothesWebSite.Win.Logic.Security;

namespace USClothesWebSite.Win.Logic.Document
{
    internal class DocumentService : BaseService, IDocumentService
    {
        [Inject]
        public DocumentService(IReadOnlyContainer container) 
            : base(container)
        {
        }

        private ISecurityService SecurityService
        {
            get { return Container.Get<ISecurityService>(); }
        }

        #region Parcel

        public Parcel[] GetParcels(DateTime startDate, DateTime endDate, string filter)
        {
            CheckHelper.ArgumentWithinCondition(startDate <= endDate, "startDate <= endDate");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            return APIClientHelper<DocumentAPIClient>.Call(c => c.GetParcels(startDate, endDate, filter));
        }

        public string CreateParcel(Parcel parcel)
        {
            CheckHelper.ArgumentNotNull(parcel, "parcel");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            var errors = IoC.Container.Get<IValidateService>().Validate(parcel);
            if (errors != null)
                return errors.ToErrorMessage();

            var createdParcel = (Parcel)parcel.Clone();

            var errorMessage = APIClientHelper<DocumentAPIClient>.Call(c => c.CreateParcel(ref createdParcel));

            parcel.Id = createdParcel.Id;

            return errorMessage;
        }

        public string UpdateParcel(Parcel parcel)
        {
            CheckHelper.ArgumentNotNull(parcel, "parcel");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            var errors = IoC.Container.Get<IValidateService>().Validate(parcel);
            if (errors != null)
                return errors.ToErrorMessage();

            return APIClientHelper<DocumentAPIClient>.Call(c => c.UpdateParcel(parcel));
        }

        #endregion


        #region Order

        public Order[] GetOrders(DateTime startDate, DateTime endDate, string filter)
        {
            CheckHelper.ArgumentWithinCondition(startDate <= endDate, "startDate <= endDate");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            return APIClientHelper<DocumentAPIClient>.Call(c => c.GetOrders(startDate, endDate, filter));
        }

        public Order[] GetOrders(Parcel parcel, string filter)
        {
            CheckHelper.ArgumentNotNull(parcel, "parcel");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            return APIClientHelper<DocumentAPIClient>.Call(c => c.GetOrdersByParcel(parcel, filter));
        }

        public string CreateOrder(Order order)
        {
            CheckHelper.ArgumentNotNull(order, "order");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            var errors = IoC.Container.Get<IValidateService>().Validate(order);
            if (errors != null)
                return errors.ToErrorMessage();

            var createdOrder = (Order)order.Clone();

            var errorMessage = APIClientHelper<DocumentAPIClient>.Call(c => c.CreateOrder(ref createdOrder));

            order.Id = createdOrder.Id;

            return errorMessage;
        }

        public string UpdateOrder(Order order)
        {
            CheckHelper.ArgumentNotNull(order, "order");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            var errors = IoC.Container.Get<IValidateService>().Validate(order);
            if (errors != null)
                return errors.ToErrorMessage();

            return APIClientHelper<DocumentAPIClient>.Call(c => c.UpdateOrder(order));
        }

        #endregion


        #region Order Item

        public OrderItem[] GetOrderItems(Order order)
        {
            CheckHelper.ArgumentNotNull(order, "order");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            return APIClientHelper<DocumentAPIClient>.Call(c => c.GetOrderItems(order));
        }

        public string CreateOrderItem(OrderItem orderItem)
        {
            CheckHelper.ArgumentNotNull(orderItem, "orderItem");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            var errors = IoC.Container.Get<IValidateService>().Validate(orderItem);
            if (errors != null)
                return errors.ToErrorMessage();

            var createdOrderItem = (OrderItem)orderItem.Clone();

            var errorMessage = APIClientHelper<DocumentAPIClient>.Call(c => c.CreateOrderItem(ref createdOrderItem));

            orderItem.Id = createdOrderItem.Id;

            return errorMessage;
        }

        public string UpdateOrderItem(OrderItem orderItem)
        {
            CheckHelper.ArgumentNotNull(orderItem, "orderItem");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            var errors = IoC.Container.Get<IValidateService>().Validate(orderItem);
            if (errors != null)
                return errors.ToErrorMessage();

            return APIClientHelper<DocumentAPIClient>.Call(c => c.UpdateOrderItem(orderItem));
        }

        #endregion


        #region Distributor Transfer

        public DistributorTransfer[] GetDistributorTransfers(User distributor)
        {
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            return APIClientHelper<DocumentAPIClient>.Call(c => c.GetDistributorTransfers(distributor));
        }

        public string CreateDistributorTransfer(DistributorTransfer distributorTransfer)
        {
            CheckHelper.ArgumentNotNull(distributorTransfer, "distributorTransfer");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            var errors = IoC.Container.Get<IValidateService>().Validate(distributorTransfer);
            if (errors != null)
                return errors.ToErrorMessage();

            var createdDistributorTransfer = (DistributorTransfer)distributorTransfer.Clone();

            var errorMessage = APIClientHelper<DocumentAPIClient>.Call(c => c.CreateDistributorTransfer(ref createdDistributorTransfer));

            distributorTransfer.Id = createdDistributorTransfer.Id;

            return errorMessage;
        }

        public string UpdateDistributorTransfer(DistributorTransfer distributorTransfer)
        {
            CheckHelper.ArgumentNotNull(distributorTransfer, "distributorTransfer");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            var errors = IoC.Container.Get<IValidateService>().Validate(distributorTransfer);
            if (errors != null)
                return errors.ToErrorMessage();

            return APIClientHelper<DocumentAPIClient>.Call(c => c.UpdateDistributorTransfer(distributorTransfer));
        } 

        #endregion
    }
}
