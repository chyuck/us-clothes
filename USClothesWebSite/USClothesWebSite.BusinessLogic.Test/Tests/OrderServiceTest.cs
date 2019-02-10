using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.BusinessLogic.Dto;
using USClothesWebSite.BusinessLogic.Order;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.BusinessLogic.Test.Extensions;
using USClothesWebSite.BusinessLogic.Test.Mocks;
using USClothesWebSite.Common.Services.Time;
using USClothesWebSite.DataAccess;
using USClothesWebSite.Test.Common;
using USClothesWebSite.BusinessLogic.Extensions;

namespace USClothesWebSite.BusinessLogic.Test
{
    [TestClass]
    public class OrderServiceTest
    {
        [TestMethod]
        public void GetOrders_Should_Return_Orders_By_Filter()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            // Act
            var orders =
                orderService.GetOrders(
                    TimeServiceMockFactory.Date1, TimeServiceMockFactory.Date5, "Россия");

            // Assert
            var expectedOrders =
                new[]
                {
                    dtoService.CreateOrder(OrderMockFactory.Order_2),
                    dtoService.CreateOrder(OrderMockFactory.Order_4),
                    dtoService.CreateOrder(OrderMockFactory.Order_7)
                };
            CollectionAssert.AreEqual(expectedOrders, orders);
        }

        [TestMethod]
        public void GetOrders_Should_Return_Orders_By_Dates()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            // Act
            var orders =
                orderService.GetOrders(
                    TimeServiceMockFactory.Date1, TimeServiceMockFactory.Date2, null);

            // Assert
            var expectedOrders =
                new[]
                {
                    dtoService.CreateOrder(OrderMockFactory.Order_1),
                    dtoService.CreateOrder(OrderMockFactory.Order_2),
                    dtoService.CreateOrder(OrderMockFactory.Order_4),
                    dtoService.CreateOrder(OrderMockFactory.Order_7),
                    dtoService.CreateOrder(OrderMockFactory.Order_8)
                };
            CollectionAssert.AreEqual(expectedOrders, orders);
        }

        [TestMethod]
        public void GetOrders_Should_Return_Orders_Created_By_Current_User_When_Current_User_Is_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.DianaDistributor.Active = false;
            UserRoleMockFactory.DianaPurchaser.Active = false;
            UserRoleMockFactory.DianaAdministrator.Active = false;
            UserRoleMockFactory.DianaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            // Act
            var orders =
                orderService.GetOrders(
                    TimeServiceMockFactory.Date1, TimeServiceMockFactory.Date5, null);

            // Assert
            var expectedOrders =
                new[]
                {
                    dtoService.CreateOrder(OrderMockFactory.Order_4),
                    dtoService.CreateOrder(OrderMockFactory.Order_6),
                    dtoService.CreateOrder(OrderMockFactory.Order_7)
                };
            CollectionAssert.AreEqual(expectedOrders, orders);
        }

        [TestMethod]
        public void GetOrders_Should_Return_Orders_Included_In_Parcel_With_Current_User_As_Distributor_When_Current_User_Is_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.OlesyaDistributor.Active = true;
            UserRoleMockFactory.OlesyaPurchaser.Active = false;
            UserRoleMockFactory.OlesyaAdministrator.Active = false;
            UserRoleMockFactory.OlesyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            // Act
            var orders =
                orderService.GetOrders(
                    TimeServiceMockFactory.Date1, TimeServiceMockFactory.Date5, null);

            // Assert
            var expectedOrders =
                new[]
                {
                    dtoService.CreateOrder(OrderMockFactory.Order_1),
                    dtoService.CreateOrder(OrderMockFactory.Order_2)
                };
            CollectionAssert.AreEqual(expectedOrders, orders);
        }

        [TestMethod]
        public void GetOrders_Should_Return_Orders_When_Current_User_Is_Purchaser()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = true;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            // Act
            var orders =
                orderService.GetOrders(
                    TimeServiceMockFactory.Date1, TimeServiceMockFactory.Date5, null);

            // Assert
            var expectedOrders =
                new[]
                {
                    dtoService.CreateOrder(OrderMockFactory.Order_1),
                    dtoService.CreateOrder(OrderMockFactory.Order_2),
                    dtoService.CreateOrder(OrderMockFactory.Order_3),
                    dtoService.CreateOrder(OrderMockFactory.Order_4),
                    dtoService.CreateOrder(OrderMockFactory.Order_5),
                    dtoService.CreateOrder(OrderMockFactory.Order_6),
                    dtoService.CreateOrder(OrderMockFactory.Order_7),
                    dtoService.CreateOrder(OrderMockFactory.Order_8)
                };
            CollectionAssert.AreEqual(expectedOrders, orders);
        }

        [TestMethod]
        public void GetOrders_Should_Return_Orders_When_Current_User_Is_Purchaser_Distributor_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = true;
            UserRoleMockFactory.JenyaPurchaser.Active = true;
            UserRoleMockFactory.JenyaSeller.Active = true;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            // Act
            var orders =
                orderService.GetOrders(
                    TimeServiceMockFactory.Date1, TimeServiceMockFactory.Date5, null);

            // Assert
            var expectedOrders =
                new[]
                {
                    dtoService.CreateOrder(OrderMockFactory.Order_1),
                    dtoService.CreateOrder(OrderMockFactory.Order_2),
                    dtoService.CreateOrder(OrderMockFactory.Order_3),
                    dtoService.CreateOrder(OrderMockFactory.Order_4),
                    dtoService.CreateOrder(OrderMockFactory.Order_5),
                    dtoService.CreateOrder(OrderMockFactory.Order_6),
                    dtoService.CreateOrder(OrderMockFactory.Order_7),
                    dtoService.CreateOrder(OrderMockFactory.Order_8)
                };
            CollectionAssert.AreEqual(expectedOrders, orders);
        }

        [TestMethod]
        public void GetOrders_Should_Return_Orders_When_Current_User_Is_Seller_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.DianaSeller.Active = true;
            UserRoleMockFactory.DianaDistributor.Active = true;
            UserRoleMockFactory.DianaPurchaser.Active = false;
            UserRoleMockFactory.DianaAdministrator.Active = false;
            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);
            
            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            // Act
            var orders =
                orderService.GetOrders(
                    TimeServiceMockFactory.Date1, TimeServiceMockFactory.Date5, null);

            // Assert
            var expectedOrders =
                new[]
                {
                    dtoService.CreateOrder(OrderMockFactory.Order_4),
                    dtoService.CreateOrder(OrderMockFactory.Order_6),
                    dtoService.CreateOrder(OrderMockFactory.Order_7),
                    dtoService.CreateOrder(OrderMockFactory.Order_8)
                };
            CollectionAssert.AreEqual(expectedOrders, orders);
        }

        [TestMethod]
        public void GetOrders_Should_Throw_Exception_When_Current_Is_User_Not_Seller_Purchaser_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserMockFactory.Andrey.Active = true;
            securityService.LogIn(UserMockFactory.Andrey.Login, EncryptServiceMockFactory.AndreyPasswordData.Password);

            var orderService = container.Get<IOrderService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => orderService.GetOrders(TimeServiceMockFactory.Date1, TimeServiceMockFactory.Date5, null),
                "Only seller, purchaser and distributor can get all orders.");
        }

        [TestMethod]
        public void GetOrders_Should_Return_Orders_By_Id_When_Id_Template_Is_Used_In_Filter()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            // Act
            var orders = 
                orderService.GetOrders(
                    TimeServiceMockFactory.Date1, TimeServiceMockFactory.Date5, "ID:3");

            // Assert
            var expectedOrders =
                new[]
                {
                    dtoService.CreateOrder(OrderMockFactory.Order_3)
                };
            CollectionAssert.AreEqual(expectedOrders, orders);
        }

        [TestMethod]
        public void GetOrdersByParcel_Should_Return_Orders_By_Filter()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            var parcel = dtoService.CreateParcel(ParcelMockFactory.Parcel_1);

            // Act
            var orders = orderService.GetOrdersByParcel(parcel, "Пупкин");

            // Assert
            var expectedOrders =
                new[]
                {
                    dtoService.CreateOrder(OrderMockFactory.Order_1)
                };
            CollectionAssert.AreEqual(expectedOrders, orders);
        }

        [TestMethod]
        public void GetOrdersByParcel_Should_Return_Orders_Created_By_Current_User_When_Current_User_Is_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.DianaDistributor.Active = false;
            UserRoleMockFactory.DianaPurchaser.Active = false;
            UserRoleMockFactory.DianaAdministrator.Active = false;
            UserRoleMockFactory.DianaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            var parcel = dtoService.CreateParcel(ParcelMockFactory.Parcel_3);

            // Act
            var orders = orderService.GetOrdersByParcel(parcel, null);

            // Assert
            var expectedOrders =
                new[]
                {
                    dtoService.CreateOrder(OrderMockFactory.Order_4)
                };
            CollectionAssert.AreEqual(expectedOrders, orders);
        }

        [TestMethod]
        public void GetOrdersByParcel_Should_Return_Orders_Included_In_Parcel_With_Current_User_As_Distributor_When_Current_User_Is_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.OlesyaDistributor.Active = true;
            UserRoleMockFactory.OlesyaPurchaser.Active = false;
            UserRoleMockFactory.OlesyaAdministrator.Active = false;
            UserRoleMockFactory.OlesyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            var parcel = dtoService.CreateParcel(ParcelMockFactory.Parcel_1);

            // Act
            var orders = orderService.GetOrdersByParcel(parcel, null);

            // Assert
            var expectedOrders =
                new[]
                {
                    dtoService.CreateOrder(OrderMockFactory.Order_1),
                    dtoService.CreateOrder(OrderMockFactory.Order_2)
                };
            CollectionAssert.AreEqual(expectedOrders, orders);
        }

        [TestMethod]
        public void GetOrdersByParcel_Should_Throw_Exception_When_Current_User_Is_Distributor_And_Parcel_Is_Not_Assigned_To_Current_User()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.OlesyaDistributor.Active = true;
            UserRoleMockFactory.OlesyaPurchaser.Active = false;
            UserRoleMockFactory.OlesyaAdministrator.Active = false;
            UserRoleMockFactory.OlesyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            var parcel = dtoService.CreateParcel(ParcelMockFactory.Parcel_2);

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => orderService.GetOrdersByParcel(parcel, null),
                "Current user is either distributor and parcel is not assigned to him or seller and parcel does not have any order created by him.");
        }

        [TestMethod]
        public void GetOrdersByParcel_Should_Throw_Exception_When_Current_User_Is_Seller_And_Parcel_Does_Not_Have_Orders_Created_By_Current_User()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.DianaDistributor.Active = false;
            UserRoleMockFactory.DianaPurchaser.Active = false;
            UserRoleMockFactory.DianaAdministrator.Active = false;
            UserRoleMockFactory.DianaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            var parcel = dtoService.CreateParcel(ParcelMockFactory.Parcel_1);

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => orderService.GetOrdersByParcel(parcel, null),
                "Current user is either distributor and parcel is not assigned to him or seller and parcel does not have any order created by him.");
        }

        [TestMethod]
        public void GetOrdersByParcel_Should_Return_Orders_When_Current_User_Is_Purchaser()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = true;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            var parcel = dtoService.CreateParcel(ParcelMockFactory.Parcel_3);

            // Act
            var orders = orderService.GetOrdersByParcel(parcel, null);

            // Assert
            var expectedOrders =
                new[]
                {
                    dtoService.CreateOrder(OrderMockFactory.Order_4),
                    dtoService.CreateOrder(OrderMockFactory.Order_5)
                };
            CollectionAssert.AreEqual(expectedOrders, orders);
        }

        [TestMethod]
        public void GetOrdersByParcel_Should_Return_Orders_When_Current_User_Is_Purchaser_Distributor_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = true;
            UserRoleMockFactory.JenyaPurchaser.Active = true;
            UserRoleMockFactory.JenyaSeller.Active = true;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            var parcel = dtoService.CreateParcel(ParcelMockFactory.Parcel_3);

            // Act
            var orders = orderService.GetOrdersByParcel(parcel, null);

            // Assert
            var expectedOrders =
                new[]
                {
                    dtoService.CreateOrder(OrderMockFactory.Order_4),
                    dtoService.CreateOrder(OrderMockFactory.Order_5)
                };
            CollectionAssert.AreEqual(expectedOrders, orders);
        }

        [TestMethod]
        public void GetOrdersByParcel_Should_Return_Orders_When_Current_User_Is_Seller_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.DianaSeller.Active = true;
            UserRoleMockFactory.DianaDistributor.Active = true;
            UserRoleMockFactory.DianaPurchaser.Active = false;
            UserRoleMockFactory.DianaAdministrator.Active = false;
            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            var parcel = dtoService.CreateParcel(ParcelMockFactory.Parcel_3);

            // Act
            var orders = orderService.GetOrdersByParcel(parcel, null);

            // Assert
            var expectedOrders =
                new[]
                {
                    dtoService.CreateOrder(OrderMockFactory.Order_4)
                };
            CollectionAssert.AreEqual(expectedOrders, orders);
        }

        [TestMethod]
        public void GetOrdersByParcel_Should_Throw_Exception_When_Current_Is_User_Not_Seller_Purchaser_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserMockFactory.Andrey.Active = true;
            securityService.LogIn(UserMockFactory.Andrey.Login, EncryptServiceMockFactory.AndreyPasswordData.Password);

            var orderService = container.Get<IOrderService>();
            var dtoService = container.Get<IDtoService>();

            var parcel = dtoService.CreateParcel(ParcelMockFactory.Parcel_1);

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => orderService.GetOrdersByParcel(parcel, null),
                "Only seller, purchaser and distributor can get all orders.");
        }

        [TestMethod]
        public void GetOrdersByParcel_Should_Return_Orders_By_Id_When_Id_Template_Is_Used_In_Filter()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            var parcel = dtoService.CreateParcel(ParcelMockFactory.Parcel_1);

            // Act
            var orders =
                orderService.GetOrdersByParcel(parcel, "ID:2");

            // Assert
            var expectedOrders =
                new[]
                {
                    dtoService.CreateOrder(OrderMockFactory.Order_2)
                };
            CollectionAssert.AreEqual(expectedOrders, orders);
        }

        [TestMethod]
        public void GetOrderItems_Should_Return_OrderItems_In_Order_Created_By_Current_User_When_Current_User_Is_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.DianaDistributor.Active = false;
            UserRoleMockFactory.DianaPurchaser.Active = false;
            UserRoleMockFactory.DianaAdministrator.Active = false;
            UserRoleMockFactory.DianaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            var order = dtoService.CreateOrder(OrderMockFactory.Order_4);
            
            // Act
            var orderItems = orderService.GetOrderItems(order);

            // Assert
            var expectedOrderItems =
                new[]
                {
                    dtoService.CreateOrderItem(OrderItemMockFactory.OrderItem_7),
                    dtoService.CreateOrderItem(OrderItemMockFactory.OrderItem_14)
                };
            CollectionAssert.AreEqual(expectedOrderItems, orderItems);
        }

        [TestMethod]
        public void GetOrderItems_Should_Return_OrderItems_In_Order_Included_In_Parcel_With_Current_User_As_Distributor_When_Current_User_Is_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.OlesyaDistributor.Active = true;
            UserRoleMockFactory.OlesyaPurchaser.Active = false;
            UserRoleMockFactory.OlesyaAdministrator.Active = false;
            UserRoleMockFactory.OlesyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            var order = dtoService.CreateOrder(OrderMockFactory.Order_1);

            // Act
            var orderItems = orderService.GetOrderItems(order);

            // Assert
            var expectedOrderItems =
                new[]
                {
                    dtoService.CreateOrderItem(OrderItemMockFactory.OrderItem_2),
                    dtoService.CreateOrderItem(OrderItemMockFactory.OrderItem_5),
                    dtoService.CreateOrderItem(OrderItemMockFactory.OrderItem_6)
                };
            CollectionAssert.AreEqual(expectedOrderItems, orderItems);
        }

        [TestMethod]
        public void GetOrderItems_Should_Return_OrderItems_When_Current_User_Is_Purchaser()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = true;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            var order = dtoService.CreateOrder(OrderMockFactory.Order_6);

            // Act
            var orderItems = orderService.GetOrderItems(order);

            // Assert
            var expectedOrderItems =
                new[]
                {
                    dtoService.CreateOrderItem(OrderItemMockFactory.OrderItem_9),
                    dtoService.CreateOrderItem(OrderItemMockFactory.OrderItem_13)
                };
            CollectionAssert.AreEqual(expectedOrderItems, orderItems);
        }

        [TestMethod]
        public void GetOrderItems_Should_Return_OrderItems_When_Current_User_Is_Purchaser_Distributor_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = true;
            UserRoleMockFactory.JenyaPurchaser.Active = true;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            var order = dtoService.CreateOrder(OrderMockFactory.Order_2);

            // Act
            var orderItems = orderService.GetOrderItems(order);

            // Assert
            var expectedOrderItems =
                new[]
                {
                    dtoService.CreateOrderItem(OrderItemMockFactory.OrderItem_3),
                    dtoService.CreateOrderItem(OrderItemMockFactory.OrderItem_4)
                };
            CollectionAssert.AreEqual(expectedOrderItems, orderItems);
        }

        [TestMethod]
        public void GetOrderItems_Should_Return_OrderItems_When_Current_User_Is_Seller_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.DianaDistributor.Active = true;
            UserRoleMockFactory.DianaPurchaser.Active = false;
            UserRoleMockFactory.DianaAdministrator.Active = false;
            UserRoleMockFactory.DianaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            var order = dtoService.CreateOrder(OrderMockFactory.Order_6);

            // Act
            var orderItems = orderService.GetOrderItems(order);

            // Assert
            var expectedOrderItems =
                new[]
                {
                    dtoService.CreateOrderItem(OrderItemMockFactory.OrderItem_9),
                    dtoService.CreateOrderItem(OrderItemMockFactory.OrderItem_13)
                };
            CollectionAssert.AreEqual(expectedOrderItems, orderItems);
        }

        [TestMethod]
        public void GetOrderItems_Should_Throw_Exception_When_Current_Is_User_Not_Seller_Purchaser_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserMockFactory.Andrey.Active = true;
            securityService.LogIn(UserMockFactory.Andrey.Login, EncryptServiceMockFactory.AndreyPasswordData.Password);

            var orderService = container.Get<IOrderService>();
            var dtoService = container.Get<IDtoService>();

            var order = dtoService.CreateOrder(OrderMockFactory.Order_6);

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => orderService.GetOrderItems(order),
                "Only seller, purchaser and distributor can get all order items.");
        }

        [TestMethod]
        public void GetOrderItems_Should_Throw_Exception_When_Current_User_Is_Distributor_And_Order_Is_Not_included_In_Parcel_Assigned_To_Current_User()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.OlesyaDistributor.Active = true;
            UserRoleMockFactory.OlesyaPurchaser.Active = false;
            UserRoleMockFactory.OlesyaAdministrator.Active = false;
            UserRoleMockFactory.OlesyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            var order = dtoService.CreateOrder(OrderMockFactory.Order_7);

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => orderService.GetOrderItems(order),
                "Current user is either distributor and order is not included in parcel assigned to him or seller and order is not created by him.");
        }

        [TestMethod]
        public void GetOrderItems_Should_Throw_Exception_When_Current_User_Is_Seller_And_Order_Is_Not_Created_By_Current_User()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.DianaDistributor.Active = false;
            UserRoleMockFactory.DianaPurchaser.Active = false;
            UserRoleMockFactory.DianaAdministrator.Active = false;
            UserRoleMockFactory.DianaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var orderService = container.Get<IOrderService>();

            var order = dtoService.CreateOrder(OrderMockFactory.Order_5);

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => orderService.GetOrderItems(order),
                "Current user is either distributor and order is not included in parcel assigned to him or seller and order is not created by him.");
        }

        [TestMethod]
        public void CreateOrder_Should_Create_Order()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = false;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var orderDate = new DateTime(2013, 7, 2);
            const string CUSTOMER_FIRST_NAME = "Вася";
            const string CUSTOMER_LAST_NAME = "Иванов";
            const string CUSTOMER_ADDRESS = "Волжский бульвар, дом 55, кв 80";
            const string CUSTOMER_CITY = "Москва";
            const string CUSTOMER_COUNTRY = "Россия";
            const string CUSTOMER_POSTAL_CODE = "909877";
            const string CUSTOMER_PHONE_NUMBER = "9267545808";
            const string CUSTOMER_EMAIL = "chyuck@mail.ru";
            const bool ACTIVE = false;
            const string COMMENTS = "Some comments";
            const decimal RUBLES_PER_DOLLAR = 31.5m;
            const decimal CUSTOMER_PREPAID = 1300m;
            const decimal CUSTOMER_PAID = 2500m;

            var createdOrder =
                new DTO.Order
                {
                    OrderDate = orderDate,
                    CustomerFirstName = CUSTOMER_FIRST_NAME,
                    CustomerLastName = CUSTOMER_LAST_NAME,
                    CustomerAddress = CUSTOMER_ADDRESS,
                    CustomerCity = CUSTOMER_CITY,
                    CustomerCountry = CUSTOMER_COUNTRY,
                    CustomerPostalCode = CUSTOMER_POSTAL_CODE,
                    CustomerPhoneNumber = CUSTOMER_PHONE_NUMBER,
                    CustomerEmail = CUSTOMER_EMAIL,
                    Active = ACTIVE,
                    Comments = COMMENTS,
                    RublesPerDollar = RUBLES_PER_DOLLAR,
                    CustomerPrepaid = CUSTOMER_PREPAID,
                    DistributorSpentOnDelivery = 200m,
                    CustomerPaid = CUSTOMER_PAID,
                    TrackingNumber = "GHJ9884753067576H",
                    Parcel = container.Get<IDtoService>().CreateParcel(ParcelMockFactory.Parcel_3)
                };

            var orderService = container.Get<IOrderService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            orderService.CreateOrder(createdOrder);

            // Assert
            Assert.IsTrue(createdOrder.Id > 0);

            var actualOrder = persistentService.GetEntityById<DataAccess.Order>(createdOrder.Id);

            Assert.AreEqual(createdOrder.Id, actualOrder.Id);
            Assert.AreEqual(orderDate, actualOrder.OrderDate);
            Assert.AreEqual(CUSTOMER_FIRST_NAME, actualOrder.CustomerFirstName);
            Assert.AreEqual(CUSTOMER_LAST_NAME, actualOrder.CustomerLastName);
            Assert.AreEqual(CUSTOMER_ADDRESS, actualOrder.CustomerAddress);
            Assert.AreEqual(CUSTOMER_CITY, actualOrder.CustomerCity);
            Assert.AreEqual(CUSTOMER_COUNTRY, actualOrder.CustomerCountry);
            Assert.AreEqual(CUSTOMER_POSTAL_CODE, actualOrder.CustomerPostalCode);
            Assert.AreEqual(CUSTOMER_PHONE_NUMBER, actualOrder.CustomerPhoneNumber);
            Assert.AreEqual(CUSTOMER_EMAIL, actualOrder.CustomerEmail);
            Assert.AreEqual(ACTIVE, actualOrder.Active);
            Assert.AreEqual(COMMENTS, actualOrder.Comments);
            Assert.AreEqual(RUBLES_PER_DOLLAR, actualOrder.RublesPerDollar);
            Assert.AreEqual(CUSTOMER_PREPAID, actualOrder.CustomerPrepaid);
            Assert.AreEqual(0, actualOrder.DistributorSpentOnDelivery);
            Assert.AreEqual(CUSTOMER_PAID, actualOrder.CustomerPaid);
            Assert.IsNull(actualOrder.TrackingNumber);
            Assert.IsNull(actualOrder.Parcel);
            Assert.AreEqual(timeService.UtcNow, actualOrder.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualOrder.ChangeDate);
            Assert.AreEqual(UserMockFactory.Jenya, actualOrder.CreatedBy);
            Assert.AreEqual(UserMockFactory.Jenya, actualOrder.ChangedBy);

            Assert.AreEqual(createdOrder, container.Get<IDtoService>().CreateOrder(actualOrder));
        }

        [TestMethod]
        public void CreateOrder_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = true;
            UserRoleMockFactory.JenyaPurchaser.Active = true;
            UserRoleMockFactory.JenyaAdministrator.Active = true;
            UserRoleMockFactory.JenyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var createdOrder =
                new DTO.Order
                {
                    OrderDate = new DateTime(2013, 7, 2),
                    CustomerFirstName = "Вася",
                    CustomerLastName = "Иванов",
                    CustomerAddress = "Волжский бульвар, дом 55, кв 80",
                    CustomerCity = "Москва",
                    CustomerCountry = "Россия",
                    CustomerPostalCode = "909877",
                    CustomerPhoneNumber = "9267545808",
                    CustomerEmail = "chyuck@mail.ru",
                    Active = false,
                    Comments = "Some comments",
                    RublesPerDollar = 31.5m,
                    CustomerPrepaid = 1300m,
                    CustomerPaid = 2500m
                };

            var orderService = container.Get<IOrderService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => orderService.CreateOrder(createdOrder),
                "Only seller can create order.");
        }

        [TestMethod]
        public void UpdateOrder_Should_Update_Order_When_Current_User_Is_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = false;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var orderDate = new DateTime(2013, 7, 2);
            const string CUSTOMER_FIRST_NAME = "Вася";
            const string CUSTOMER_LAST_NAME = "Иванов";
            const string CUSTOMER_ADDRESS = "Волжский бульвар, дом 55, кв 80";
            const string CUSTOMER_CITY = "Москва";
            const string CUSTOMER_COUNTRY = "Россия";
            const string CUSTOMER_POSTAL_CODE = "909877";
            const string CUSTOMER_PHONE_NUMBER = "9267545808";
            const string CUSTOMER_EMAIL = "chyuck@mail.ru";
            const bool ACTIVE = false;
            const string COMMENTS = "Some comments";
            const decimal RUBLES_PER_DOLLAR = 31.5m;
            const decimal CUSTOMER_PREPAID = 1300m;
            const decimal CUSTOMER_PAID = 2500m;
            var createDate = OrderMockFactory.Order_8.CreateDate;
            var createdBy = OrderMockFactory.Order_8.CreatedBy;
            var distributorSpentOnDelivery = OrderMockFactory.Order_8.DistributorSpentOnDelivery;
            var trackingNumber = OrderMockFactory.Order_8.TrackingNumber;
            var parcel = OrderMockFactory.Order_8.Parcel;

            var updatedOrder =
                new DTO.Order
                {
                    Id = OrderMockFactory.Order_8.Id,
                    OrderDate = orderDate,
                    CustomerFirstName = CUSTOMER_FIRST_NAME,
                    CustomerLastName = CUSTOMER_LAST_NAME,
                    CustomerAddress = CUSTOMER_ADDRESS,
                    CustomerCity = CUSTOMER_CITY,
                    CustomerCountry = CUSTOMER_COUNTRY,
                    CustomerPostalCode = CUSTOMER_POSTAL_CODE,
                    CustomerPhoneNumber = CUSTOMER_PHONE_NUMBER,
                    CustomerEmail = CUSTOMER_EMAIL,
                    Active = ACTIVE,
                    Comments = COMMENTS,
                    RublesPerDollar = RUBLES_PER_DOLLAR,
                    CustomerPrepaid = CUSTOMER_PREPAID,
                    DistributorSpentOnDelivery = 200m,
                    CustomerPaid = CUSTOMER_PAID,
                    TrackingNumber = "GHJ9884753067576H",
                    Parcel = container.Get<IDtoService>().CreateParcel(ParcelMockFactory.Parcel_3)
                };

            var orderService = container.Get<IOrderService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            orderService.UpdateOrder(updatedOrder);

            // Assert
            var actualOrder = persistentService.GetEntityById<DataAccess.Order>(OrderMockFactory.Order_8.Id);

            Assert.AreEqual(updatedOrder.Id, actualOrder.Id);
            Assert.AreEqual(orderDate, actualOrder.OrderDate);
            Assert.AreEqual(CUSTOMER_FIRST_NAME, actualOrder.CustomerFirstName);
            Assert.AreEqual(CUSTOMER_LAST_NAME, actualOrder.CustomerLastName);
            Assert.AreEqual(CUSTOMER_ADDRESS, actualOrder.CustomerAddress);
            Assert.AreEqual(CUSTOMER_CITY, actualOrder.CustomerCity);
            Assert.AreEqual(CUSTOMER_COUNTRY, actualOrder.CustomerCountry);
            Assert.AreEqual(CUSTOMER_POSTAL_CODE, actualOrder.CustomerPostalCode);
            Assert.AreEqual(CUSTOMER_PHONE_NUMBER, actualOrder.CustomerPhoneNumber);
            Assert.AreEqual(CUSTOMER_EMAIL, actualOrder.CustomerEmail);
            Assert.AreEqual(ACTIVE, actualOrder.Active);
            Assert.AreEqual(COMMENTS, actualOrder.Comments);
            Assert.AreEqual(RUBLES_PER_DOLLAR, actualOrder.RublesPerDollar);
            Assert.AreEqual(CUSTOMER_PREPAID, actualOrder.CustomerPrepaid);
            Assert.AreEqual(distributorSpentOnDelivery, actualOrder.DistributorSpentOnDelivery);
            Assert.AreEqual(CUSTOMER_PAID, actualOrder.CustomerPaid);
            Assert.AreEqual(trackingNumber, actualOrder.TrackingNumber);
            Assert.AreEqual(parcel, actualOrder.Parcel);
            Assert.AreEqual(createDate, actualOrder.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualOrder.ChangeDate);
            Assert.AreEqual(createdBy, actualOrder.CreatedBy);
            Assert.AreEqual(UserMockFactory.Jenya, actualOrder.ChangedBy);

            Assert.AreEqual(updatedOrder, container.Get<IDtoService>().CreateOrder(actualOrder));
        }

        [TestMethod]
        public void UpdateOrder_Should_Update_Order_When_Current_User_Is_Purchaser()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = true;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var parcel = container.Get<IDtoService>().CreateParcel(ParcelMockFactory.Parcel_3);

            var createDate = OrderMockFactory.Order_8.CreateDate;
            var createdBy = OrderMockFactory.Order_8.CreatedBy;
            var orderDate = OrderMockFactory.Order_8.OrderDate;
            var customerFirstName = OrderMockFactory.Order_8.CustomerFirstName;
            var customerLastName = OrderMockFactory.Order_8.CustomerLastName;
            var customerAddress = OrderMockFactory.Order_8.CustomerAddress;
            var customerCity = OrderMockFactory.Order_8.CustomerCity;
            var customerCountry = OrderMockFactory.Order_8.CustomerCountry;
            var customerPostalCode = OrderMockFactory.Order_8.CustomerPostalCode;
            var customerPhoneNumber = OrderMockFactory.Order_8.CustomerPhoneNumber;
            var customerEmail = OrderMockFactory.Order_8.CustomerEmail;
            var active = OrderMockFactory.Order_8.Active;
            var comments = OrderMockFactory.Order_8.Comments;
            var rublesPerDollar = OrderMockFactory.Order_8.RublesPerDollar;
            var customerPrepaid = OrderMockFactory.Order_8.CustomerPrepaid;
            var distributorSpentOnDelivery = OrderMockFactory.Order_8.DistributorSpentOnDelivery;
            var customerPaid = OrderMockFactory.Order_8.CustomerPaid;
            var trackingNumber = OrderMockFactory.Order_8.TrackingNumber;

            var updatedOrder =
                new DTO.Order
                {
                    Id = OrderMockFactory.Order_8.Id,
                    OrderDate = new DateTime(2013, 7, 2),
                    CustomerFirstName = "Вася",
                    CustomerLastName = "Иванов",
                    CustomerAddress = "Волжский бульвар, дом 55, кв 80",
                    CustomerCity = "Москва",
                    CustomerCountry = "Россия",
                    CustomerPostalCode = "909877",
                    CustomerPhoneNumber = "9267545808",
                    CustomerEmail = "chyuck@mail.ru",
                    Active = false,
                    Comments = "Some comments",
                    RublesPerDollar = 31.5m,
                    CustomerPrepaid = 1300m,
                    DistributorSpentOnDelivery = 200m,
                    CustomerPaid = 2500m,
                    TrackingNumber = "GHJ9884753067576H",
                    Parcel = parcel
                };

            var orderService = container.Get<IOrderService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            orderService.UpdateOrder(updatedOrder);

            // Assert
            var actualOrder = persistentService.GetEntityById<DataAccess.Order>(OrderMockFactory.Order_8.Id);

            Assert.AreEqual(updatedOrder.Id, actualOrder.Id);
            Assert.AreEqual(orderDate, actualOrder.OrderDate);
            Assert.AreEqual(customerFirstName, actualOrder.CustomerFirstName);
            Assert.AreEqual(customerLastName, actualOrder.CustomerLastName);
            Assert.AreEqual(customerAddress, actualOrder.CustomerAddress);
            Assert.AreEqual(customerCity, actualOrder.CustomerCity);
            Assert.AreEqual(customerCountry, actualOrder.CustomerCountry);
            Assert.AreEqual(customerPostalCode, actualOrder.CustomerPostalCode);
            Assert.AreEqual(customerPhoneNumber, actualOrder.CustomerPhoneNumber);
            Assert.AreEqual(customerEmail, actualOrder.CustomerEmail);
            Assert.AreEqual(active, actualOrder.Active);
            Assert.AreEqual(comments, actualOrder.Comments);
            Assert.AreEqual(rublesPerDollar, actualOrder.RublesPerDollar);
            Assert.AreEqual(customerPrepaid, actualOrder.CustomerPrepaid);
            Assert.AreEqual(distributorSpentOnDelivery, actualOrder.DistributorSpentOnDelivery);
            Assert.AreEqual(customerPaid, actualOrder.CustomerPaid);
            Assert.AreEqual(trackingNumber, actualOrder.TrackingNumber);
            Assert.AreEqual(parcel.Id, actualOrder.Parcel.Id);
            Assert.AreEqual(createDate, actualOrder.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualOrder.ChangeDate);
            Assert.AreEqual(createdBy, actualOrder.CreatedBy);
            Assert.AreEqual(UserMockFactory.Jenya, actualOrder.ChangedBy);

            Assert.AreEqual(updatedOrder, container.Get<IDtoService>().CreateOrder(actualOrder));
        }

        [TestMethod]
        public void UpdateOrder_Should_Update_Order_When_Current_User_Is_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.DianaDistributor.Active = true;
            UserRoleMockFactory.DianaPurchaser.Active = false;
            UserRoleMockFactory.DianaAdministrator.Active = false;
            UserRoleMockFactory.DianaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            const decimal DISTRIBUTOR_SPENT_ON_DELIVERY = 200m;
            const string TRACKING_NUMBER = "GHJ9884753067576H";
            var createDate = OrderMockFactory.Order_8.CreateDate;
            var createdBy = OrderMockFactory.Order_8.CreatedBy;
            var orderDate = OrderMockFactory.Order_8.OrderDate;
            var customerFirstName = OrderMockFactory.Order_8.CustomerFirstName;
            var customerLastName = OrderMockFactory.Order_8.CustomerLastName;
            var customerAddress = OrderMockFactory.Order_8.CustomerAddress;
            var customerCity = OrderMockFactory.Order_8.CustomerCity;
            var customerCountry = OrderMockFactory.Order_8.CustomerCountry;
            var customerPostalCode = OrderMockFactory.Order_8.CustomerPostalCode;
            var customerPhoneNumber = OrderMockFactory.Order_8.CustomerPhoneNumber;
            var customerEmail = OrderMockFactory.Order_8.CustomerEmail;
            var active = OrderMockFactory.Order_8.Active;
            var comments = OrderMockFactory.Order_8.Comments;
            var rublesPerDollar = OrderMockFactory.Order_8.RublesPerDollar;
            var customerPrepaid = OrderMockFactory.Order_8.CustomerPrepaid;
            var customerPaid = OrderMockFactory.Order_8.CustomerPaid;
            var parcel = OrderMockFactory.Order_8.Parcel;

            var updatedOrder =
                new DTO.Order
                {
                    Id = OrderMockFactory.Order_8.Id,
                    OrderDate = new DateTime(2013, 7, 2),
                    CustomerFirstName = "Вася",
                    CustomerLastName = "Иванов",
                    CustomerAddress = "Волжский бульвар, дом 55, кв 80",
                    CustomerCity = "Москва",
                    CustomerCountry = "Россия",
                    CustomerPostalCode = "909877",
                    CustomerPhoneNumber = "9267545808",
                    CustomerEmail = "chyuck@mail.ru",
                    Active = false,
                    Comments = "Some comments",
                    RublesPerDollar = 31.5m,
                    CustomerPrepaid = 1300m,
                    DistributorSpentOnDelivery = DISTRIBUTOR_SPENT_ON_DELIVERY,
                    CustomerPaid = 2500m,
                    TrackingNumber = TRACKING_NUMBER,
                    Parcel = container.Get<IDtoService>().CreateParcel(ParcelMockFactory.Parcel_3)
                };

            var orderService = container.Get<IOrderService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            orderService.UpdateOrder(updatedOrder);

            // Assert
            var actualOrder = persistentService.GetEntityById<DataAccess.Order>(OrderMockFactory.Order_8.Id);

            Assert.AreEqual(updatedOrder.Id, actualOrder.Id);
            Assert.AreEqual(orderDate, actualOrder.OrderDate);
            Assert.AreEqual(customerFirstName, actualOrder.CustomerFirstName);
            Assert.AreEqual(customerLastName, actualOrder.CustomerLastName);
            Assert.AreEqual(customerAddress, actualOrder.CustomerAddress);
            Assert.AreEqual(customerCity, actualOrder.CustomerCity);
            Assert.AreEqual(customerCountry, actualOrder.CustomerCountry);
            Assert.AreEqual(customerPostalCode, actualOrder.CustomerPostalCode);
            Assert.AreEqual(customerPhoneNumber, actualOrder.CustomerPhoneNumber);
            Assert.AreEqual(customerEmail, actualOrder.CustomerEmail);
            Assert.AreEqual(active, actualOrder.Active);
            Assert.AreEqual(comments, actualOrder.Comments);
            Assert.AreEqual(rublesPerDollar, actualOrder.RublesPerDollar);
            Assert.AreEqual(customerPrepaid, actualOrder.CustomerPrepaid);
            Assert.AreEqual(DISTRIBUTOR_SPENT_ON_DELIVERY, actualOrder.DistributorSpentOnDelivery);
            Assert.AreEqual(customerPaid, actualOrder.CustomerPaid);
            Assert.AreEqual(TRACKING_NUMBER, actualOrder.TrackingNumber);
            Assert.AreEqual(parcel, actualOrder.Parcel);
            Assert.AreEqual(createDate, actualOrder.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualOrder.ChangeDate);
            Assert.AreEqual(createdBy, actualOrder.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualOrder.ChangedBy);

            Assert.AreEqual(updatedOrder, container.Get<IDtoService>().CreateOrder(actualOrder));
        }

        [TestMethod]
        public void UpdateOrder_Should_Throw_Exception_When_Current_User_Is_Not_Seller_Purchaser_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = false;
            UserRoleMockFactory.JenyaAdministrator.Active = true;
            UserRoleMockFactory.JenyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var updatedOrder =
                new DTO.Order
                {
                    Id = OrderMockFactory.Order_8.Id,
                    OrderDate = new DateTime(2013, 7, 2),
                    CustomerFirstName = "Вася",
                    CustomerLastName = "Иванов",
                    CustomerAddress = "Волжский бульвар, дом 55, кв 80",
                    CustomerCity = "Москва",
                    CustomerCountry = "Россия",
                    CustomerPostalCode = "909877",
                    CustomerPhoneNumber = "9267545808",
                    CustomerEmail = "chyuck@mail.ru",
                    Active = false,
                    Comments = "Some comments",
                    RublesPerDollar = 31.5m,
                    CustomerPrepaid = 1300m,
                    DistributorSpentOnDelivery = 200m,
                    CustomerPaid = 2500m,
                    TrackingNumber = "GHJ9884753067576H",
                    Parcel = container.Get<IDtoService>().CreateParcel(ParcelMockFactory.Parcel_3)
                };

            var orderService = container.Get<IOrderService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => orderService.UpdateOrder(updatedOrder),
                "Only seller, purchaser and distributor can change order.");
        }

        [TestMethod]
        public void UpdateOrder_Should_Throw_Exception_When_Current_User_Is_Seller_And_Order_Is_Created_By_Another_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = false;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var updatedOrder =
                new DTO.Order
                {
                    Id = OrderMockFactory.Order_7.Id,
                    OrderDate = new DateTime(2013, 7, 2),
                    CustomerFirstName = "Вася",
                    CustomerLastName = "Иванов",
                    CustomerAddress = "Волжский бульвар, дом 55, кв 80",
                    CustomerCity = "Москва",
                    CustomerCountry = "Россия",
                    CustomerPostalCode = "909877",
                    CustomerPhoneNumber = "9267545808",
                    CustomerEmail = "chyuck@mail.ru",
                    Active = false,
                    Comments = "Some comments",
                    RublesPerDollar = 31.5m,
                    CustomerPrepaid = 1300m,
                    CustomerPaid = 2500m,
                    DistributorSpentOnDelivery = OrderMockFactory.Order_7.DistributorSpentOnDelivery,
                    TrackingNumber = OrderMockFactory.Order_7.TrackingNumber,
                    Parcel = container.Get<IDtoService>().CreateParcel(OrderMockFactory.Order_7.Parcel)
                };

            var orderService = container.Get<IOrderService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => orderService.UpdateOrder(updatedOrder),
                "Only seller, purchaser and distributor can change order.");
        }

        [TestMethod]
        public void UpdateOrder_Should_Throw_Exception_When_Current_User_Is_Distributor_And_Order_Is_Included_In_Parcel_Assigned_To_Another_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.OlesyaDistributor.Active = true;
            UserRoleMockFactory.OlesyaPurchaser.Active = false;
            UserRoleMockFactory.OlesyaAdministrator.Active = false;
            UserRoleMockFactory.OlesyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var updatedOrder =
                new DTO.Order
                {
                    Id = OrderMockFactory.Order_8.Id,
                    OrderDate = OrderMockFactory.Order_8.OrderDate,
                    CustomerFirstName = OrderMockFactory.Order_8.CustomerFirstName,
                    CustomerLastName = OrderMockFactory.Order_8.CustomerLastName,
                    CustomerAddress = OrderMockFactory.Order_8.CustomerAddress,
                    CustomerCity = OrderMockFactory.Order_8.CustomerCity,
                    CustomerCountry = OrderMockFactory.Order_8.CustomerCountry,
                    CustomerPostalCode = OrderMockFactory.Order_8.CustomerPostalCode,
                    CustomerPhoneNumber = OrderMockFactory.Order_8.CustomerPhoneNumber,
                    CustomerEmail = OrderMockFactory.Order_8.CustomerEmail,
                    Active = OrderMockFactory.Order_8.Active,
                    Comments = OrderMockFactory.Order_8.Comments,
                    RublesPerDollar = OrderMockFactory.Order_8.RublesPerDollar,
                    CustomerPrepaid = OrderMockFactory.Order_8.CustomerPrepaid,
                    CustomerPaid = OrderMockFactory.Order_8.CustomerPaid,
                    DistributorSpentOnDelivery = 200m,
                    TrackingNumber = "GHJ9884753067576H",
                    Parcel = container.Get<IDtoService>().CreateParcel(OrderMockFactory.Order_8.Parcel)
                };

            var orderService = container.Get<IOrderService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => orderService.UpdateOrder(updatedOrder),
                "Only seller, purchaser and distributor can change order.");
        }

        [TestMethod]
        public void UpdateOrder_Should_Update_Order_When_Current_User_Is_Seller_Purchaser_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.DianaDistributor.Active = true;
            UserRoleMockFactory.DianaPurchaser.Active = true;
            UserRoleMockFactory.DianaAdministrator.Active = false;
            UserRoleMockFactory.DianaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var orderDate = new DateTime(2013, 7, 2);
            const string CUSTOMER_FIRST_NAME = "Вася";
            const string CUSTOMER_LAST_NAME = "Иванов";
            const string CUSTOMER_ADDRESS = "Волжский бульвар, дом 55, кв 80";
            const string CUSTOMER_CITY = "Москва";
            const string CUSTOMER_COUNTRY = "Россия";
            const string CUSTOMER_POSTAL_CODE = "909877";
            const string CUSTOMER_PHONE_NUMBER = "9267545808";
            const string CUSTOMER_EMAIL = "chyuck@mail.ru";
            const bool ACTIVE = false;
            const string COMMENTS = "Some comments";
            const decimal RUBLES_PER_DOLLAR = 31.5m;
            const decimal CUSTOMER_PREPAID = 1300m;
            const decimal CUSTOMER_PAID = 2500m;
            const decimal DISTRIBUTOR_SPENT_ON_DELIVERY = 200m;
            const string TRACKING_NUMBER = "GHJ9884753067576H";
            var parcel = container.Get<IDtoService>().CreateParcel(ParcelMockFactory.Parcel_3);
            var createDate = OrderMockFactory.Order_7.CreateDate;
            var createdBy = OrderMockFactory.Order_7.CreatedBy;


            var updatedOrder =
                new DTO.Order
                {
                    Id = OrderMockFactory.Order_7.Id,
                    OrderDate = orderDate,
                    CustomerFirstName = CUSTOMER_FIRST_NAME,
                    CustomerLastName = CUSTOMER_LAST_NAME,
                    CustomerAddress = CUSTOMER_ADDRESS,
                    CustomerCity = CUSTOMER_CITY,
                    CustomerCountry = CUSTOMER_COUNTRY,
                    CustomerPostalCode = CUSTOMER_POSTAL_CODE,
                    CustomerPhoneNumber = CUSTOMER_PHONE_NUMBER,
                    CustomerEmail = CUSTOMER_EMAIL,
                    Active = ACTIVE,
                    Comments = COMMENTS,
                    RublesPerDollar = RUBLES_PER_DOLLAR,
                    CustomerPrepaid = CUSTOMER_PREPAID,
                    DistributorSpentOnDelivery = DISTRIBUTOR_SPENT_ON_DELIVERY,
                    CustomerPaid = CUSTOMER_PAID,
                    TrackingNumber = TRACKING_NUMBER,
                    Parcel = parcel
                };

            var orderService = container.Get<IOrderService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            orderService.UpdateOrder(updatedOrder);

            // Assert
            var actualOrder = persistentService.GetEntityById<DataAccess.Order>(OrderMockFactory.Order_7.Id);

            Assert.AreEqual(updatedOrder.Id, actualOrder.Id);
            Assert.AreEqual(orderDate, actualOrder.OrderDate);
            Assert.AreEqual(CUSTOMER_FIRST_NAME, actualOrder.CustomerFirstName);
            Assert.AreEqual(CUSTOMER_LAST_NAME, actualOrder.CustomerLastName);
            Assert.AreEqual(CUSTOMER_ADDRESS, actualOrder.CustomerAddress);
            Assert.AreEqual(CUSTOMER_CITY, actualOrder.CustomerCity);
            Assert.AreEqual(CUSTOMER_COUNTRY, actualOrder.CustomerCountry);
            Assert.AreEqual(CUSTOMER_POSTAL_CODE, actualOrder.CustomerPostalCode);
            Assert.AreEqual(CUSTOMER_PHONE_NUMBER, actualOrder.CustomerPhoneNumber);
            Assert.AreEqual(CUSTOMER_EMAIL, actualOrder.CustomerEmail);
            Assert.AreEqual(ACTIVE, actualOrder.Active);
            Assert.AreEqual(COMMENTS, actualOrder.Comments);
            Assert.AreEqual(RUBLES_PER_DOLLAR, actualOrder.RublesPerDollar);
            Assert.AreEqual(CUSTOMER_PREPAID, actualOrder.CustomerPrepaid);
            Assert.AreEqual(DISTRIBUTOR_SPENT_ON_DELIVERY, actualOrder.DistributorSpentOnDelivery);
            Assert.AreEqual(CUSTOMER_PAID, actualOrder.CustomerPaid);
            Assert.AreEqual(TRACKING_NUMBER, actualOrder.TrackingNumber);
            Assert.AreEqual(parcel.Id, actualOrder.Parcel.Id);
            Assert.AreEqual(createDate, actualOrder.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualOrder.ChangeDate);
            Assert.AreEqual(createdBy, actualOrder.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualOrder.ChangedBy);

            Assert.AreEqual(updatedOrder, container.Get<IDtoService>().CreateOrder(actualOrder));
        }

        [TestMethod]
        public void UpdateOrder_Should_Update_Order_When_Current_User_Is_Seller_Purchaser_Distributor_And_Order_Is_Created_By_Another_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.DianaDistributor.Active = true;
            UserRoleMockFactory.DianaPurchaser.Active = true;
            UserRoleMockFactory.DianaAdministrator.Active = false;
            UserRoleMockFactory.DianaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            const decimal DISTRIBUTOR_SPENT_ON_DELIVERY = 200m;
            const string TRACKING_NUMBER = "GHJ9884753067576H";
            var parcel = container.Get<IDtoService>().CreateParcel(ParcelMockFactory.Parcel_3);
            var createDate = OrderMockFactory.Order_8.CreateDate;
            var createdBy = OrderMockFactory.Order_8.CreatedBy;
            var orderDate = OrderMockFactory.Order_8.OrderDate;
            var customerFirstName = OrderMockFactory.Order_8.CustomerFirstName;
            var customerLastName = OrderMockFactory.Order_8.CustomerLastName;
            var customerAddress = OrderMockFactory.Order_8.CustomerAddress;
            var customerCity = OrderMockFactory.Order_8.CustomerCity;
            var customerCountry = OrderMockFactory.Order_8.CustomerCountry;
            var customerPostalCode = OrderMockFactory.Order_8.CustomerPostalCode;
            var customerPhoneNumber = OrderMockFactory.Order_8.CustomerPhoneNumber;
            var customerEmail = OrderMockFactory.Order_8.CustomerEmail;
            var active = OrderMockFactory.Order_8.Active;
            var comments = OrderMockFactory.Order_8.Comments;
            var rublesPerDollar = OrderMockFactory.Order_8.RublesPerDollar;
            var customerPrepaid = OrderMockFactory.Order_8.CustomerPrepaid;
            var customerPaid = OrderMockFactory.Order_8.CustomerPaid;

            var updatedOrder =
                new DTO.Order
                {
                    Id = OrderMockFactory.Order_8.Id,
                    OrderDate = new DateTime(2013, 7, 2),
                    CustomerFirstName = "Вася",
                    CustomerLastName = "Иванов",
                    CustomerAddress = "Волжский бульвар, дом 55, кв 80",
                    CustomerCity = "Москва",
                    CustomerCountry = "Россия",
                    CustomerPostalCode = "909877",
                    CustomerPhoneNumber = "9267545808",
                    CustomerEmail = "chyuck@mail.ru",
                    Active = false,
                    Comments = "Some comments",
                    RublesPerDollar = 31.5m,
                    CustomerPrepaid = 1300m,
                    DistributorSpentOnDelivery = DISTRIBUTOR_SPENT_ON_DELIVERY,
                    CustomerPaid = 2500m,
                    TrackingNumber = TRACKING_NUMBER,
                    Parcel = parcel
                };

            var orderService = container.Get<IOrderService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            orderService.UpdateOrder(updatedOrder);

            // Assert
            var actualOrder = persistentService.GetEntityById<DataAccess.Order>(OrderMockFactory.Order_8.Id);

            Assert.AreEqual(updatedOrder.Id, actualOrder.Id);
            Assert.AreEqual(orderDate, actualOrder.OrderDate);
            Assert.AreEqual(customerFirstName, actualOrder.CustomerFirstName);
            Assert.AreEqual(customerLastName, actualOrder.CustomerLastName);
            Assert.AreEqual(customerAddress, actualOrder.CustomerAddress);
            Assert.AreEqual(customerCity, actualOrder.CustomerCity);
            Assert.AreEqual(customerCountry, actualOrder.CustomerCountry);
            Assert.AreEqual(customerPostalCode, actualOrder.CustomerPostalCode);
            Assert.AreEqual(customerPhoneNumber, actualOrder.CustomerPhoneNumber);
            Assert.AreEqual(customerEmail, actualOrder.CustomerEmail);
            Assert.AreEqual(active, actualOrder.Active);
            Assert.AreEqual(comments, actualOrder.Comments);
            Assert.AreEqual(rublesPerDollar, actualOrder.RublesPerDollar);
            Assert.AreEqual(customerPrepaid, actualOrder.CustomerPrepaid);
            Assert.AreEqual(DISTRIBUTOR_SPENT_ON_DELIVERY, actualOrder.DistributorSpentOnDelivery);
            Assert.AreEqual(customerPaid, actualOrder.CustomerPaid);
            Assert.AreEqual(TRACKING_NUMBER, actualOrder.TrackingNumber);
            Assert.AreEqual(parcel.Id, actualOrder.Parcel.Id);
            Assert.AreEqual(createDate, actualOrder.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualOrder.ChangeDate);
            Assert.AreEqual(createdBy, actualOrder.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualOrder.ChangedBy);

            Assert.AreEqual(updatedOrder, container.Get<IDtoService>().CreateOrder(actualOrder));
        }

        [TestMethod]
        public void UpdateOrder_Should_Update_Order_When_Current_User_Is_Seller_Purchaser_Distributor_And_Order_Is_Included_In_Parcel_Assigned_To_Another_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.DianaDistributor.Active = true;
            UserRoleMockFactory.DianaPurchaser.Active = true;
            UserRoleMockFactory.DianaAdministrator.Active = false;
            UserRoleMockFactory.DianaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var orderDate = new DateTime(2013, 7, 2);
            const string CUSTOMER_FIRST_NAME = "Вася";
            const string CUSTOMER_LAST_NAME = "Иванов";
            const string CUSTOMER_ADDRESS = "Волжский бульвар, дом 55, кв 80";
            const string CUSTOMER_CITY = "Москва";
            const string CUSTOMER_COUNTRY = "Россия";
            const string CUSTOMER_POSTAL_CODE = "909877";
            const string CUSTOMER_PHONE_NUMBER = "9267545808";
            const string CUSTOMER_EMAIL = "chyuck@mail.ru";
            const bool ACTIVE = false;
            const string COMMENTS = "Some comments";
            const decimal RUBLES_PER_DOLLAR = 31.5m;
            const decimal CUSTOMER_PREPAID = 1300m;
            const decimal CUSTOMER_PAID = 2500m;
            var parcel = container.Get<IDtoService>().CreateParcel(ParcelMockFactory.Parcel_3);
            var createDate = OrderMockFactory.Order_4.CreateDate;
            var createdBy = OrderMockFactory.Order_4.CreatedBy;
            var distributorSpentOnDelivery = OrderMockFactory.Order_4.DistributorSpentOnDelivery;
            var trackingNumber = OrderMockFactory.Order_4.TrackingNumber;

            var updatedOrder =
                new DTO.Order
                {
                    Id = OrderMockFactory.Order_4.Id,
                    OrderDate = orderDate,
                    CustomerFirstName = CUSTOMER_FIRST_NAME,
                    CustomerLastName = CUSTOMER_LAST_NAME,
                    CustomerAddress = CUSTOMER_ADDRESS,
                    CustomerCity = CUSTOMER_CITY,
                    CustomerCountry = CUSTOMER_COUNTRY,
                    CustomerPostalCode = CUSTOMER_POSTAL_CODE,
                    CustomerPhoneNumber = CUSTOMER_PHONE_NUMBER,
                    CustomerEmail = CUSTOMER_EMAIL,
                    Active = ACTIVE,
                    Comments = COMMENTS,
                    RublesPerDollar = RUBLES_PER_DOLLAR,
                    CustomerPrepaid = CUSTOMER_PREPAID,
                    DistributorSpentOnDelivery = 200m,
                    CustomerPaid = CUSTOMER_PAID,
                    TrackingNumber = "GHJ9884753067576H",
                    Parcel = parcel
                };

            var orderService = container.Get<IOrderService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            orderService.UpdateOrder(updatedOrder);

            // Assert
            var actualOrder = persistentService.GetEntityById<DataAccess.Order>(OrderMockFactory.Order_4.Id);

            Assert.AreEqual(updatedOrder.Id, actualOrder.Id);
            Assert.AreEqual(orderDate, actualOrder.OrderDate);
            Assert.AreEqual(CUSTOMER_FIRST_NAME, actualOrder.CustomerFirstName);
            Assert.AreEqual(CUSTOMER_LAST_NAME, actualOrder.CustomerLastName);
            Assert.AreEqual(CUSTOMER_ADDRESS, actualOrder.CustomerAddress);
            Assert.AreEqual(CUSTOMER_CITY, actualOrder.CustomerCity);
            Assert.AreEqual(CUSTOMER_COUNTRY, actualOrder.CustomerCountry);
            Assert.AreEqual(CUSTOMER_POSTAL_CODE, actualOrder.CustomerPostalCode);
            Assert.AreEqual(CUSTOMER_PHONE_NUMBER, actualOrder.CustomerPhoneNumber);
            Assert.AreEqual(CUSTOMER_EMAIL, actualOrder.CustomerEmail);
            Assert.AreEqual(ACTIVE, actualOrder.Active);
            Assert.AreEqual(COMMENTS, actualOrder.Comments);
            Assert.AreEqual(RUBLES_PER_DOLLAR, actualOrder.RublesPerDollar);
            Assert.AreEqual(CUSTOMER_PREPAID, actualOrder.CustomerPrepaid);
            Assert.AreEqual(distributorSpentOnDelivery, actualOrder.DistributorSpentOnDelivery);
            Assert.AreEqual(CUSTOMER_PAID, actualOrder.CustomerPaid);
            Assert.AreEqual(trackingNumber, actualOrder.TrackingNumber);
            Assert.AreEqual(parcel.Id, actualOrder.Parcel.Id);
            Assert.AreEqual(createDate, actualOrder.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualOrder.ChangeDate);
            Assert.AreEqual(createdBy, actualOrder.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualOrder.ChangedBy);

            Assert.AreEqual(updatedOrder, container.Get<IDtoService>().CreateOrder(actualOrder));
        }

        [TestMethod]
        public void CreateOrderItem_Should_Create_OrderItem()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = false;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            const decimal PRICE = 2200m;
            const int QUANTITY = 3;
            const bool ACTIVE = true;
            var order = container.Get<IDtoService>().CreateOrder(OrderMockFactory.Order_5);
            var productSize = container.Get<IDtoService>().CreateProductSize(ProductSizeMockFactory.Girls_Sweater_0_3_Months);

            var createdOrderItem =
                new DTO.OrderItem
                {
                    Price = PRICE,
                    Quantity = QUANTITY,
                    Active = ACTIVE,
                    PurchaserPaid = 23m,
                    Order = order,
                    ProductSize = productSize
                };

            var orderService = container.Get<IOrderService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            orderService.CreateOrderItem(createdOrderItem);

            // Assert
            Assert.IsTrue(createdOrderItem.Id > 0);

            var actualOrderItem = persistentService.GetEntityById<OrderItem>(createdOrderItem.Id);

            Assert.AreEqual(createdOrderItem.Id, actualOrderItem.Id);
            Assert.AreEqual(PRICE, actualOrderItem.Price);
            Assert.AreEqual(QUANTITY, actualOrderItem.Quantity);
            Assert.AreEqual(ACTIVE, actualOrderItem.Active);
            Assert.AreEqual(0, actualOrderItem.PurchaserPaid);
            Assert.AreEqual(order.Id, actualOrderItem.Order.Id);
            Assert.AreEqual(productSize.Id, actualOrderItem.ProductSize.Id);
            Assert.AreEqual(timeService.UtcNow, actualOrderItem.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualOrderItem.ChangeDate);
            Assert.AreEqual(UserMockFactory.Jenya, actualOrderItem.CreatedBy);
            Assert.AreEqual(UserMockFactory.Jenya, actualOrderItem.ChangedBy);

            Assert.AreEqual(createdOrderItem, container.Get<IDtoService>().CreateOrderItem(actualOrderItem));
        }

        [TestMethod]
        public void CreateOrderItem_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = true;
            UserRoleMockFactory.JenyaPurchaser.Active = true;
            UserRoleMockFactory.JenyaAdministrator.Active = true;
            UserRoleMockFactory.JenyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var createdOrderItem =
                new DTO.OrderItem
                {
                    Price = 2200m,
                    Quantity = 3,
                    Active = true,
                    PurchaserPaid = 23m,
                    Order = container.Get<IDtoService>().CreateOrder(OrderMockFactory.Order_5),
                    ProductSize = container.Get<IDtoService>().CreateProductSize(ProductSizeMockFactory.Girls_Sweater_0_3_Months)
                };

            var orderService = container.Get<IOrderService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => orderService.CreateOrderItem(createdOrderItem),
                "Only seller can create order item.");
        }

        [TestMethod]
        public void CreateOrderItem_Should_Throw_Exception_When_Current_User_Is_Seller_But_Order_Is_Created_By_Another_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = false;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var createdOrderItem =
                new DTO.OrderItem
                {
                    Price = 2200m,
                    Quantity = 3,
                    Active = true,
                    PurchaserPaid = 23m,
                    Order = container.Get<IDtoService>().CreateOrder(OrderMockFactory.Order_6),
                    ProductSize = container.Get<IDtoService>().CreateProductSize(ProductSizeMockFactory.Boys_Sweater_0_3_Months)
                };

            var orderService = container.Get<IOrderService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => orderService.CreateOrderItem(createdOrderItem),
                "Order is created by another seller.");
        }

        [TestMethod]
        public void CreateOrderItem_Should_Throw_Exception_When_OrderItem_With_ProductSize_Already_Exist()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = false;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            const decimal PRICE = 2200m;
            const int QUANTITY = 3;
            const bool ACTIVE = true;
            var order = container.Get<IDtoService>().CreateOrder(OrderMockFactory.Order_5);
            var productSize = container.Get<IDtoService>().CreateProductSize(ProductSizeMockFactory.Boys_Sweater_0_3_Months);

            var createdOrderItem =
                new DTO.OrderItem
                {
                    Price = PRICE,
                    Quantity = QUANTITY,
                    Active = ACTIVE,
                    Order = order,
                    ProductSize = productSize
                };

            var orderService = container.Get<IOrderService>();

            // Act
            // Assert
            ExceptionAssert.Throw<OrderServiceException>(
                () => orderService.CreateOrderItem(createdOrderItem),
                "Строка заказа с заданным размером товара уже существует в текущем заказе.");
        }

        [TestMethod]
        public void UpdateOrderItem_Should_Update_OrderItem_When_Current_User_Is_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = false;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            const decimal PRICE = 2200m;
            const int QUANTITY = 3;
            const bool ACTIVE = true;
            var order = container.Get<IDtoService>().CreateOrder(OrderMockFactory.Order_5);
            var productSize = container.Get<IDtoService>().CreateProductSize(ProductSizeMockFactory.Girls_Sweater_0_3_Months);
            var createDate = OrderItemMockFactory.OrderItem_8.CreateDate;
            var createdBy = OrderItemMockFactory.OrderItem_8.CreatedBy;
            var purchaserPaid = OrderItemMockFactory.OrderItem_8.PurchaserPaid;

            var updatedOrderItem =
                new DTO.OrderItem
                {
                    Id = OrderItemMockFactory.OrderItem_8.Id,
                    Price = PRICE,
                    Quantity = QUANTITY,
                    Active = ACTIVE,
                    PurchaserPaid = 23m,
                    Order = order,
                    ProductSize = productSize
                };

            var orderService = container.Get<IOrderService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            orderService.UpdateOrderItem(updatedOrderItem);

            // Assert
            var actualOrderItem = persistentService.GetEntityById<OrderItem>(updatedOrderItem.Id);

            Assert.AreEqual(updatedOrderItem.Id, actualOrderItem.Id);
            Assert.AreEqual(PRICE, actualOrderItem.Price);
            Assert.AreEqual(QUANTITY, actualOrderItem.Quantity);
            Assert.AreEqual(ACTIVE, actualOrderItem.Active);
            Assert.AreEqual(purchaserPaid, actualOrderItem.PurchaserPaid);
            Assert.AreEqual(order.Id, actualOrderItem.Order.Id);
            Assert.AreEqual(productSize.Id, actualOrderItem.ProductSize.Id);
            Assert.AreEqual(createDate, actualOrderItem.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualOrderItem.ChangeDate);
            Assert.AreEqual(createdBy, actualOrderItem.CreatedBy);
            Assert.AreEqual(UserMockFactory.Jenya, actualOrderItem.ChangedBy);

            Assert.AreEqual(updatedOrderItem, container.Get<IDtoService>().CreateOrderItem(actualOrderItem));
        }

        [TestMethod]
        public void UpdateOrderItem_Should_Update_OrderItem_When_Current_User_Is_Purchaser()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = true;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            const decimal PURCHASER_PAID = 23m;
            var createDate = OrderItemMockFactory.OrderItem_8.CreateDate;
            var createdBy = OrderItemMockFactory.OrderItem_8.CreatedBy;
            var price = OrderItemMockFactory.OrderItem_8.Price;
            var quantity = OrderItemMockFactory.OrderItem_8.Quantity;
            var active = OrderItemMockFactory.OrderItem_8.Active;
            var order = OrderItemMockFactory.OrderItem_8.Order;
            var productSize = OrderItemMockFactory.OrderItem_8.ProductSize;

            var updatedOrderItem =
                new DTO.OrderItem
                {
                    Id = OrderItemMockFactory.OrderItem_8.Id,
                    Price = 2200m,
                    Quantity = 3,
                    Active = false,
                    PurchaserPaid = PURCHASER_PAID,
                    Order = container.Get<IDtoService>().CreateOrder(OrderMockFactory.Order_5),
                    ProductSize = container.Get<IDtoService>().CreateProductSize(ProductSizeMockFactory.Girls_Sweater_0_3_Months)
                };

            var orderService = container.Get<IOrderService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            orderService.UpdateOrderItem(updatedOrderItem);

            // Assert
            var actualOrderItem = persistentService.GetEntityById<OrderItem>(updatedOrderItem.Id);

            Assert.AreEqual(updatedOrderItem.Id, actualOrderItem.Id);
            Assert.AreEqual(price, actualOrderItem.Price);
            Assert.AreEqual(quantity, actualOrderItem.Quantity);
            Assert.AreEqual(active, actualOrderItem.Active);
            Assert.AreEqual(PURCHASER_PAID, actualOrderItem.PurchaserPaid);
            Assert.AreEqual(order, actualOrderItem.Order);
            Assert.AreEqual(productSize, actualOrderItem.ProductSize);
            Assert.AreEqual(createDate, actualOrderItem.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualOrderItem.ChangeDate);
            Assert.AreEqual(createdBy, actualOrderItem.CreatedBy);
            Assert.AreEqual(UserMockFactory.Jenya, actualOrderItem.ChangedBy);

            Assert.AreEqual(updatedOrderItem, container.Get<IDtoService>().CreateOrderItem(actualOrderItem));
        }

        [TestMethod]
        public void UpdateOrderItem_Should_Throw_Exception_When_Current_User_Is_Not_Seller_And_Purchaser()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = true;
            UserRoleMockFactory.JenyaPurchaser.Active = false;
            UserRoleMockFactory.JenyaAdministrator.Active = true;
            UserRoleMockFactory.JenyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var updatedOrderItem =
                new DTO.OrderItem
                {
                    Id = OrderItemMockFactory.OrderItem_8.Id,
                    Price = 2200m,
                    Quantity = 3,
                    Active = true,
                    PurchaserPaid = 23m,
                    Order = container.Get<IDtoService>().CreateOrder(OrderMockFactory.Order_5),
                    ProductSize = container.Get<IDtoService>().CreateProductSize(ProductSizeMockFactory.Girls_Sweater_0_3_Months)
                };

            var orderService = container.Get<IOrderService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => orderService.UpdateOrderItem(updatedOrderItem),
                "Only seller and purchaser can change order item.");
        }

        [TestMethod]
        public void UpdateOrderItem_Should_Throw_Exception_When_Current_User_Is_Seller_But_Order_Is_Created_By_Another_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = false;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var updatedOrderItem =
                new DTO.OrderItem
                {
                    Id = OrderItemMockFactory.OrderItem_10.Id,
                    Price = 2200m,
                    Quantity = 3,
                    Active = true,
                    PurchaserPaid = 23m,
                    Order = container.Get<IDtoService>().CreateOrder(OrderMockFactory.Order_7),
                    ProductSize = container.Get<IDtoService>().CreateProductSize(ProductSizeMockFactory.Girls_Sweater_0_3_Months)
                };

            var orderService = container.Get<IOrderService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => orderService.UpdateOrderItem(updatedOrderItem),
                "Order is created by another seller.");
        }

        [TestMethod]
        public void UpdateOrderItem_Should_Update_OrderItem_When_Current_User_Is_Seller_And_Purchaser_And_Order_Is_Created_By_Another_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = true;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            const decimal PURCHASER_PAID = 23m;
            var createDate = OrderItemMockFactory.OrderItem_10.CreateDate;
            var createdBy = OrderItemMockFactory.OrderItem_10.CreatedBy;
            var price = OrderItemMockFactory.OrderItem_10.Price;
            var quantity = OrderItemMockFactory.OrderItem_10.Quantity;
            var active = OrderItemMockFactory.OrderItem_10.Active;
            var order = OrderItemMockFactory.OrderItem_10.Order;
            var productSize = OrderItemMockFactory.OrderItem_10.ProductSize;

            var updatedOrderItem =
                new DTO.OrderItem
                {
                    Id = OrderItemMockFactory.OrderItem_10.Id,
                    Price = 2200m,
                    Quantity = 3,
                    Active = false,
                    PurchaserPaid = PURCHASER_PAID,
                    Order = container.Get<IDtoService>().CreateOrder(OrderMockFactory.Order_4),
                    ProductSize = container.Get<IDtoService>().CreateProductSize(ProductSizeMockFactory.Girls_Sweater_0_3_Months)
                };

            var orderService = container.Get<IOrderService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            orderService.UpdateOrderItem(updatedOrderItem);

            // Assert
            var actualOrderItem = persistentService.GetEntityById<OrderItem>(updatedOrderItem.Id);

            Assert.AreEqual(updatedOrderItem.Id, actualOrderItem.Id);
            Assert.AreEqual(price, actualOrderItem.Price);
            Assert.AreEqual(quantity, actualOrderItem.Quantity);
            Assert.AreEqual(active, actualOrderItem.Active);
            Assert.AreEqual(PURCHASER_PAID, actualOrderItem.PurchaserPaid);
            Assert.AreEqual(order, actualOrderItem.Order);
            Assert.AreEqual(productSize, actualOrderItem.ProductSize);
            Assert.AreEqual(createDate, actualOrderItem.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualOrderItem.ChangeDate);
            Assert.AreEqual(createdBy, actualOrderItem.CreatedBy);
            Assert.AreEqual(UserMockFactory.Jenya, actualOrderItem.ChangedBy);

            Assert.AreEqual(updatedOrderItem, container.Get<IDtoService>().CreateOrderItem(actualOrderItem));
        }

        [TestMethod]
        public void UpdateOrderItem_Should_Update_OrderItem_When_Current_User_Is_Seller_And_Purchaser_And_Order_Is_Created_By_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = true;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            const decimal PRICE = 2200m;
            const int QUANTITY = 3;
            const bool ACTIVE = true;
            const decimal PURCHASER_PAID = 23m;
            var order = container.Get<IDtoService>().CreateOrder(OrderMockFactory.Order_5);
            var productSize = container.Get<IDtoService>().CreateProductSize(ProductSizeMockFactory.Girls_Sweater_0_3_Months);
            var createDate = OrderItemMockFactory.OrderItem_8.CreateDate;
            var createdBy = OrderItemMockFactory.OrderItem_8.CreatedBy;

            var updatedOrderItem =
                new DTO.OrderItem
                {
                    Id = OrderItemMockFactory.OrderItem_8.Id,
                    Price = PRICE,
                    Quantity = QUANTITY,
                    Active = ACTIVE,
                    PurchaserPaid = PURCHASER_PAID,
                    Order = order,
                    ProductSize = productSize
                };

            var orderService = container.Get<IOrderService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            orderService.UpdateOrderItem(updatedOrderItem);

            // Assert
            var actualOrderItem = persistentService.GetEntityById<OrderItem>(updatedOrderItem.Id);

            Assert.AreEqual(updatedOrderItem.Id, actualOrderItem.Id);
            Assert.AreEqual(PRICE, actualOrderItem.Price);
            Assert.AreEqual(QUANTITY, actualOrderItem.Quantity);
            Assert.AreEqual(ACTIVE, actualOrderItem.Active);
            Assert.AreEqual(PURCHASER_PAID, actualOrderItem.PurchaserPaid);
            Assert.AreEqual(order.Id, actualOrderItem.Order.Id);
            Assert.AreEqual(productSize.Id, actualOrderItem.ProductSize.Id);
            Assert.AreEqual(createDate, actualOrderItem.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualOrderItem.ChangeDate);
            Assert.AreEqual(createdBy, actualOrderItem.CreatedBy);
            Assert.AreEqual(UserMockFactory.Jenya, actualOrderItem.ChangedBy);

            Assert.AreEqual(updatedOrderItem, container.Get<IDtoService>().CreateOrderItem(actualOrderItem));
        }

        [TestMethod]
        public void UpdateOrderItem_Should_Throw_Exception_When_OrderItem_With_ProductSize_Already_Exist()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = false;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            const decimal PRICE = 2200m;
            const int QUANTITY = 3;
            const bool ACTIVE = true;
            var order = container.Get<IDtoService>().CreateOrder(OrderMockFactory.Order_2);
            var productSize = container.Get<IDtoService>().CreateProductSize(ProductSizeMockFactory.Boys_Sweater_0_3_Months);

            var updatedOrderItem =
                new DTO.OrderItem
                {
                    Id = OrderItemMockFactory.OrderItem_4.Id,
                    Price = PRICE,
                    Quantity = QUANTITY,
                    Active = ACTIVE,
                    PurchaserPaid = 23m,
                    Order = order,
                    ProductSize = productSize
                };

            var orderService = container.Get<IOrderService>();

            // Act
            // Assert
            ExceptionAssert.Throw<OrderServiceException>(
                () => orderService.UpdateOrderItem(updatedOrderItem),
                "Строка заказа с заданным размером товара уже существует в текущем заказе.");
        }
    }
}
