using System;
using System.Linq;
using DepIC;
using DepIC.Attributes;
using USClothesWebSite.BusinessLogic.Dto;
using USClothesWebSite.BusinessLogic.Extensions;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services;
using USClothesWebSite.Common.Services.Validate;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.Order
{
    internal class OrderService : BaseService, IOrderService
    {
        #region Constructors

        [Inject]
        public OrderService(IReadOnlyContainer container) 
            : base(container)
        {
        }

        #endregion


        #region Properties

        private ISecurityService SecurityService
        {
            get { return Container.Get<ISecurityService>(); }
        }

        #endregion


        #region Private Methods

        private static void ApplyOrderFilterCondition(ref IQueryable<DataAccess.Order> query, string filter)
        {
            if (!string.IsNullOrWhiteSpace(filter))
            {
                if (filter.StartsWith("ID:"))
                {
                    var idString = filter.Replace("ID:", string.Empty).Trim();
                    int id;
                    if (int.TryParse(idString, out id))
                    {
                        query = query.Where(o => o.Id == id);
                        return;
                    }
                }       

                query =
                    query
                        .Where(o =>
                               o.CustomerFirstName.Contains(filter) ||
                               o.CustomerLastName.Contains(filter) ||
                               o.CustomerAddress.Contains(filter) ||
                               o.CustomerCity.Contains(filter) ||
                               o.CustomerCountry.Contains(filter) ||
                               o.CustomerPostalCode.Contains(filter) ||
                               o.CustomerPhoneNumber.Contains(filter) ||
                               o.CustomerEmail.Contains(filter) ||
                               (o.Comments != null && o.Comments.Contains(filter)) ||
                               (o.TrackingNumber != null && o.TrackingNumber.Contains(filter)));
            }
        }

        private void UpdateParcel(DataAccess.Order order, DTO.Parcel parcel)
        {
            CheckHelper.ArgumentNotNull(order, "order");

            if (parcel != null)
            {
                var parcelId = parcel.Id;
                CheckHelper.WithinCondition(parcelId > 0, "Parcel is new.");

                var persistentService = Container.Get<IPersistentService>();

                var p = persistentService.GetEntityById<DataAccess.Parcel>(parcelId);
                CheckHelper.NotNull(p, "Parcel user does not exist.");
                
                order.ParcelId = p.Id;
                order.Parcel = p;
            }
            else
            {
                order.ParcelId = null;
                order.Parcel = null;
            }
        }

        private void UpdateOrder(OrderItem orderItem, DTO.Order order)
        {
            CheckHelper.ArgumentNotNull(orderItem, "orderItem");
            CheckHelper.ArgumentNotNull(order, "order");

            var orderId = order.Id;
            CheckHelper.WithinCondition(orderId > 0, "Order is new.");

            var persistentService = Container.Get<IPersistentService>();

            var o = persistentService.GetEntityById<DataAccess.Order>(orderId);
            CheckHelper.NotNull(o, "Order user does not exist.");

            orderItem.OrderId = o.Id;
            orderItem.Order = o;
        }

        private void UpdateProductSize(OrderItem orderItem, DTO.ProductSize productSize)
        {
            CheckHelper.ArgumentNotNull(orderItem, "orderItem");
            CheckHelper.ArgumentNotNull(productSize, "productSize");

            var productSizeId = productSize.Id;
            CheckHelper.WithinCondition(productSizeId > 0, "Product size is new.");

            var persistentService = Container.Get<IPersistentService>();

            var ps = persistentService.GetEntityById<DataAccess.ProductSize>(productSizeId);
            CheckHelper.NotNull(ps, "Product size user does not exist.");

            orderItem.ProductSizeId = ps.Id;
            orderItem.ProductSize = ps;
        }

        private bool IsCurrentUserDistributorForOrder(DataAccess.Order order)
        {
            CheckHelper.ArgumentNotNull(order, "order");

            return
                SecurityService.IsCurrentUserDistributor && 
                order.Parcel != null && 
                order.Parcel.DistributorId.HasValue &&
                order.Parcel.DistributorId == SecurityService.CurrentUser.Id;
        }

        private bool IsCurrentUserSellerForOrder(DataAccess.Order order)
        {
            CheckHelper.ArgumentNotNull(order, "order");

            return
                SecurityService.IsCurrentUserSeller && 
                order.CreatedBy.Id == SecurityService.CurrentUser.Id;
        }

        #endregion


        #region IOrderService
        
        public DTO.Order[] GetOrders(DateTime startDate, DateTime endDate, string filter)
        {
            CheckHelper.ArgumentWithinCondition(startDate <= endDate, "startDate <= endDate");

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(
                SecurityService.IsCurrentUserSeller ||
                SecurityService.IsCurrentUserPurchaser ||
                SecurityService.IsCurrentUserDistributor,
                "Only seller, purchaser and distributor can get all orders.");

            var query =
                Container
                    .Get<IPersistentService>()
                    .GetEntitySet<DataAccess.Order>()
                    .Where(o =>
                        (startDate <= o.CreateDate && o.CreateDate <= endDate) ||
                        (startDate <= o.ChangeDate && o.ChangeDate <= endDate) ||
                        (startDate <= o.OrderDate && o.OrderDate <= endDate));

            ApplyOrderFilterCondition(ref query, filter);

            if (!SecurityService.IsCurrentUserPurchaser)
            {
                var currentUserId = SecurityService.CurrentUser.Id;

                if (SecurityService.IsCurrentUserSeller && SecurityService.IsCurrentUserDistributor)
                {
                    query =
                        query
                            .Where(o =>
                                (o.Parcel != null && o.Parcel.DistributorId != null && o.Parcel.DistributorId == currentUserId)
                                ||
                                o.CreateUserId == currentUserId);
                }
                else if (SecurityService.IsCurrentUserSeller)
                {
                    query =
                        query
                            .Where(o => o.CreateUserId == currentUserId);
                }
                else if (SecurityService.IsCurrentUserDistributor)
                {
                    query =
                        query
                            .Where(o => o.Parcel != null && o.Parcel.DistributorId != null && o.Parcel.DistributorId == currentUserId);
                }
            }

            var dtoService = Container.Get<IDtoService>();

            var predicate =
                SecurityService.IsCurrentUserSeller && !SecurityService.IsCurrentUserPurchaser && !SecurityService.IsCurrentUserDistributor
                    ? o => o.CreateUserId == SecurityService.CurrentUser.Id
                    : (Func<DataAccess.Order, bool>)null;

            return
                query
                    .OrderBy(o => o.Id)
                    .AsEnumerable()
                    .Select(o => dtoService.CreateOrder(o, false, predicate))
                    .ToArray();
        }

        public DTO.Order[] GetOrdersByParcel(DTO.Parcel parcel, string filter)
        {
            CheckHelper.ArgumentNotNull(parcel, "parcel");
            CheckHelper.ArgumentWithinCondition(!parcel.IsNew(), "Parcel is new.");

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(
                SecurityService.IsCurrentUserSeller ||
                SecurityService.IsCurrentUserPurchaser ||
                SecurityService.IsCurrentUserDistributor,
                "Only seller, purchaser and distributor can get all orders.");

            var parcelId = parcel.Id;

            var currentParcel =
                Container
                    .Get<IPersistentService>()
                    .GetEntityById<DataAccess.Parcel>(parcelId);
            CheckHelper.NotNull(currentParcel, "Parcel does not exist.");

            var currentUserId = SecurityService.CurrentUser.Id;

            CheckHelper.WithinCondition(
                SecurityService.IsCurrentUserPurchaser ||
                (SecurityService.IsCurrentUserDistributor && currentParcel.Distributor != null && currentParcel.DistributorId == currentUserId) ||
                (SecurityService.IsCurrentUserSeller && currentParcel.Orders.Any(o => o.CreateUserId == currentUserId)),
                "Current user is either distributor and parcel is not assigned to him or seller and parcel does not have any order created by him.");

            var query =
                Container
                    .Get<IPersistentService>()
                    .GetEntitySet<DataAccess.Order>()
                    .Where(o => o.Parcel != null && o.ParcelId == parcelId);

            ApplyOrderFilterCondition(ref query, filter);

            Func<DataAccess.Order, bool> predicate = null;

            if (SecurityService.IsCurrentUserSeller &&
                !SecurityService.IsCurrentUserPurchaser && 
                !(SecurityService.IsCurrentUserDistributor && currentParcel.Distributor != null && currentParcel.DistributorId == currentUserId))
            {
                query = query.Where(o => o.CreateUserId == currentUserId);
                
                predicate = o => o.CreateUserId == currentUserId;
            }

            var dtoService = Container.Get<IDtoService>();

            return
                query
                    .OrderBy(o => o.Id)
                    .AsEnumerable()
                    .Select(o => dtoService.CreateOrder(o, false, predicate))
                    .ToArray();
        }

        public DTO.OrderItem[] GetOrderItems(DTO.Order order)
        {
            CheckHelper.ArgumentNotNull(order, "order");
            CheckHelper.ArgumentWithinCondition(!order.IsNew(), "Order is new.");

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(
                SecurityService.IsCurrentUserSeller ||
                SecurityService.IsCurrentUserPurchaser ||
                SecurityService.IsCurrentUserDistributor,
                "Only seller, purchaser and distributor can get all order items.");

            var orderId = order.Id;

            var currentOrder =
                Container
                    .Get<IPersistentService>()
                    .GetEntityById<DataAccess.Order>(orderId);
            CheckHelper.NotNull(currentOrder, "Order does not exist.");

            var currentParcel = currentOrder.Parcel;
            
            var currentUserId = SecurityService.CurrentUser.Id;

            CheckHelper.WithinCondition(
                SecurityService.IsCurrentUserPurchaser ||
                (SecurityService.IsCurrentUserDistributor && currentParcel != null && currentParcel.Distributor != null && currentParcel.DistributorId == currentUserId) ||
                (SecurityService.IsCurrentUserSeller && currentOrder.CreateUserId == currentUserId),
                "Current user is either distributor and order is not included in parcel assigned to him or seller and order is not created by him.");

            var dtoService = Container.Get<IDtoService>();

            Func<DataAccess.Order, bool> predicate = null;

            if (SecurityService.IsCurrentUserSeller &&
                !SecurityService.IsCurrentUserPurchaser &&
                !(SecurityService.IsCurrentUserDistributor && currentParcel != null && currentParcel.Distributor != null && currentParcel.DistributorId == currentUserId))
            {
                predicate = o => o.CreateUserId == currentUserId;
            }

            return 
                Container
                    .Get<IPersistentService>()
                    .GetEntitySet<OrderItem>()
                    .Where(oi => oi.OrderId == orderId)
                    .OrderBy(oi => oi.Id)
                    .AsEnumerable()
                    .Select(oi => dtoService.CreateOrderItem(oi, false, predicate))
                    .ToArray();
        }

        public void CreateOrder(DTO.Order createdOrder)
        {
            CheckHelper.ArgumentNotNull(createdOrder, "createdOrder");
            CheckHelper.ArgumentWithinCondition(createdOrder.IsNew(), "Order is not new.");
            Container.Get<IValidateService>().CheckIsValid(createdOrder);

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can create order.");

            var persistentService = Container.Get<IPersistentService>();

            var order =
                new DataAccess.Order
                {
                    OrderDate = createdOrder.OrderDate,
                    CustomerFirstName = createdOrder.CustomerFirstName,
                    CustomerLastName = createdOrder.CustomerLastName,
                    CustomerAddress = createdOrder.CustomerAddress,
                    CustomerCity = createdOrder.CustomerCity,
                    CustomerCountry = createdOrder.CustomerCountry,
                    CustomerPostalCode = createdOrder.CustomerPostalCode,
                    CustomerPhoneNumber = createdOrder.CustomerPhoneNumber,
                    CustomerEmail = createdOrder.CustomerEmail,
                    Active = createdOrder.Active,
                    Comments = createdOrder.Comments,
                    RublesPerDollar = createdOrder.RublesPerDollar,
                    CustomerPrepaid = createdOrder.CustomerPrepaid,
                    CustomerPaid = createdOrder.CustomerPaid
                };
            order.UpdateTrackFields(Container);

            persistentService.Add(order);
            persistentService.SaveChanges();

            createdOrder.Id = order.Id;
            createdOrder.CreateDate = order.CreateDate;
            createdOrder.CreateUser = order.CreatedBy.GetFullName();
            createdOrder.ChangeDate = order.ChangeDate;
            createdOrder.ChangeUser = order.ChangedBy.GetFullName();

            createdOrder.Parcel = null;
            createdOrder.DistributorSpentOnDelivery = 0m;
            createdOrder.TrackingNumber = null;
        }

        public void UpdateOrder(DTO.Order updatedOrder)
        {
            CheckHelper.ArgumentNotNull(updatedOrder, "updatedOrder");
            CheckHelper.ArgumentWithinCondition(!updatedOrder.IsNew(), "Order is new.");
            Container.Get<IValidateService>().CheckIsValid(updatedOrder);

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(
                SecurityService.IsCurrentUserSeller ||
                SecurityService.IsCurrentUserPurchaser ||
                SecurityService.IsCurrentUserDistributor,
                "Only seller, purchaser and distributor can change order.");

            var persistentService = Container.Get<IPersistentService>();

            var order = persistentService.GetEntityById<DataAccess.Order>(updatedOrder.Id);
            CheckHelper.NotNull(order, "Order does not exist.");
            CheckHelper.WithinCondition(
                SecurityService.IsCurrentUserPurchaser ||
                IsCurrentUserDistributorForOrder(order) ||
                IsCurrentUserSellerForOrder(order),
                "Only seller, purchaser and distributor can change order.");

            if (IsCurrentUserDistributorForOrder(order))
            {
                order.DistributorSpentOnDelivery = updatedOrder.DistributorSpentOnDelivery;
                order.TrackingNumber = updatedOrder.TrackingNumber;
            }
            else
            {
                updatedOrder.DistributorSpentOnDelivery = order.DistributorSpentOnDelivery;
                updatedOrder.TrackingNumber = order.TrackingNumber;
            }

            if (IsCurrentUserSellerForOrder(order))
            {
                order.OrderDate = updatedOrder.OrderDate;
                order.CustomerFirstName = updatedOrder.CustomerFirstName;
                order.CustomerLastName = updatedOrder.CustomerLastName;
                order.CustomerAddress = updatedOrder.CustomerAddress;
                order.CustomerCity = updatedOrder.CustomerCity;
                order.CustomerCountry = updatedOrder.CustomerCountry;
                order.CustomerPostalCode = updatedOrder.CustomerPostalCode;
                order.CustomerPhoneNumber = updatedOrder.CustomerPhoneNumber;
                order.CustomerEmail = updatedOrder.CustomerEmail;
                order.Active = updatedOrder.Active;
                order.Comments = updatedOrder.Comments;
                order.RublesPerDollar = updatedOrder.RublesPerDollar;
                order.CustomerPrepaid = updatedOrder.CustomerPrepaid;
                order.CustomerPaid = updatedOrder.CustomerPaid;
            }
            else
            {
                updatedOrder.OrderDate = order.OrderDate;
                updatedOrder.CustomerFirstName = order.CustomerFirstName;
                updatedOrder.CustomerLastName = order.CustomerLastName;
                updatedOrder.CustomerAddress = order.CustomerAddress;
                updatedOrder.CustomerCity = order.CustomerCity;
                updatedOrder.CustomerCountry = order.CustomerCountry;
                updatedOrder.CustomerPostalCode = order.CustomerPostalCode;
                updatedOrder.CustomerPhoneNumber = order.CustomerPhoneNumber;
                updatedOrder.CustomerEmail = order.CustomerEmail;
                updatedOrder.Active = order.Active;
                updatedOrder.Comments = order.Comments;
                updatedOrder.RublesPerDollar = order.RublesPerDollar;
                updatedOrder.CustomerPrepaid = order.CustomerPrepaid;
                updatedOrder.CustomerPaid = order.CustomerPaid;
            }

            if (SecurityService.IsCurrentUserPurchaser)
            {
                UpdateParcel(order, updatedOrder.Parcel);
            }
            else
            {
                updatedOrder.Parcel =
                    order.Parcel  == null
                        ? null
                        : Container.Get<IDtoService>().CreateParcel(order.Parcel);
            }
            
            order.UpdateTrackFields(Container);

            persistentService.SaveChanges();
        }

        public void CreateOrderItem(DTO.OrderItem createdOrderItem)
        {
            CheckHelper.ArgumentNotNull(createdOrderItem, "createdOrderItem");
            CheckHelper.ArgumentWithinCondition(createdOrderItem.IsNew(), "Order item is not new.");
            Container.Get<IValidateService>().CheckIsValid(createdOrderItem);

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can create order item.");

            var persistentService = Container.Get<IPersistentService>();

            var order = persistentService.GetEntityById<DataAccess.Order>(createdOrderItem.Order.Id);
            CheckHelper.NotNull(order, "Order does not exist");
            
            CheckHelper.WithinCondition(order.CreatedBy.Id == SecurityService.CurrentUser.Id, "Order is created by another seller.");

            var doesAnotherOrderItemWithTheSameProductSizeExist =
                persistentService
                    .GetEntitySet<OrderItem>()
                    .Any(oi => 
                        oi.OrderId == order.Id && 
                        oi.ProductSizeId == createdOrderItem.ProductSize.Id);
            if (doesAnotherOrderItemWithTheSameProductSizeExist)
                throw new OrderServiceException("Строка заказа с заданным размером товара уже существует в текущем заказе.");

            var orderItem =
                new OrderItem
                {
                    Price = createdOrderItem.Price,
                    Quantity = createdOrderItem.Quantity,
                    TotalPrice = createdOrderItem.Price * createdOrderItem.Quantity,
                    Active = createdOrderItem.Active
                };
            UpdateOrder(orderItem, createdOrderItem.Order);
            UpdateProductSize(orderItem, createdOrderItem.ProductSize);
            orderItem.UpdateTrackFields(Container);

            persistentService.Add(orderItem);
            persistentService.SaveChanges();

            createdOrderItem.Id = orderItem.Id;
            createdOrderItem.CreateDate = orderItem.CreateDate;
            createdOrderItem.CreateUser = orderItem.CreatedBy.GetFullName();
            createdOrderItem.ChangeDate = orderItem.ChangeDate;
            createdOrderItem.ChangeUser = orderItem.ChangedBy.GetFullName();

            createdOrderItem.PurchaserPaid = 0m;
        }

        public void UpdateOrderItem(DTO.OrderItem updatedOrderItem)
        {
            CheckHelper.ArgumentNotNull(updatedOrderItem, "updatedOrderItem");
            CheckHelper.ArgumentWithinCondition(!updatedOrderItem.IsNew(), "Order item is new.");
            Container.Get<IValidateService>().CheckIsValid(updatedOrderItem);

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(
                SecurityService.IsCurrentUserSeller ||
                SecurityService.IsCurrentUserPurchaser,
                "Only seller and purchaser can change order item.");

            var persistentService = Container.Get<IPersistentService>();

            var order = persistentService.GetEntityById<DataAccess.Order>(updatedOrderItem.Order.Id);
            CheckHelper.NotNull(order, "Order does not exist");
            
            CheckHelper.WithinCondition(
                SecurityService.IsCurrentUserPurchaser ||
                IsCurrentUserSellerForOrder(order), 
                "Order is created by another seller.");

            var doesAnotherOrderItemWithTheSameProductSizeExist =
                persistentService
                    .GetEntitySet<OrderItem>()
                    .Any(oi =>
                        oi.Id != updatedOrderItem.Id &&
                        oi.OrderId == order.Id &&
                        oi.ProductSizeId == updatedOrderItem.ProductSize.Id);
            if (doesAnotherOrderItemWithTheSameProductSizeExist)
                throw new OrderServiceException("Строка заказа с заданным размером товара уже существует в текущем заказе.");

            var orderItem = persistentService.GetEntityById<OrderItem>(updatedOrderItem.Id);
            CheckHelper.NotNull(order, "Order item does not exist");
            
            if (IsCurrentUserSellerForOrder(order))
            {
                orderItem.Price = updatedOrderItem.Price;
                orderItem.Quantity = updatedOrderItem.Quantity;
                orderItem.TotalPrice = updatedOrderItem.TotalPrice;
                orderItem.Active = updatedOrderItem.Active;

                UpdateOrder(orderItem, updatedOrderItem.Order);
                UpdateProductSize(orderItem, updatedOrderItem.ProductSize);
            }
            else
            {
                updatedOrderItem.Price = orderItem.Price;
                updatedOrderItem.Quantity = orderItem.Quantity;
                updatedOrderItem.Active = orderItem.Active;

                Func<DataAccess.Order, bool> predicate = null;
                if (SecurityService.IsCurrentUserSeller && !SecurityService.IsCurrentUserPurchaser)
                    predicate = o => o.CreateUserId == SecurityService.CurrentUser.Id;
                updatedOrderItem.Order = Container.Get<IDtoService>().CreateOrder(orderItem.Order, false, predicate);

                updatedOrderItem.ProductSize = Container.Get<IDtoService>().CreateProductSize(orderItem.ProductSize);
            }
            
            if (SecurityService.IsCurrentUserPurchaser)
            {
                orderItem.PurchaserPaid = updatedOrderItem.PurchaserPaid;
            }
            else
            {
                updatedOrderItem.PurchaserPaid = orderItem.PurchaserPaid;
            }

            orderItem.UpdateTrackFields(Container);

            persistentService.SaveChanges();
        }

        #endregion
    }
}


