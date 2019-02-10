using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.BusinessLogic.Report;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.BusinessLogic.Test.Extensions;
using USClothesWebSite.BusinessLogic.Test.Mocks;
using USClothesWebSite.Common.Extensions;
using USClothesWebSite.DTO;
using USClothesWebSite.BusinessLogic.Extensions;
using USClothesWebSite.Test.Common;

namespace USClothesWebSite.BusinessLogic.Test
{
    [TestClass]
    public class ReportServiceTest
    {
        #region Expected Data

        private static ParcelReportItem GetParcelReportItem1()
        {
            var parcelReportItem =
                new ParcelReportItem
                {
                    Id = ParcelMockFactory.Parcel_1.Id,

                    ParcelName = DTO.Parcel.GetParcelName(ParcelMockFactory.Parcel_1.Id),
                    SentDate = ParcelMockFactory.Parcel_1.SentDate,
                    ReceivedDate = ParcelMockFactory.Parcel_1.ReceivedDate,
                    DistributorName = UserMockFactory.Olesya.GetFullName(),
                    PurchaserPaid =
                        // Order 1
                        OrderItemMockFactory.OrderItem_2.PurchaserPaid +
                        OrderItemMockFactory.OrderItem_6.PurchaserPaid +
                        // Order 2
                        OrderItemMockFactory.OrderItem_3.PurchaserPaid +
                        OrderItemMockFactory.OrderItem_4.PurchaserPaid,
                    PurchaserSpentOnDelivery = ParcelMockFactory.Parcel_1.PurchaserSpentOnDelivery,
                    DistributorSpentOnDelivery =
                        (OrderMockFactory.Order_1.DistributorSpentOnDelivery / OrderMockFactory.Order_1.RublesPerDollar).ToMoney() +
                        (OrderMockFactory.Order_2.DistributorSpentOnDelivery / OrderMockFactory.Order_2.RublesPerDollar).ToMoney(),
                    CustomersPrepaid =
                        (OrderMockFactory.Order_1.CustomerPrepaid / OrderMockFactory.Order_1.RublesPerDollar).ToMoney() +
                        (OrderMockFactory.Order_2.CustomerPrepaid / OrderMockFactory.Order_2.RublesPerDollar).ToMoney(),
                    CustomersPaid =
                        (OrderMockFactory.Order_1.CustomerPaid / OrderMockFactory.Order_1.RublesPerDollar).ToMoney() +
                        (OrderMockFactory.Order_2.CustomerPaid / OrderMockFactory.Order_2.RublesPerDollar).ToMoney(),
                    ExpectedTotalCustomerPaid =
                        // Order 1
                        (OrderItemMockFactory.OrderItem_2.TotalPrice / OrderMockFactory.Order_1.RublesPerDollar).ToMoney() +
                        (OrderItemMockFactory.OrderItem_6.TotalPrice / OrderMockFactory.Order_1.RublesPerDollar).ToMoney() +
                        // Order 2
                        (OrderItemMockFactory.OrderItem_3.TotalPrice / OrderMockFactory.Order_2.RublesPerDollar).ToMoney() +
                        (OrderItemMockFactory.OrderItem_4.TotalPrice / OrderMockFactory.Order_2.RublesPerDollar).ToMoney()
                };
            parcelReportItem.TotalPaid =
                parcelReportItem.PurchaserPaid +
                parcelReportItem.PurchaserSpentOnDelivery +
                parcelReportItem.DistributorSpentOnDelivery;
            parcelReportItem.TotalCustomersPaid =
                parcelReportItem.CustomersPrepaid +
                parcelReportItem.CustomersPaid;
            parcelReportItem.TotalProfit =
                parcelReportItem.TotalCustomersPaid - parcelReportItem.TotalPaid;
            parcelReportItem.ExpectedTotalProfit =
                parcelReportItem.ExpectedTotalCustomerPaid - parcelReportItem.TotalPaid;

            return parcelReportItem;
        }

        private static ParcelReportItem GetParcelReportItem2()
        {
            var parcelReportItem =
                new ParcelReportItem
                {
                    Id = ParcelMockFactory.Parcel_2.Id,

                    ParcelName = DTO.Parcel.GetParcelName(ParcelMockFactory.Parcel_2.Id),
                    SentDate = ParcelMockFactory.Parcel_2.SentDate,
                    ReceivedDate = ParcelMockFactory.Parcel_2.ReceivedDate,
                    DistributorName = UserMockFactory.Diana.GetFullName(),
                    PurchaserPaid =
                        // Order 7
                        OrderItemMockFactory.OrderItem_10.PurchaserPaid +
                        // Order 8
                        OrderItemMockFactory.OrderItem_11.PurchaserPaid,
                    PurchaserSpentOnDelivery = ParcelMockFactory.Parcel_2.PurchaserSpentOnDelivery,
                    DistributorSpentOnDelivery =
                        (OrderMockFactory.Order_7.DistributorSpentOnDelivery / OrderMockFactory.Order_7.RublesPerDollar).ToMoney() +
                        (OrderMockFactory.Order_8.DistributorSpentOnDelivery / OrderMockFactory.Order_8.RublesPerDollar).ToMoney(),
                    CustomersPrepaid =
                        (OrderMockFactory.Order_7.CustomerPrepaid / OrderMockFactory.Order_7.RublesPerDollar).ToMoney() +
                        (OrderMockFactory.Order_8.CustomerPrepaid / OrderMockFactory.Order_8.RublesPerDollar).ToMoney(),
                    CustomersPaid =
                        (OrderMockFactory.Order_7.CustomerPaid / OrderMockFactory.Order_7.RublesPerDollar).ToMoney() +
                        (OrderMockFactory.Order_8.CustomerPaid / OrderMockFactory.Order_8.RublesPerDollar).ToMoney(),
                    ExpectedTotalCustomerPaid =
                        // Order 7
                        (OrderItemMockFactory.OrderItem_10.TotalPrice / OrderMockFactory.Order_7.RublesPerDollar).ToMoney() +
                        // Order 8
                        (OrderItemMockFactory.OrderItem_11.TotalPrice / OrderMockFactory.Order_8.RublesPerDollar).ToMoney()
                };
            parcelReportItem.TotalPaid =
                parcelReportItem.PurchaserPaid +
                parcelReportItem.PurchaserSpentOnDelivery +
                parcelReportItem.DistributorSpentOnDelivery;
            parcelReportItem.TotalCustomersPaid =
                parcelReportItem.CustomersPrepaid +
                parcelReportItem.CustomersPaid;
            parcelReportItem.TotalProfit =
                parcelReportItem.TotalCustomersPaid - parcelReportItem.TotalPaid;
            parcelReportItem.ExpectedTotalProfit =
                parcelReportItem.ExpectedTotalCustomerPaid - parcelReportItem.TotalPaid;

            return parcelReportItem;
        }

        private static ParcelReportItem GetParcelReportItem3()
        {
            var parcelReportItem =
                new ParcelReportItem
                {
                    Id = ParcelMockFactory.Parcel_3.Id,

                    ParcelName = DTO.Parcel.GetParcelName(ParcelMockFactory.Parcel_3.Id),
                    SentDate = ParcelMockFactory.Parcel_3.SentDate,
                    ReceivedDate = ParcelMockFactory.Parcel_3.ReceivedDate,
                    DistributorName = string.Empty,
                    PurchaserPaid =
                        // Order 5
                        OrderItemMockFactory.OrderItem_8.PurchaserPaid,
                    PurchaserSpentOnDelivery = ParcelMockFactory.Parcel_2.PurchaserSpentOnDelivery,
                    DistributorSpentOnDelivery =
                        (OrderMockFactory.Order_5.DistributorSpentOnDelivery / OrderMockFactory.Order_5.RublesPerDollar).ToMoney(),
                    CustomersPrepaid =
                        (OrderMockFactory.Order_5.CustomerPrepaid / OrderMockFactory.Order_5.RublesPerDollar).ToMoney(),
                    CustomersPaid =
                        (OrderMockFactory.Order_5.CustomerPaid / OrderMockFactory.Order_5.RublesPerDollar).ToMoney(),
                    ExpectedTotalCustomerPaid =
                        // Order 5
                        (OrderItemMockFactory.OrderItem_8.TotalPrice / OrderMockFactory.Order_5.RublesPerDollar).ToMoney()
                };
            parcelReportItem.TotalPaid =
                parcelReportItem.PurchaserPaid +
                parcelReportItem.PurchaserSpentOnDelivery +
                parcelReportItem.DistributorSpentOnDelivery;
            parcelReportItem.TotalCustomersPaid =
                parcelReportItem.CustomersPrepaid +
                parcelReportItem.CustomersPaid;
            parcelReportItem.TotalProfit =
                parcelReportItem.TotalCustomersPaid - parcelReportItem.TotalPaid;
            parcelReportItem.ExpectedTotalProfit =
                parcelReportItem.ExpectedTotalCustomerPaid - parcelReportItem.TotalPaid;

            return parcelReportItem;
        }

        private static DistributorReportItem GetOlesyaReportItem()
        {
            var distributorReportItem =
                new DistributorReportItem
                {
                    Id = UserMockFactory.Olesya.Id,

                    DistributorName = UserMockFactory.Olesya.GetFullName(),
                    DistributorSpent =
                        (DistributorTransferMockFactory.Olesya_Transfer_1.Amount / DistributorTransferMockFactory.Olesya_Transfer_1.RublesPerDollar).ToMoney() + 
                        (DistributorTransferMockFactory.Olesya_Transfer_2.Amount / DistributorTransferMockFactory.Olesya_Transfer_2.RublesPerDollar).ToMoney() +
                        (OrderMockFactory.Order_1.DistributorSpentOnDelivery / OrderMockFactory.Order_1.RublesPerDollar).ToMoney() +
                        (OrderMockFactory.Order_2.DistributorSpentOnDelivery / OrderMockFactory.Order_2.RublesPerDollar).ToMoney(),
                    DistributorReceived =
                        (OrderMockFactory.Order_1.CustomerPrepaid / OrderMockFactory.Order_1.RublesPerDollar).ToMoney() +
                        (OrderMockFactory.Order_2.CustomerPrepaid / OrderMockFactory.Order_2.RublesPerDollar).ToMoney() +
                        (OrderMockFactory.Order_1.CustomerPaid / OrderMockFactory.Order_1.RublesPerDollar).ToMoney() +
                        (OrderMockFactory.Order_2.CustomerPaid / OrderMockFactory.Order_2.RublesPerDollar).ToMoney(),
                    PurchaserSpent =
                        // Order 1
                        OrderItemMockFactory.OrderItem_2.PurchaserPaid +
                        OrderItemMockFactory.OrderItem_6.PurchaserPaid +
                        // Order 2
                        OrderItemMockFactory.OrderItem_3.PurchaserPaid +
                        OrderItemMockFactory.OrderItem_4.PurchaserPaid +
                        ParcelMockFactory.Parcel_1.PurchaserSpentOnDelivery,
                    PurchaserReceived = 
                        (DistributorTransferMockFactory.Olesya_Transfer_1.Amount / DistributorTransferMockFactory.Olesya_Transfer_1.RublesPerDollar).ToMoney() + 
                        (DistributorTransferMockFactory.Olesya_Transfer_2.Amount / DistributorTransferMockFactory.Olesya_Transfer_2.RublesPerDollar).ToMoney()
                };

            distributorReportItem.DistributorBalance = 
                distributorReportItem.DistributorSpent - distributorReportItem.DistributorReceived;
            distributorReportItem.PurchaserBalance =
                distributorReportItem.PurchaserSpent - distributorReportItem.PurchaserReceived;
            distributorReportItem.TotalBalance =
                ((distributorReportItem.PurchaserBalance - distributorReportItem.DistributorBalance) / 2).ToMoney();

            return distributorReportItem;
        }

        private static DistributorReportItem GetDianaReportItem()
        {
            var distributorReportItem =
                new DistributorReportItem
                {
                    Id = UserMockFactory.Diana.Id,

                    DistributorName = UserMockFactory.Diana.GetFullName(),
                    DistributorSpent =
                        (DistributorTransferMockFactory.Diana_Transfer_1.Amount / DistributorTransferMockFactory.Diana_Transfer_1.RublesPerDollar).ToMoney() +
                        (DistributorTransferMockFactory.Diana_Transfer_2.Amount / DistributorTransferMockFactory.Diana_Transfer_2.RublesPerDollar).ToMoney() +
                        (OrderMockFactory.Order_7.DistributorSpentOnDelivery / OrderMockFactory.Order_7.RublesPerDollar).ToMoney() +
                        (OrderMockFactory.Order_8.DistributorSpentOnDelivery / OrderMockFactory.Order_8.RublesPerDollar).ToMoney(),
                    DistributorReceived =
                        (OrderMockFactory.Order_7.CustomerPrepaid / OrderMockFactory.Order_7.RublesPerDollar).ToMoney() +
                        (OrderMockFactory.Order_8.CustomerPrepaid / OrderMockFactory.Order_8.RublesPerDollar).ToMoney() +
                        (OrderMockFactory.Order_7.CustomerPaid / OrderMockFactory.Order_7.RublesPerDollar).ToMoney() +
                        (OrderMockFactory.Order_8.CustomerPaid / OrderMockFactory.Order_8.RublesPerDollar).ToMoney(),
                    PurchaserSpent =
                        // Order 7
                        OrderItemMockFactory.OrderItem_10.PurchaserPaid +
                        // Order 8
                        OrderItemMockFactory.OrderItem_11.PurchaserPaid +
                        ParcelMockFactory.Parcel_2.PurchaserSpentOnDelivery,
                    PurchaserReceived =
                        (DistributorTransferMockFactory.Diana_Transfer_1.Amount / DistributorTransferMockFactory.Diana_Transfer_1.RublesPerDollar).ToMoney() +
                        (DistributorTransferMockFactory.Diana_Transfer_2.Amount / DistributorTransferMockFactory.Diana_Transfer_2.RublesPerDollar).ToMoney()
                };

            distributorReportItem.DistributorBalance =
                distributorReportItem.DistributorSpent - distributorReportItem.DistributorReceived;
            distributorReportItem.PurchaserBalance =
                distributorReportItem.PurchaserSpent - distributorReportItem.PurchaserReceived;
            distributorReportItem.TotalBalance =
                ((distributorReportItem.PurchaserBalance - distributorReportItem.DistributorBalance) / 2).ToMoney();

            return distributorReportItem;
        }

        #endregion


        #region Tests

        [TestMethod]
        public void GenerateParcelsReport_Should_Generate_Report_When_Current_User_Is_Purchaser()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = true;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var reportService = container.Get<IReportService>();

            // Act
            var parcelReportItems = reportService.GenerateParcelsReport();

            // Assert
            var expectedParcelReportItems =
                new[]
                {
                    GetParcelReportItem1(),
                    GetParcelReportItem2(),
                    GetParcelReportItem3()
                };

            CollectionAssert.AreEqual(expectedParcelReportItems, parcelReportItems);
        }

        [TestMethod]
        public void GenerateParcelsReport_Should_Generate_Report_When_Current_User_Is_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.OlesyaDistributor.Active = true;
            UserRoleMockFactory.OlesyaPurchaser.Active = false;
            UserRoleMockFactory.OlesyaAdministrator.Active = false;
            UserRoleMockFactory.OlesyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var reportService = container.Get<IReportService>();

            // Act
            var parcelReportItems = reportService.GenerateParcelsReport();

            // Assert
            var expectedParcelReportItems =
                new[]
                {
                    GetParcelReportItem1()
                };

            CollectionAssert.AreEqual(expectedParcelReportItems, parcelReportItems);
        }

        [TestMethod]
        public void GenerateParcelsReport_Should_Generate_Report_When_Current_User_Is_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.DianaDistributor.Active = false;
            UserRoleMockFactory.DianaPurchaser.Active = false;
            UserRoleMockFactory.DianaAdministrator.Active = false;
            UserRoleMockFactory.DianaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var reportService = container.Get<IReportService>();
            
            // Act
            var parcelReportItems = reportService.GenerateParcelsReport();

            // Assert
            var expectedParcelReportItems =
                new[]
                {
                    GetParcelReportItem2(),
                    GetParcelReportItem3()
                };

            CollectionAssert.AreEqual(expectedParcelReportItems, parcelReportItems);
        }

        [TestMethod]
        public void GenerateParcelsReport_Should_Generate_Report_When_Current_User_Is_Seller_And_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.DianaDistributor.Active = true;
            UserRoleMockFactory.DianaPurchaser.Active = false;
            UserRoleMockFactory.DianaAdministrator.Active = false;
            UserRoleMockFactory.DianaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var reportService = container.Get<IReportService>();

            // Act
            var parcelReportItems = reportService.GenerateParcelsReport();

            // Assert
            var expectedParcelReportItems =
                new[]
                {
                    GetParcelReportItem2(),
                    GetParcelReportItem3()
                };

            CollectionAssert.AreEqual(expectedParcelReportItems, parcelReportItems);
        }

        [TestMethod]
        public void GenerateParcelsReport_Should_Throw_Exception_When_Current_User_Is_Not_Purchaser_Distributor_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.DianaDistributor.Active = false;
            UserRoleMockFactory.DianaPurchaser.Active = false;
            UserRoleMockFactory.DianaAdministrator.Active = true;
            UserRoleMockFactory.DianaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var reportService = container.Get<IReportService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => reportService.GenerateParcelsReport(),
                "Only seller, purchaser and distributor can generate parcels report.");
        }

        [TestMethod]
        [Ignore]
        public void GenerateParcelsReport_Database_Test()
        {
            var securityDatas =
                new[]
                {
                    new SecurityData {Login = "chyucka", Password = "12345"},
                    new SecurityData {Login = "Diana", Password = "12345"},
                    new SecurityData {Login = "Olesya", Password = "12345"}
                };

            foreach (var securityData in securityDatas)
            {
                using (var container = IoCFactory.CreateContainer())
                {
                    container.Get<ISecurityService>().LogIn(securityData);

                    var reportService = container.Get<IReportService>();

                    var items = reportService.GenerateParcelsReport();

                    Assert.IsTrue(items.Length > 0);

                    container.Get<ISecurityService>().LogOut();
                }
            }
        }

        [TestMethod]
        public void GenerateDistributorsReport_Should_Generate_Report_When_Current_User_Is_Purchaser()
        {
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = true;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var reportService = container.Get<IReportService>();

            // Act
            var distributorReportItems = reportService.GenerateDistributorsReport();

            // Assert
            var expectedDistributorReportItems =
                new[]
                {
                    GetOlesyaReportItem(),
                    GetDianaReportItem()
                };

            CollectionAssert.AreEqual(expectedDistributorReportItems, distributorReportItems);
        }

        [TestMethod]
        public void GenerateDistributorsReport_Should_Generate_Report_When_Current_User_Is_Distributor()
        {
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.OlesyaDistributor.Active = true;
            UserRoleMockFactory.OlesyaPurchaser.Active = false;
            UserRoleMockFactory.OlesyaAdministrator.Active = false;
            UserRoleMockFactory.OlesyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var reportService = container.Get<IReportService>();

            // Act
            var distributorReportItems = reportService.GenerateDistributorsReport();

            // Assert
            var expectedDistributorReportItems =
                new[]
                {
                    GetOlesyaReportItem()
                };

            CollectionAssert.AreEqual(expectedDistributorReportItems, distributorReportItems);
        }

        [TestMethod]
        public void GenerateDistributorsReport_Should_Generate_Report_When_Current_User_Is_Purchaser_And_Seller()
        {
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.DianaDistributor.Active = true;
            UserRoleMockFactory.DianaPurchaser.Active = false;
            UserRoleMockFactory.DianaAdministrator.Active = false;
            UserRoleMockFactory.DianaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var reportService = container.Get<IReportService>();

            // Act
            var distributorReportItems = reportService.GenerateDistributorsReport();

            // Assert
            var expectedDistributorReportItems =
                new[]
                {
                    GetDianaReportItem()
                };

            CollectionAssert.AreEqual(expectedDistributorReportItems, distributorReportItems);
        }

        [TestMethod]
        public void GenerateDistributorsReport_Should_Throw_Exception_When_Current_User_Is_Not_Purchaser_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.DianaDistributor.Active = false;
            UserRoleMockFactory.DianaPurchaser.Active = false;
            UserRoleMockFactory.DianaAdministrator.Active = true;
            UserRoleMockFactory.DianaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var reportService = container.Get<IReportService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => reportService.GenerateDistributorsReport(),
                "Only purchaser and distributor can generate distributors report.");
        }

        [TestMethod]
        [Ignore]
        public void GenerateDistributorsReport_Database_Test()
        {
            var securityDatas =
                new[]
                {
                    new SecurityData {Login = "chyucka", Password = "12345"},
                    new SecurityData {Login = "Diana", Password = "12345"},
                    new SecurityData {Login = "Olesya", Password = "12345"}
                };

            foreach (var securityData in securityDatas)
            {
                using (var container = IoCFactory.CreateContainer())
                {
                    container.Get<ISecurityService>().LogIn(securityData);

                    var reportService = container.Get<IReportService>();

                    var items = reportService.GenerateDistributorsReport();

                    Assert.IsTrue(items.Length > 0);

                    container.Get<ISecurityService>().LogOut();
                }
            }
        } 

        #endregion
    }
}
